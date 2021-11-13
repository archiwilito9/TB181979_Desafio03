namespace TB181979_Desafio03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombres = c.String(nullable: false, maxLength: 100),
                        primerApellido = c.String(nullable: false, maxLength: 100),
                        segundoApellido = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 8),
                        email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.pedido",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        clientes_id = c.Int(),
                        productos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cliente", t => t.clientes_id)
                .ForeignKey("dbo.producto", t => t.productos_id)
                .Index(t => t.clientes_id)
                .Index(t => t.productos_id);
            
            CreateTable(
                "dbo.producto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false, maxLength: 100),
                        Existencias = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pedido", "productos_id", "dbo.producto");
            DropForeignKey("dbo.pedido", "clientes_id", "dbo.cliente");
            DropIndex("dbo.pedido", new[] { "productos_id" });
            DropIndex("dbo.pedido", new[] { "clientes_id" });
            DropTable("dbo.producto");
            DropTable("dbo.pedido");
            DropTable("dbo.cliente");
        }
    }
}
