namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDistrict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "District", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "District");
        }
    }
}
