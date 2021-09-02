using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations.ProductExtraInfoDb
{
    public partial class createExtraInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductExtraInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Cost_Price = table.Column<decimal>(nullable: false),
                    HSN_Code = table.Column<string>(nullable: true),
                    IsFinanceable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductExtraInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductExtraInfos");
        }
    }
}
