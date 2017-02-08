namespace TOEICEssentialWords.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WordList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordList",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        WordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.WordId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Word", t => t.WordId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordList", "WordId", "dbo.Word");
            DropForeignKey("dbo.WordList", "UserId", "dbo.User");
            DropIndex("dbo.WordList", new[] { "WordId" });
            DropIndex("dbo.WordList", new[] { "UserId" });
            DropTable("dbo.WordList");
        }
    }
}
