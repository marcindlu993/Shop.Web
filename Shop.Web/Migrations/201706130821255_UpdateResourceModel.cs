namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResourceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "SuperBargain", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "SuperBargain");
        }
    }
}
