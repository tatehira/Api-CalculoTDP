using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class PrimaryLBR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TdpCpu = table.Column<int>(type: "int", nullable: false),
                    Gpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TdpGpu = table.Column<int>(type: "int", nullable: false),
                    Motherboard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TdpMotherboard = table.Column<int>(type: "int", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TdpRam = table.Column<int>(type: "int", nullable: false),
                    QntRam = table.Column<int>(type: "int", nullable: false),
                    SSD = table.Column<int>(type: "int", nullable: false),
                    TdpSSD = table.Column<int>(type: "int", nullable: false),
                    HDD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TdpHDD = table.Column<int>(type: "int", nullable: false),
                    TdpTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerComponent", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerComponent");
        }
    }
}
