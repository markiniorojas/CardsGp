using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.dbContext
{
    public class ApplicationDbContext : DbContext
    {

        public readonly IConfiguration _configurasion;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configurasion)
        : base(options)
        {
            _configurasion = configurasion;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("ConectionDataBase"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
