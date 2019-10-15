namespace ResearchNotesManager.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExperimentDetails",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateTime = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(unicode: false),
                        Result = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Experiment_Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Experiments", t => t.Experiment_Guid, cascadeDelete: true)
                .Index(t => t.Experiment_Guid);
            
            DropColumn("dbo.Experiments", "Result");
            DropColumn("dbo.Experiments", "Quantity");
            DropColumn("dbo.Experiments", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiments", "Description", c => c.String(unicode: false));
            AddColumn("dbo.Experiments", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Experiments", "Result", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.ExperimentDetails", "Experiment_Guid", "dbo.Experiments");
            DropIndex("dbo.ExperimentDetails", new[] { "Experiment_Guid" });
            DropTable("dbo.ExperimentDetails");
        }
    }
}
