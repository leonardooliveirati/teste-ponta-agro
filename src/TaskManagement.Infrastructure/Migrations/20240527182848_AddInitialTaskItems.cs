using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    public partial class AddInitialTaskItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Title", "Description", "CreationDate", "Status", "UserId" },

                values: new object[,]
                {
                { "Tarefa 1", "Descrição da tarefa 1", DateTime.Now, 0, "user1" }, 
                { "Tarefa 2", "Descrição da tarefa 2", DateTime.Now, 1, "user2" }, 
                { "Tarefa 3", "Descrição da tarefa 3", DateTime.Now, 2, "user3" }  
 
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Tasks");
        }
    }
}
