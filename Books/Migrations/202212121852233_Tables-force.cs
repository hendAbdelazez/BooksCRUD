namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablesforce : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.books", "Title", c => c.String(nullable: false, maxLength: 258));
            AlterColumn("dbo.books", "Author", c => c.String(nullable: false, maxLength: 126));
            AlterColumn("dbo.books", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.categories", "Name", c => c.String(nullable: false, maxLength: 122));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.categories", "Name", c => c.String());
            AlterColumn("dbo.books", "Description", c => c.String());
            AlterColumn("dbo.books", "Author", c => c.String());
            AlterColumn("dbo.books", "Title", c => c.String());
        }
    }
}
