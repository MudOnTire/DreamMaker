using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Entities;

namespace DreamMaker.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(): base("DreamMakerDB")
        {

        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<FundingProject> FundingProjects { get; set; } 
    }
}
