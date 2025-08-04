//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Entity.dbContext;
//using Entity.Model;
//using Microsoft.EntityFrameworkCore;

//namespace Business.Services
//{
//    public class TurnService
//    {
//        private readonly ApplicationDbContext _context;

//        public TurnService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<GamePlayer> GetNextTurnPlayerAsync(int gameId, int currentPlayerId)
//        {
//            var players = await _context.Set<GamePlayer>()
//                .Include(gp => gp.Player)
//                .Where(gp =>
//                    gp.GamesId == gameId &&
//                    !gp.isDeleted &&
//                    gp.Player.IsEnabled) // ✅ Solo habilitados
//                .OrderBy(gp => gp.id)
//                .ToListAsync();

//            if (!players.Any())
//                return null;

//            var currentIndex = players.FindIndex(p => p.id == currentPlayerId);
//            if (currentIndex == -1) return players.First(); // Fallback si no encuentra el actual

//            var nextIndex = (currentIndex + 1) % players.Count;

//            return players[nextIndex];
//        }
//    }
//}
