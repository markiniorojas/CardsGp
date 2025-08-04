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

    public class PlayerService
    {
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnablePlayerAsync(int playerId)
        {
            var player = await _context.Set<Player>().FindAsync(playerId);
            if (player != null)
            {
                player.IsEnabled = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DisablePlayerAsync(int playerId)
        {
            var player = await _context.Set<Player>().FindAsync(playerId);
            if (player != null)
            {
                player.IsEnabled = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Player>> GetEnabledPlayersAsync()
        {
            return await _context.Set<Player>()
                .Where(p => p.IsEnabled && !p.isDeleted)
                .ToListAsync();
        }
    }


}
