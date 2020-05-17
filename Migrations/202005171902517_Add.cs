namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "District_New");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "District_New", c => c.String(maxLength: 10));
        }
    }
}
