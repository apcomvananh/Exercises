namespace TOEICEssentialWords.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Word", "BrESoundUrl", c => c.String());
            AddColumn("dbo.Word", "NAmESoundUrl", c => c.String());
            AlterColumn("dbo.User", "Salt", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.User", "Salt", c => c.Guid(nullable: false));
            DropColumn("dbo.Word", "NAmESoundUrl");
            DropColumn("dbo.Word", "BrESoundUrl");
        }
    }
}