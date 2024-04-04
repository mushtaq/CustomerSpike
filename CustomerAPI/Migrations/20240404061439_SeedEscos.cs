using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedEscos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Escos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 789123, "Esco-789123" },
                    { 789124, "Esco-789124" },
                    { 789125, "Esco-789125" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Escos",
                keyColumn: "Id",
                keyValues: new object[] { 789123, 789124, 789125 });
        }
        
        
    }
}
