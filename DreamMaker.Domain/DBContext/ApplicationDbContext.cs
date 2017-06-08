using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DreamMaker.Domain.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DreamMakerDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<FundingProject> FundingProjects { get; set; }

        public DbSet<UserWallet> UserWallets { get; set; }
    }
}
