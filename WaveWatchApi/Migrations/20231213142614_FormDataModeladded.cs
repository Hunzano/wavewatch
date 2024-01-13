using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaveWatchApi.Migrations
{
    /// <inheritdoc />
    public partial class FormDataModeladded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormDataModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstRecordTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastRecordTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRecords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastRecordMac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastRecordSsid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinRssi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxRssi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDataModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormDataModels");
        }
    }
}
