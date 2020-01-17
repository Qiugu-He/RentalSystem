namespace IssueTrackerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Users", "MembershipTypeId");
            AddForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Users", new[] { "MembershipTypeId" });
            DropColumn("dbo.Users", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
