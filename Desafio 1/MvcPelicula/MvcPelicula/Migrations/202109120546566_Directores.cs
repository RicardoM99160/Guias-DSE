namespace MvcPelicula.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Directores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.DirectorID);
            
            AddColumn("dbo.Peliculas", "DirectorID", c => c.Int());
            CreateIndex("dbo.Peliculas", "DirectorID");
            AddForeignKey("dbo.Peliculas", "DirectorID", "dbo.Directors", "DirectorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Peliculas", "DirectorID", "dbo.Directors");
            DropIndex("dbo.Peliculas", new[] { "DirectorID" });
            DropColumn("dbo.Peliculas", "DirectorID");
            DropTable("dbo.Directors");
        }
    }
}
