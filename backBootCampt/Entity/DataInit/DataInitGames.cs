using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Entity.DataInit
{
    public static class DataInitGames
    {
        public static void dataGames(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>().HasData(
                new Games
                {
                    id = 1,
                    winner = 1,
                    startTime = "5:00 Pm",
                    endTime = "5:15 Pm",
                    date = new DateTime(2025, 4, 12),
                    isDeleted = false,
                }
                );
        
        }
    }
}
