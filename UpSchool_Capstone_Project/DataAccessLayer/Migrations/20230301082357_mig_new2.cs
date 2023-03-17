using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeDetailID",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "RecipeDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetails_RecipeID",
                table: "RecipeDetails",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDetails_Recipes_RecipeID",
                table: "RecipeDetails",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDetails_Recipes_RecipeID",
                table: "RecipeDetails");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDetails_RecipeID",
                table: "RecipeDetails");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "RecipeDetails");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDetailID",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
