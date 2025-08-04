using Entity.dbContext;
using Entity.Dto;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class RankingService
    {
        private readonly ApplicationDbContext _context;

        public RankingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GamePlayerDto>> GetTop3PlayersAsync(int gameId)
        {
            var players = await _context.Set<GamePlayer>()
                .Include(gp => gp.Player)
                .Where(gp =>
                    gp.GamesId == gameId &&
                    !gp.isDeleted &&
                    gp.Player.IsEnabled) // ✅ Solo jugadores habilitados
                .OrderByDescending(gp => gp.points)
                .Take(3)
                .ToListAsync();

            return players.Select(p => new GamePlayerDto
            {
                id = p.id,
                points = p.points,
                userName = p.Player.userName
            }).ToList();
        }
    }
}

