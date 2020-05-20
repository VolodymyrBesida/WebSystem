namespace WordsForNumbers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckIfOk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Queries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        CompiledResult = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Queries");
        }
    }
}
