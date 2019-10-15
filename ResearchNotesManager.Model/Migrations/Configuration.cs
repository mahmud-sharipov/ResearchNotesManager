namespace ResearchNotesManager.Model.Migrations
{
    using ResearchNotesManager.Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResearchNotesManager.Model.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ResearchNotesManager.Model.EntityContext";
        }

        protected override void Seed(EntityContext context)
        {
            new UnitOfMeasures(context) { Name = "Kg", Description = "Kilogram" };
            new UnitOfMeasures(context) { Name = "M", Description = "Metr" };
            new UnitOfMeasures(context) { Name = "L", Description = "Litr" };
            var unit = new UnitOfMeasures(context) { Name = "EACH", Description = "each" };
            new Product(context) { Name = "Coke", Description = "Case of cokes", UOM = unit };
            new Product(context) { Name = "Glass", Description = "Glass", UOM = unit };
            new Product(context) { Name = "Laptop", Description = "Laptop", UOM = unit };
            new Product(context) { Name = "Cup", Description = "Cup", UOM = unit };
            context.SaveChanges();
        }
    }
}
