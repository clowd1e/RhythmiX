using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhythmiX.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MusicDb");

            migrationBuilder.CreateTable(
                name: "Albums",
                schema: "MusicDb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                schema: "MusicDb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                schema: "MusicDb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                schema: "MusicDb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<long>(type: "bigint", nullable: false),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AlbumImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioDownload = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "MusicDb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHistoryAlbums",
                schema: "MusicDb",
                columns: table => new
                {
                    HistoryAlbumsId = table.Column<long>(type: "bigint", nullable: false),
                    HistoryUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistoryAlbums", x => new { x.HistoryAlbumsId, x.HistoryUsersId });
                    table.ForeignKey(
                        name: "FK_UserHistoryAlbums_Albums_HistoryAlbumsId",
                        column: x => x.HistoryAlbumsId,
                        principalSchema: "MusicDb",
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistoryAlbums_Users_HistoryUsersId",
                        column: x => x.HistoryUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHistoryArtists",
                schema: "MusicDb",
                columns: table => new
                {
                    HistoryArtistsId = table.Column<long>(type: "bigint", nullable: false),
                    HistoryUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistoryArtists", x => new { x.HistoryArtistsId, x.HistoryUsersId });
                    table.ForeignKey(
                        name: "FK_UserHistoryArtists_Artists_HistoryArtistsId",
                        column: x => x.HistoryArtistsId,
                        principalSchema: "MusicDb",
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistoryArtists_Users_HistoryUsersId",
                        column: x => x.HistoryUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHistoryPlaylists",
                schema: "MusicDb",
                columns: table => new
                {
                    HistoryPlaylistsId = table.Column<long>(type: "bigint", nullable: false),
                    HistoryUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistoryPlaylists", x => new { x.HistoryPlaylistsId, x.HistoryUsersId });
                    table.ForeignKey(
                        name: "FK_UserHistoryPlaylists_Playlists_HistoryPlaylistsId",
                        column: x => x.HistoryPlaylistsId,
                        principalSchema: "MusicDb",
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistoryPlaylists_Users_HistoryUsersId",
                        column: x => x.HistoryUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHistoryTracks",
                schema: "MusicDb",
                columns: table => new
                {
                    HistoryTracksId = table.Column<long>(type: "bigint", nullable: false),
                    HistoryUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistoryTracks", x => new { x.HistoryTracksId, x.HistoryUsersId });
                    table.ForeignKey(
                        name: "FK_UserHistoryTracks_Tracks_HistoryTracksId",
                        column: x => x.HistoryTracksId,
                        principalSchema: "MusicDb",
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistoryTracks_Users_HistoryUsersId",
                        column: x => x.HistoryUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikedAlbums",
                schema: "MusicDb",
                columns: table => new
                {
                    LikedAlbumsId = table.Column<long>(type: "bigint", nullable: false),
                    LikedUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedAlbums", x => new { x.LikedAlbumsId, x.LikedUsersId });
                    table.ForeignKey(
                        name: "FK_UserLikedAlbums_Albums_LikedAlbumsId",
                        column: x => x.LikedAlbumsId,
                        principalSchema: "MusicDb",
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikedAlbums_Users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikedArtists",
                schema: "MusicDb",
                columns: table => new
                {
                    LikedArtistsId = table.Column<long>(type: "bigint", nullable: false),
                    LikedUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedArtists", x => new { x.LikedArtistsId, x.LikedUsersId });
                    table.ForeignKey(
                        name: "FK_UserLikedArtists_Artists_LikedArtistsId",
                        column: x => x.LikedArtistsId,
                        principalSchema: "MusicDb",
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikedArtists_Users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikedPlaylists",
                schema: "MusicDb",
                columns: table => new
                {
                    LikedPlaylistsId = table.Column<long>(type: "bigint", nullable: false),
                    LikedUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedPlaylists", x => new { x.LikedPlaylistsId, x.LikedUsersId });
                    table.ForeignKey(
                        name: "FK_UserLikedPlaylists_Playlists_LikedPlaylistsId",
                        column: x => x.LikedPlaylistsId,
                        principalSchema: "MusicDb",
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikedPlaylists_Users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikedTracks",
                schema: "MusicDb",
                columns: table => new
                {
                    LikedTracksId = table.Column<long>(type: "bigint", nullable: false),
                    LikedUsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedTracks", x => new { x.LikedTracksId, x.LikedUsersId });
                    table.ForeignKey(
                        name: "FK_UserLikedTracks_Tracks_LikedTracksId",
                        column: x => x.LikedTracksId,
                        principalSchema: "MusicDb",
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikedTracks_Users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalSchema: "MusicDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryAlbums_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryAlbums",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryArtists_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryArtists",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryPlaylists_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryPlaylists",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistoryTracks_HistoryUsersId",
                schema: "MusicDb",
                table: "UserHistoryTracks",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedAlbums_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedAlbums",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedArtists_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedArtists",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedPlaylists_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedPlaylists",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedTracks_LikedUsersId",
                schema: "MusicDb",
                table: "UserLikedTracks",
                column: "LikedUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHistoryAlbums",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "UserHistoryArtists",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "UserHistoryPlaylists",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "UserHistoryTracks",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "UserLikedAlbums",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "UserLikedArtists",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "UserLikedPlaylists",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "UserLikedTracks",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "Albums",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "Artists",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "Playlists",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "Tracks",
                schema: "MusicDb");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "MusicDb");
        }
    }
}
