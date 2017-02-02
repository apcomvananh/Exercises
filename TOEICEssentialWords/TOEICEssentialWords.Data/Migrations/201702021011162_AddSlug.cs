namespace TOEICEssentialWords.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "Slug", c => c.String());
            AddColumn("dbo.Word", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Word", "Slug");
            DropColumn("dbo.Lesson", "Slug");
        }
    }
}
