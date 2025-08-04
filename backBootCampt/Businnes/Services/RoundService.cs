//using Business.Enums;
//using Entity.dbContext;
//using Entity.Dto;
//using Entity.Model;
//using Microsoft.EntityFrameworkCore;

//public class RoundService
//{
//    private readonly ApplicationDbContext _context;

//    public RoundService(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<GamePlayerDto> EvaluateTurnAsync(int gameId, AttributeToCompare attribute)
//    {
//        var playerCards = await _context.Set<PlayerCard>()
//            .Include(pc => pc.Card)
//            .Include(pc => pc.GamePlayer)
//                .ThenInclude(gp => gp.Player)
//            .Where(pc =>
//                pc.GamePlayer.GamesId == gameId &&
//                pc.GamePlayer.Player.IsEnabled &&    // ✅ Solo jugadores habilitados
//                !pc.isUsed &&
//                !pc.isDeleted)
//            .ToListAsync();

//        if (!playerCards.Any())
//            return null;

//        var winner = playerCards
//            .Select(pc => new
//            {
//                PlayerCard = pc,
//                Value = GetAttributeValue(pc.Card, attribute)
//            })
//            .OrderByDescending(x => x.Value)
//            .FirstOrDefault();

//        if (winner != null)
//        {
//            var gp = winner.PlayerCard.GamePlayer;

//            gp.points += 1;
//            winner.PlayerCard.isUsed = true;

//            await _context.SaveChangesAsync();

//            return new GamePlayerDto
//            {
//                id = gp.id,
//                points = gp.points,
//                userName = gp.Player.userName
//            };
//        }

//        return null;
//    }

//    private decimal GetAttributeValue(Card card, AttributeToCompare attr)
//    {
//        return attr switch
//        {
//            AttributeToCompare.HP => card.hP,
//            AttributeToCompare.FinalSpeed => card.finalSpeed,
//            AttributeToCompare.Torque => card.torque,
//            AttributeToCompare.CylinderCapacity => card.cylinderCapacity,
//            AttributeToCompare.NumberOfCylinders => card.nOclylinder,
//            AttributeToCompare.Weight => TryParseWeight(card.weight),
//            _ => 0
//        };
//    }

//    private decimal TryParseWeight(string weight)
//    {
//        var numeric = new string(weight.Where(char.IsDigit).ToArray());
//        return decimal.TryParse(numeric, out var result) ? result : 0;
//    }
//}

using Business.Enums;
using Entity.dbContext;
using Entity.Dto;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

public class RoundService
{
    private readonly ApplicationDbContext _context;

    public RoundService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RoundResultDto> EvaluateTurnAndGetNextAsync(int gameId, AttributeToCompare attribute, int currentPlayerId)
    {
        // Obtener una carta activa por jugador habilitado para esta ronda
        var playerCards = await _context.Set<PlayerCard>()
            .Include(pc => pc.Card)
            .Include(pc => pc.GamePlayer)
                .ThenInclude(gp => gp.Player)
            .Where(pc =>
                pc.GamePlayer.GamesId == gameId &&
                pc.GamePlayer.Player.IsEnabled &&
                !pc.isUsed &&
                !pc.isDeleted)
            .GroupBy(pc => pc.GamePlayer.id)
            .Select(g => g.First())
            .ToListAsync();

        if (!playerCards.Any())
        {
            return new RoundResultDto
            {
                Winner = null,
                NextPlayer = null,
                Message = "Todos los jugadores han usado sus cartas. El juego ha terminado. Se seleccionan los ganadores."
            };
        }

        // Evaluar el valor del atributo seleccionado
        var evaluated = playerCards
            .Select(pc => new
            {
                PlayerCard = pc,
                Value = GetAttributeValue(pc.Card, attribute)
            })
            .ToList();

        // Seleccionar al jugador con el mayor valor
        var winner = evaluated
            .OrderByDescending(x => x.Value)
            .FirstOrDefault();

        GamePlayerDto winnerDto = null;

        if (winner != null)
        {
            var gp = winner.PlayerCard.GamePlayer;
            gp.points += 1;

            winnerDto = new GamePlayerDto
            {
                id = gp.id,
                points = gp.points,
                userName = gp.Player.userName
            };
        }

        // Marcar todas las cartas de esta ronda como usadas
        foreach (var entry in evaluated)
        {
            entry.PlayerCard.isUsed = true;
        }

        await _context.SaveChangesAsync();

        // Verificar si ya no quedan más cartas disponibles
        bool allCardsUsed = !await _context.Set<PlayerCard>()
            .Include(pc => pc.GamePlayer)
            .Where(pc =>
                pc.GamePlayer.GamesId == gameId &&
                pc.GamePlayer.Player.IsEnabled &&
                !pc.isUsed &&
                !pc.isDeleted)
            .AnyAsync();

        GamePlayerDto nextPlayerDto = null;

        if (!allCardsUsed)
        {
            var players = await _context.Set<GamePlayer>()
                .Include(gp => gp.Player)
                .Where(gp => gp.GamesId == gameId && !gp.isDeleted && gp.Player.IsEnabled)
                .OrderBy(gp => gp.id)
                .ToListAsync();

            var currentIndex = players.FindIndex(p => p.id == currentPlayerId);
            var nextIndex = currentIndex == -1 ? 0 : (currentIndex + 1) % players.Count;
            var nextPlayer = players[nextIndex];

            nextPlayerDto = new GamePlayerDto
            {
                id = nextPlayer.id,
                userName = nextPlayer.Player.userName,
                points = nextPlayer.points
            };
        }

        return new RoundResultDto
        {
            Winner = winnerDto,
            NextPlayer = nextPlayerDto,
            Message = allCardsUsed
                ? "Se han usado todas las cartas. Fin del juego. Se seleccionan los ganadores."
                : $"Turno del siguiente jugador: {nextPlayerDto?.userName}"
        };
    }

    private decimal GetAttributeValue(Card card, AttributeToCompare attr)
    {
        return attr switch
        {
            AttributeToCompare.HP => card.hP,
            AttributeToCompare.FinalSpeed => card.finalSpeed,
            AttributeToCompare.Torque => card.torque,
            AttributeToCompare.CylinderCapacity => card.cylinderCapacity,
            AttributeToCompare.NumberOfCylinders => card.nOclylinder,
            AttributeToCompare.Weight => TryParseWeight(card.weight),
            _ => 0
        };
    }

    private decimal TryParseWeight(string weight)
    {
        var numeric = new string(weight.Where(char.IsDigit).ToArray());
        return decimal.TryParse(numeric, out var result) ? result : 0;
    }
}
