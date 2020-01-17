namespace IssueTrackerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsSubscribedToNewsletter");
        }
    }
}
