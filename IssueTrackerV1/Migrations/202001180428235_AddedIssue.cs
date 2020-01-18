namespace IssueTrackerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIssue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStack = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "GenreId", "dbo.Genres");
            DropIndex("dbo.Issues", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Issues");
        }
    }
}
