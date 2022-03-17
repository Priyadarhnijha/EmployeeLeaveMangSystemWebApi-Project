using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLeaveMang.RepositoryLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyPlannedLeaves",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveDuration = table.Column<int>(type: "int", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyPlannedLeaves", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeClassDetail",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveId = table.Column<int>(type: "int", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClassDetail", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveDetails",
                columns: table => new
                {
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveDuration = table.Column<int>(type: "int", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveDetails", x => x.LeaveId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyPlannedLeaves");

            migrationBuilder.DropTable(
                name: "EmployeeClassDetail");

            migrationBuilder.DropTable(
                name: "LeaveDetails");
        }
    }
}
