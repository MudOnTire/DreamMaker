namespace DreamMaker.Domain.Migrations.DomainContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationA : DbMigrationsConfiguration<DreamMaker.Domain.Concrete.EfDbContext>
    {
        public ConfigurationA()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DomainContext";
        }

        protected override void Seed(DreamMaker.Domain.Concrete.EfDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
