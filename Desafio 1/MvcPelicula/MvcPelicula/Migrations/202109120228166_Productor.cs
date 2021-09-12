namespace MvcPelicula.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peliculas", "Productor", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peliculas", "Productor");
        }
    }
}
