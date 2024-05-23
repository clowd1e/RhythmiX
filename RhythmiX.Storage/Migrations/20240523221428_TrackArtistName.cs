using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhythmiX.Storage.Migrations
{
    /// <inheritdoc />
    public partial class TrackArtistName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                schema: "MusicDb",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistName",
                schema: "MusicDb",
                table: "Tracks");
        }
    }
}
