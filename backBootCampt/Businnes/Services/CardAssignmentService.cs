using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.dbContext;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class CardAssignmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly Random _random = new();

        public CardAssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Asignar 8 cartas aleatorias por jugador (desde tu modelo actual)

        public async Task AssignCardsToEnabledPlayersAsync()
        {
            var enabledPlayers = await _context.Set<Player>()
                .Where(p => p.IsEnabled && !p.isDeleted)
                .ToListAsync();

            var gamePlayers = await _context.Set<GamePlayer>()
                .Where(gp => enabledPlayers.Select(p => p.id).Contains(gp.playersId))
                .ToListAsync();

            var allCards = await _context.Set<Card>()
                .Where(c => !c.isDeleted)
                .ToListAsync();

            foreach (var gp in gamePlayers)
            {
                var selectedCards = allCards
                    .OrderBy(x => _random.Next())
                    .Take(8)
                    .ToList();

                foreach (var card in selectedCards)
                {
                    var playerCard = new PlayerCard
                    {
                        gamePlayerId = gp.id,
                        CardId = card.id,
                        isUsed = false,
                        isDeleted = false
                    };

                    _context.Set<PlayerCard>().Add(playerCard);
                }
            }

            await _context.SaveChangesAsync();
        }

    }

}
