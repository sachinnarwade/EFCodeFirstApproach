namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCHanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Number", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            AddColumn("dbo.Students", "District_New", c => c.String(maxLength: 10));
            DropColumn("dbo.Students", "District");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "District", c => c.String(maxLength: 10));
            DropColumn("dbo.Students", "District_New");
            DropColumn("dbo.Courses", "Number");
        }
    }
}
