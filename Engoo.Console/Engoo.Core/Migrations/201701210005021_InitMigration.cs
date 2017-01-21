namespace Engoo.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonId = c.Int(nullable: false),
                        LessonDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        TimePassed = c.Boolean(nullable: false),
                        LockedLesson = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LessonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lessons");
        }
    }
}
