namespace Engoo.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeachers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "TeacherId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "TeacherId");
        }
    }
}
