using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Infrastructure.Migrations
{
    public partial class InsertTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Productos\"(\"Nombre\",\"Precio\",\"Descuento\",\"IVA\") VALUES('Caja de Colores',25000,15,10)");
            migrationBuilder.Sql("INSERT INTO \"Productos\"(\"Nombre\",\"Precio\",\"Descuento\",\"IVA\") VALUES('Cuaderno',2000,5,10)");
            migrationBuilder.Sql("INSERT INTO \"Productos\"(\"Nombre\",\"Precio\",\"Descuento\",\"IVA\") VALUES('Blog',12000,10,10)");
            migrationBuilder.Sql("INSERT INTO \"Productos\"(\"Nombre\",\"Precio\",\"Descuento\",\"IVA\") VALUES('Libro Español',55000,25,19)");
            migrationBuilder.Sql("INSERT INTO \"Productos\"(\"Nombre\",\"Precio\",\"Descuento\",\"IVA\") VALUES('Libro Matematicas',60000,25,19)");

            migrationBuilder.Sql("INSERT INTO \"Clientes\"(\"NumeroDocumento\",\"Nombre\") VALUES('10102020','JOHN DOE')");
            migrationBuilder.Sql("INSERT INTO \"Clientes\"(\"NumeroDocumento\",\"Nombre\") VALUES('20200010','MARY DOE')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Productos\"", true);
            migrationBuilder.Sql("DELETE FROM \"Clientes\"", true);
        }
    }
}
