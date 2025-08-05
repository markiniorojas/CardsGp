using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataInit
{
    public static class DataInitPlayer
    {
        public static void dataPlayers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    id = 1 ,
                    isDeleted = false,
                    userName = "camilosada12",
                    IsEnabled = true,
                },
                 new Player
                 {
                     id = 2,
                     isDeleted = false,
                     userName = "marcos12",
                     IsEnabled = false,
                 },
                  new Player
                  {
                      id = 3,
                      isDeleted = false,
                      userName = "palomar12",
                      IsEnabled = false,
                  }
                  , new Player
                  {
                      id = 4,
                      isDeleted = false,
                      userName = "palmar12",
                      IsEnabled = false,
                  },
                   new Player
                   {
                       id = 5,
                       isDeleted = false,
                       userName = "marcami31",
                       IsEnabled = false,
                   });
            
        }
    }
}

