using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Entity.DataInit
{
    public static class DataInitPlayersCard
    {
        public static void dataPlayersCard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerCard>().HasData(
                new PlayerCard
                {
                    id = 1,
                    gamePlayerId = 1,
                    CardId = 1,
                    isUsed = true,
                    isDeleted = false,
                });
        }
    }
}
