using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbumShare2.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Albums_AlbumId",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Image",
                newName: "AlbumID");

            migrationBuilder.RenameIndex(
                name: "IX_Image_AlbumId",
                table: "Image",
                newName: "IX_Image_AlbumID");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumID",
                table: "Image",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Albums_AlbumID",
                table: "Image",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Albums_AlbumID",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "Image",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_AlbumID",
                table: "Image",
                newName: "IX_Image_AlbumId");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Image",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Albums_AlbumId",
                table: "Image",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
