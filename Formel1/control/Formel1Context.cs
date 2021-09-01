using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formel1.model;
using Microsoft.EntityFrameworkCore;


namespace Formel1.control
{
    public class Formel1Context : DbContext
    {
        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Result> Results{ get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Season> Season { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Formel1;");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }

}