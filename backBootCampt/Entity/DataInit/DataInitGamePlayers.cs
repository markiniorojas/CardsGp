using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Entity.DataInit
{
    public static class DataInitGamePlayers
    {
        public static void dataGamePlayers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePlayer>().HasData(
                new GamePlayer
                {
                    id = 1,
                    points = 3,
                    playersId = 1,
                    GamesId = 1,
                    isDeleted = false,
                },
                 new GamePlayer
                 {
                     id = 2,
                     points = 2,
                     playersId = 2,
                     GamesId = 1,
                     isDeleted = false,
                 },
                  new GamePlayer
                  {
                      id = 3,
                      points = 5,
                      playersId = 3,
                      GamesId = 1,
                      isDeleted = false,
                  },
                   new GamePlayer
                   {
                       id = 4,
                       points = 6,
                       playersId = 4,
                       GamesId = 1,
                       isDeleted = false,
                   },
                    new GamePlayer
                    {
                        id = 5,
                        points = 1,
                        playersId = 5,
                        GamesId = 1,
                        isDeleted = false,
                    });
        }
    }
}
