using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringMachinesAPI.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OsVersion = table.Column<string>(nullable: true),
                    DotNetVersion = table.Column<string>(nullable: true),
                    IsUp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Antivirus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HasAntivirus = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antivirus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antivirus_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HardDrive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FreeSpace = table.Column<string>(nullable: true),
                    UsedSpace = table.Column<string>(nullable: true),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDrive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardDrive_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antivirus_MachineId",
                table: "Antivirus",
                column: "MachineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardDrive_MachineId",
                table: "HardDrive",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antivirus");

            migrationBuilder.DropTable(
                name: "HardDrive");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
