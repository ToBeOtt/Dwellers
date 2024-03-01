using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dwellers.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BulletinPriorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BulletinStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerConversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerConversations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemScope = table.Column<int>(type: "int", nullable: false),
                    ItemPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ItemStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DwellerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dwellers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceScope = table.Column<int>(type: "int", nullable: false),
                    ServiceStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visibility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bulletins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bulletins_BulletinPriorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "BulletinPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bulletins_BulletinStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BulletinStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bulletins_Dwellers_DwellerId",
                        column: x => x.DwellerId,
                        principalTable: "Dwellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BulletinScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    BulletinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulletinScopes_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalTable: "Bulletins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BulletinTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BulletinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulletinTags_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalTable: "Bulletins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dwellings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DwellingProfilePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BulletinId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwellings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dwellings_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalTable: "Bulletins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BorrowedItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Returned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_DwellerItems_DwellerItemId",
                        column: x => x.DwellerItemId,
                        principalTable: "DwellerItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellerEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventScopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DwellerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DwellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerEvents_Dwellers_DwellerId",
                        column: x => x.DwellerId,
                        principalTable: "Dwellers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DwellerEvents_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellerEvents_Visibility_EventScopeId",
                        column: x => x.EventScopeId,
                        principalTable: "Visibility",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DwellingGallery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellingImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellingGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellingGallery_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellingInhabitants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellingInhabitants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellingInhabitants_Dwellers_DwellerId",
                        column: x => x.DwellerId,
                        principalTable: "Dwellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellingInhabitants_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberInConversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInConversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberInConversations_DwellerConversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "DwellerConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberInConversations_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvidedServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsProvider = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceReturned = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_DwellerServices_DwellerServiceId",
                        column: x => x.DwellerServiceId,
                        principalTable: "DwellerServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScopedDwellings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BulletinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScopedDwellings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScopedDwellings_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalTable: "Bulletins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScopedDwellings_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_DwellerItemId",
                table: "BorrowedItems",
                column: "DwellerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_DwellingId",
                table: "BorrowedItems",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_DwellerId",
                table: "Bulletins",
                column: "DwellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_PriorityId",
                table: "Bulletins",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_StatusId",
                table: "Bulletins",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BulletinScopes_BulletinId",
                table: "BulletinScopes",
                column: "BulletinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BulletinTags_BulletinId",
                table: "BulletinTags",
                column: "BulletinId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_DwellerId",
                table: "DwellerEvents",
                column: "DwellerId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_DwellingId",
                table: "DwellerEvents",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_EventScopeId",
                table: "DwellerEvents",
                column: "EventScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingGallery_DwellingId",
                table: "DwellingGallery",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingInhabitants_DwellerId",
                table: "DwellingInhabitants",
                column: "DwellerId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingInhabitants_DwellingId",
                table: "DwellingInhabitants",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Dwellings_BulletinId",
                table: "Dwellings",
                column: "BulletinId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberInConversations_ConversationId",
                table: "MemberInConversations",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberInConversations_DwellingId",
                table: "MemberInConversations",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_DwellerServiceId",
                table: "ProvidedServices",
                column: "DwellerServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_DwellingId",
                table: "ProvidedServices",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_ScopedDwellings_BulletinId",
                table: "ScopedDwellings",
                column: "BulletinId");

            migrationBuilder.CreateIndex(
                name: "IX_ScopedDwellings_DwellingId",
                table: "ScopedDwellings",
                column: "DwellingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedItems");

            migrationBuilder.DropTable(
                name: "BulletinScopes");

            migrationBuilder.DropTable(
                name: "BulletinTags");

            migrationBuilder.DropTable(
                name: "DwellerEvents");

            migrationBuilder.DropTable(
                name: "DwellerMessages");

            migrationBuilder.DropTable(
                name: "DwellingGallery");

            migrationBuilder.DropTable(
                name: "DwellingInhabitants");

            migrationBuilder.DropTable(
                name: "MemberInConversations");

            migrationBuilder.DropTable(
                name: "ProvidedServices");

            migrationBuilder.DropTable(
                name: "ScopedDwellings");

            migrationBuilder.DropTable(
                name: "DwellerItems");

            migrationBuilder.DropTable(
                name: "Visibility");

            migrationBuilder.DropTable(
                name: "DwellerConversations");

            migrationBuilder.DropTable(
                name: "DwellerServices");

            migrationBuilder.DropTable(
                name: "Dwellings");

            migrationBuilder.DropTable(
                name: "Bulletins");

            migrationBuilder.DropTable(
                name: "BulletinPriorities");

            migrationBuilder.DropTable(
                name: "BulletinStatus");

            migrationBuilder.DropTable(
                name: "Dwellers");
        }
    }
}
