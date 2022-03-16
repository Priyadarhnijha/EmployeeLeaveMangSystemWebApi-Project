using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLeaveMang.RepositoryLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeClassDetail",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "String(max)", nullable: false),
                    EmpGender = table.Column<string>(type: "String(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClassDetail", x => x.EmpId);
                });



            migrationBuilder.CreateTable(
               name: "EmployeeLeaveType",
               columns: table => new
               {
                   LeaveType = table.Column<string>(type: "String", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   LeaveDays = table.Column<int>(type: "nvarchar(3)", nullable: false),
                   EmpId = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_EmployeeLeaveType", x => x.EmpId);
               });




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeClassDetail");
        }
    }
}
