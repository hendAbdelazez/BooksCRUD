namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNeedTablesforce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        categoryId = c.Byte(nullable: false),
                        Addon = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.books", "categoryId", "dbo.categories");
            DropIndex("dbo.books", new[] { "categoryId" });
            DropTable("dbo.categories");
            DropTable("dbo.books");
        }
    }
}
