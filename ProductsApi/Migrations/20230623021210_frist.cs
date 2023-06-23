using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class frist : Migration
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
                    Gpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QntRam = table.Column<int>(type: "int", nullable: false),
                    TdpCpu = table.Column<int>(type: "int", nullable: false),
                    TdpGpu = table.Column<int>(type: "int", nullable: false),
                    TdpRam = table.Column<int>(type: "int", nullable: false),
                    TdpHDDPC = table.Column<int>(type: "int", nullable: false),
                    TdpHDDNote = table.Column<int>(type: "int", nullable: false),
                    TdpSSDSata = table.Column<int>(type: "int", nullable: false),
                    TdpSSDNvme = table.Column<int>(type: "int", nullable: false),
                    TdpTotal = table.Column<int>(type: "int", nullable: false),
                    TdpMotherboardMini = table.Column<int>(type: "int", nullable: false),
                    TdpMotherboardMicro = table.Column<int>(type: "int", nullable: false),
                    TdpMotherboardATX = table.Column<int>(type: "int", nullable: false),
                    TdpMotherboardExtended = table.Column<int>(type: "int", nullable: false),
                    HDD = table.Column<int>(type: "int", nullable: false),
                    SSD = table.Column<int>(type: "int", nullable: false),
                    Motherboard = table.Column<int>(type: "int", nullable: false),
                    RotuloCategory = table.Column<int>(type: "int", nullable: false)
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
