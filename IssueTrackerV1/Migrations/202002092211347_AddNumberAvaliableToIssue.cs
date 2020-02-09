namespace IssueTrackerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvaliableToIssue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "NumberAvaliable", c => c.Byte(nullable: false));

            Sql("UPDATE Issues SET NumberAvaliable = NumberInStack");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "NumberAvaliable");
        }
    }
}
