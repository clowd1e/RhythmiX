using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhythmiX.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryAlbums_Albums_HistoryAlbumsId",
                schema: "MusicDb",
                table: "UserHistoryAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryAlbums_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryArtists_Artists_HistoryArtistsId",
                schema: "MusicDb",
                table: "UserHistoryArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryArtists_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryPlaylists_Playlists_HistoryPlaylistsId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryPlaylists_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryTracks_Tracks_HistoryTracksId",
                schema: "MusicDb",
                table: "UserHistoryTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryTracks_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedAlbums_Albums_LikedAlbumsId",
                schema: "MusicDb",
                table: "UserLikedAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedAlbums_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedArtists_Artists_LikedArtistsId",
                schema: "MusicDb",
                table: "UserLikedArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedArtists_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedPlaylists_Playlists_LikedPlaylistsId",
                schema: "MusicDb",
                table: "UserLikedPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedPlaylists_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedTracks_Tracks_LikedTracksId",
                schema: "MusicDb",
                table: "UserLikedTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedTracks_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedTracks",
                schema: "MusicDb",
                table: "UserLikedTracks");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedTracks_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedPlaylists",
                schema: "MusicDb",
                table: "UserLikedPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedPlaylists_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedArtists",
                schema: "MusicDb",
                table: "UserLikedArtists");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedArtists_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedAlbums",
                schema: "MusicDb",
                table: "UserLikedAlbums");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedAlbums_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedAlbums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryTracks",
                schema: "MusicDb",
                table: "UserHistoryTracks");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryTracks_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryPlaylists",
                schema: "MusicDb",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryPlaylists_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryArtists",
                schema: "MusicDb",
                table: "UserHistoryArtists");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryArtists_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryAlbums",
                schema: "MusicDb",
                table: "UserHistoryAlbums");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryAlbums_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryAlbums");

            migrationBuilder.RenameTable(
                name: "UserLikedTracks",
                schema: "MusicDb",
                newName: "UserLikedTracks");

            migrationBuilder.RenameTable(
                name: "UserLikedPlaylists",
                schema: "MusicDb",
                newName: "UserLikedPlaylists");

            migrationBuilder.RenameTable(
                name: "UserLikedArtists",
                schema: "MusicDb",
                newName: "UserLikedArtists");

            migrationBuilder.RenameTable(
                name: "UserLikedAlbums",
                schema: "MusicDb",
                newName: "UserLikedAlbums");

            migrationBuilder.RenameTable(
                name: "UserHistoryTracks",
                schema: "MusicDb",
                newName: "UserHistoryTracks");

            migrationBuilder.RenameTable(
                name: "UserHistoryPlaylists",
                schema: "MusicDb",
                newName: "UserHistoryPlaylists");

            migrationBuilder.RenameTable(
                name: "UserHistoryArtists",
                schema: "MusicDb",
                newName: "UserHistoryArtists");

            migrationBuilder.RenameTable(
                name: "UserHistoryAlbums",
                schema: "MusicDb",
                newName: "UserHistoryAlbums");

            migrationBuilder.RenameColumn(
                name: "LikedUsersId",
                table: "UserLikedTracks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LikedTracksId",
                table: "UserLikedTracks",
                newName: "TrackId");

            migrationBuilder.RenameColumn(
                name: "LikedUsersId",
                table: "UserLikedPlaylists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LikedPlaylistsId",
                table: "UserLikedPlaylists",
                newName: "PlaylistId");

            migrationBuilder.RenameColumn(
                name: "LikedUsersId",
                table: "UserLikedArtists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LikedArtistsId",
                table: "UserLikedArtists",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "LikedUsersId",
                table: "UserLikedAlbums",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LikedAlbumsId",
                table: "UserLikedAlbums",
                newName: "AlbumId");

            migrationBuilder.RenameColumn(
                name: "HistoryUsersId",
                table: "UserHistoryTracks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "HistoryTracksId",
                table: "UserHistoryTracks",
                newName: "TrackId");

            migrationBuilder.RenameColumn(
                name: "HistoryUsersId",
                table: "UserHistoryPlaylists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "HistoryPlaylistsId",
                table: "UserHistoryPlaylists",
                newName: "PlaylistId");

            migrationBuilder.RenameColumn(
                name: "HistoryUsersId",
                table: "UserHistoryArtists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "HistoryArtistsId",
                table: "UserHistoryArtists",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "HistoryUsersId",
                table: "UserHistoryAlbums",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "HistoryAlbumsId",
                table: "UserHistoryAlbums",
                newName: "AlbumId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "MusicDb",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                schema: "MusicDb",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserLikedTracks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserLikedPlaylists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserLikedArtists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserLikedAlbums",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserHistoryTracks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserHistoryPlaylists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserHistoryArtists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserHistoryAlbums",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedTracks",
                table: "UserLikedTracks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedPlaylists",
                table: "UserLikedPlaylists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedArtists",
                table: "UserLikedArtists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedAlbums",
                table: "UserLikedAlbums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryTracks",
                table: "UserHistoryTracks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryPlaylists",
                table: "UserHistoryPlaylists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryArtists",
                table: "UserHistoryArtists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryAlbums",
                table: "UserHistoryAlbums",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedTracks_TrackId",
                table: "UserLikedTracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedTracks_UserId_TrackId",
                table: "UserLikedTracks",
                columns: new[] { "UserId", "TrackId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedPlaylists_PlaylistId",
                table: "UserLikedPlaylists",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedPlaylists_UserId_PlaylistId",
                table: "UserLikedPlaylists",
                columns: new[] { "UserId", "PlaylistId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedArtists_ArtistId",
                table: "UserLikedArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedArtists_UserId_ArtistId",
                table: "UserLikedArtists",
                columns: new[] { "UserId", "ArtistId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedAlbums_AlbumId",
                table: "UserLikedAlbums",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedAlbums_UserId_AlbumId",
                table: "UserLikedAlbums",
                columns: new[] { "UserId", "AlbumId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryTracks_TrackId",
                table: "UserHistoryTracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryTracks_UserId_TrackId",
                table: "UserHistoryTracks",
                columns: new[] { "UserId", "TrackId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryPlaylists_PlaylistId",
                table: "UserHistoryPlaylists",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryPlaylists_UserId_PlaylistId",
                table: "UserHistoryPlaylists",
                columns: new[] { "UserId", "PlaylistId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryArtists_ArtistId",
                table: "UserHistoryArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryArtists_UserId_ArtistId",
                table: "UserHistoryArtists",
                columns: new[] { "UserId", "ArtistId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryAlbums_AlbumId",
                table: "UserHistoryAlbums",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryAlbums_UserId_AlbumId",
                table: "UserHistoryAlbums",
                columns: new[] { "UserId", "AlbumId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryAlbums_Albums_AlbumId",
                table: "UserHistoryAlbums",
                column: "AlbumId",
                principalSchema: "MusicDb",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryAlbums_Users_UserId",
                table: "UserHistoryAlbums",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryArtists_Artists_ArtistId",
                table: "UserHistoryArtists",
                column: "ArtistId",
                principalSchema: "MusicDb",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryArtists_Users_UserId",
                table: "UserHistoryArtists",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryPlaylists_Playlists_PlaylistId",
                table: "UserHistoryPlaylists",
                column: "PlaylistId",
                principalSchema: "MusicDb",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryPlaylists_Users_UserId",
                table: "UserHistoryPlaylists",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryTracks_Tracks_TrackId",
                table: "UserHistoryTracks",
                column: "TrackId",
                principalSchema: "MusicDb",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryTracks_Users_UserId",
                table: "UserHistoryTracks",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedAlbums_Albums_AlbumId",
                table: "UserLikedAlbums",
                column: "AlbumId",
                principalSchema: "MusicDb",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedAlbums_Users_UserId",
                table: "UserLikedAlbums",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedArtists_Artists_ArtistId",
                table: "UserLikedArtists",
                column: "ArtistId",
                principalSchema: "MusicDb",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedArtists_Users_UserId",
                table: "UserLikedArtists",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedPlaylists_Playlists_PlaylistId",
                table: "UserLikedPlaylists",
                column: "PlaylistId",
                principalSchema: "MusicDb",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedPlaylists_Users_UserId",
                table: "UserLikedPlaylists",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedTracks_Tracks_TrackId",
                table: "UserLikedTracks",
                column: "TrackId",
                principalSchema: "MusicDb",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedTracks_Users_UserId",
                table: "UserLikedTracks",
                column: "UserId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryAlbums_Albums_AlbumId",
                table: "UserHistoryAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryAlbums_Users_UserId",
                table: "UserHistoryAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryArtists_Artists_ArtistId",
                table: "UserHistoryArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryArtists_Users_UserId",
                table: "UserHistoryArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryPlaylists_Playlists_PlaylistId",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryPlaylists_Users_UserId",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryTracks_Tracks_TrackId",
                table: "UserHistoryTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistoryTracks_Users_UserId",
                table: "UserHistoryTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedAlbums_Albums_AlbumId",
                table: "UserLikedAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedAlbums_Users_UserId",
                table: "UserLikedAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedArtists_Artists_ArtistId",
                table: "UserLikedArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedArtists_Users_UserId",
                table: "UserLikedArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedPlaylists_Playlists_PlaylistId",
                table: "UserLikedPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedPlaylists_Users_UserId",
                table: "UserLikedPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedTracks_Tracks_TrackId",
                table: "UserLikedTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedTracks_Users_UserId",
                table: "UserLikedTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedTracks",
                table: "UserLikedTracks");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedTracks_TrackId",
                table: "UserLikedTracks");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedTracks_UserId_TrackId",
                table: "UserLikedTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedPlaylists",
                table: "UserLikedPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedPlaylists_PlaylistId",
                table: "UserLikedPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedPlaylists_UserId_PlaylistId",
                table: "UserLikedPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedArtists",
                table: "UserLikedArtists");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedArtists_ArtistId",
                table: "UserLikedArtists");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedArtists_UserId_ArtistId",
                table: "UserLikedArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedAlbums",
                table: "UserLikedAlbums");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedAlbums_AlbumId",
                table: "UserLikedAlbums");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedAlbums_UserId_AlbumId",
                table: "UserLikedAlbums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryTracks",
                table: "UserHistoryTracks");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryTracks_TrackId",
                table: "UserHistoryTracks");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryTracks_UserId_TrackId",
                table: "UserHistoryTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryPlaylists",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryPlaylists_PlaylistId",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryPlaylists_UserId_PlaylistId",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryArtists",
                table: "UserHistoryArtists");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryArtists_ArtistId",
                table: "UserHistoryArtists");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryArtists_UserId_ArtistId",
                table: "UserHistoryArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistoryAlbums",
                table: "UserHistoryAlbums");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryAlbums_AlbumId",
                table: "UserHistoryAlbums");

            migrationBuilder.DropIndex(
                name: "IX_UserHistoryAlbums_UserId_AlbumId",
                table: "UserHistoryAlbums");

            migrationBuilder.DropColumn(
                name: "ArtistName",
                schema: "MusicDb",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLikedTracks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLikedPlaylists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLikedArtists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLikedAlbums");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserHistoryTracks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserHistoryPlaylists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserHistoryArtists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserHistoryAlbums");

            migrationBuilder.RenameTable(
                name: "UserLikedTracks",
                newName: "UserLikedTracks",
                newSchema: "MusicDb");

            migrationBuilder.RenameTable(
                name: "UserLikedPlaylists",
                newName: "UserLikedPlaylists",
                newSchema: "MusicDb");

            migrationBuilder.RenameTable(
                name: "UserLikedArtists",
                newName: "UserLikedArtists",
                newSchema: "MusicDb");

            migrationBuilder.RenameTable(
                name: "UserLikedAlbums",
                newName: "UserLikedAlbums",
                newSchema: "MusicDb");

            migrationBuilder.RenameTable(
                name: "UserHistoryTracks",
                newName: "UserHistoryTracks",
                newSchema: "MusicDb");

            migrationBuilder.RenameTable(
                name: "UserHistoryPlaylists",
                newName: "UserHistoryPlaylists",
                newSchema: "MusicDb");

            migrationBuilder.RenameTable(
                name: "UserHistoryArtists",
                newName: "UserHistoryArtists",
                newSchema: "MusicDb");

            migrationBuilder.RenameTable(
                name: "UserHistoryAlbums",
                newName: "UserHistoryAlbums",
                newSchema: "MusicDb");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserLikedTracks",
                newName: "LikedUsersId");

            migrationBuilder.RenameColumn(
                name: "TrackId",
                schema: "MusicDb",
                table: "UserLikedTracks",
                newName: "LikedTracksId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserLikedPlaylists",
                newName: "LikedUsersId");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                schema: "MusicDb",
                table: "UserLikedPlaylists",
                newName: "LikedPlaylistsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserLikedArtists",
                newName: "LikedUsersId");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                schema: "MusicDb",
                table: "UserLikedArtists",
                newName: "LikedArtistsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserLikedAlbums",
                newName: "LikedUsersId");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                schema: "MusicDb",
                table: "UserLikedAlbums",
                newName: "LikedAlbumsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserHistoryTracks",
                newName: "HistoryUsersId");

            migrationBuilder.RenameColumn(
                name: "TrackId",
                schema: "MusicDb",
                table: "UserHistoryTracks",
                newName: "HistoryTracksId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists",
                newName: "HistoryUsersId");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists",
                newName: "HistoryPlaylistsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserHistoryArtists",
                newName: "HistoryUsersId");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                schema: "MusicDb",
                table: "UserHistoryArtists",
                newName: "HistoryArtistsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MusicDb",
                table: "UserHistoryAlbums",
                newName: "HistoryUsersId");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                schema: "MusicDb",
                table: "UserHistoryAlbums",
                newName: "HistoryAlbumsId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "MusicDb",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedTracks",
                schema: "MusicDb",
                table: "UserLikedTracks",
                columns: new[] { "LikedTracksId", "LikedUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedPlaylists",
                schema: "MusicDb",
                table: "UserLikedPlaylists",
                columns: new[] { "LikedPlaylistsId", "LikedUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedArtists",
                schema: "MusicDb",
                table: "UserLikedArtists",
                columns: new[] { "LikedArtistsId", "LikedUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedAlbums",
                schema: "MusicDb",
                table: "UserLikedAlbums",
                columns: new[] { "LikedAlbumsId", "LikedUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryTracks",
                schema: "MusicDb",
                table: "UserHistoryTracks",
                columns: new[] { "HistoryTracksId", "HistoryUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryPlaylists",
                schema: "MusicDb",
                table: "UserHistoryPlaylists",
                columns: new[] { "HistoryPlaylistsId", "HistoryUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryArtists",
                schema: "MusicDb",
                table: "UserHistoryArtists",
                columns: new[] { "HistoryArtistsId", "HistoryUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistoryAlbums",
                schema: "MusicDb",
                table: "UserHistoryAlbums",
                columns: new[] { "HistoryAlbumsId", "HistoryUsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedTracks_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedTracks",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedPlaylists_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedPlaylists",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedArtists_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedArtists",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedAlbums_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedAlbums",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryTracks_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryTracks",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryPlaylists_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryArtists_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryArtists",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryAlbums_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryAlbums",
                column: "HistoryUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryAlbums_Albums_HistoryAlbumsId",
                schema: "MusicDb",
                table: "UserHistoryAlbums",
                column: "HistoryAlbumsId",
                principalSchema: "MusicDb",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryAlbums_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryAlbums",
                column: "HistoryUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryArtists_Artists_HistoryArtistsId",
                schema: "MusicDb",
                table: "UserHistoryArtists",
                column: "HistoryArtistsId",
                principalSchema: "MusicDb",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryArtists_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryArtists",
                column: "HistoryUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryPlaylists_Playlists_HistoryPlaylistsId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists",
                column: "HistoryPlaylistsId",
                principalSchema: "MusicDb",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryPlaylists_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists",
                column: "HistoryUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryTracks_Tracks_HistoryTracksId",
                schema: "MusicDb",
                table: "UserHistoryTracks",
                column: "HistoryTracksId",
                principalSchema: "MusicDb",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistoryTracks_Users_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryTracks",
                column: "HistoryUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedAlbums_Albums_LikedAlbumsId",
                schema: "MusicDb",
                table: "UserLikedAlbums",
                column: "LikedAlbumsId",
                principalSchema: "MusicDb",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedAlbums_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedAlbums",
                column: "LikedUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedArtists_Artists_LikedArtistsId",
                schema: "MusicDb",
                table: "UserLikedArtists",
                column: "LikedArtistsId",
                principalSchema: "MusicDb",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedArtists_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedArtists",
                column: "LikedUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedPlaylists_Playlists_LikedPlaylistsId",
                schema: "MusicDb",
                table: "UserLikedPlaylists",
                column: "LikedPlaylistsId",
                principalSchema: "MusicDb",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedPlaylists_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedPlaylists",
                column: "LikedUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedTracks_Tracks_LikedTracksId",
                schema: "MusicDb",
                table: "UserLikedTracks",
                column: "LikedTracksId",
                principalSchema: "MusicDb",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedTracks_Users_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedTracks",
                column: "LikedUsersId",
                principalSchema: "MusicDb",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
