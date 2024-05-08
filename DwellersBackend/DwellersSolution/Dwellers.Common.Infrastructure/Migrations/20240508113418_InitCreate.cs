using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dwellers.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dweller_schema");

            migrationBuilder.CreateTable(
                name: "BulletinPriorities",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BulletinStatus",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerConversations",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerConversations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dwellers",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ProfilePhoto = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: true),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerScopes",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Scope = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerServices",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ServiceScope = table.Column<int>(type: "integer", nullable: false),
                    ServiceStatus = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dwellings",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvitationCode = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DwellingProfilePhoto = table.Column<byte[]>(type: "bytea", nullable: true),
                    DwellingFriends = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwellings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bulletins",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriorityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellerId = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bulletins_BulletinPriorities_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "dweller_schema",
                        principalTable: "BulletinPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bulletins_BulletinStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dweller_schema",
                        principalTable: "BulletinStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bulletins_Dwellers_DwellerId",
                        column: x => x.DwellerId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DwellerMessages",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageText = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    DwellerId = table.Column<string>(type: "text", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerMessages_DwellerConversations_ConversationId",
                        column: x => x.ConversationId,
                        principalSchema: "dweller_schema",
                        principalTable: "DwellerConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellerMessages_Dwellers_DwellerId",
                        column: x => x.DwellerId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellerEvents",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventScopeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DwellerId = table.Column<string>(type: "text", nullable: true),
                    DwellingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerEvents_DwellerScopes_EventScopeId",
                        column: x => x.EventScopeId,
                        principalSchema: "dweller_schema",
                        principalTable: "DwellerScopes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DwellerEvents_Dwellers_DwellerId",
                        column: x => x.DwellerId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DwellerEvents_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellerItems",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ItemScope = table.Column<int>(type: "integer", nullable: false),
                    ItemPhoto = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsBorrowed = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerOfItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerItems_Dwellings_OwnerOfItemId",
                        column: x => x.OwnerOfItemId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellingGallery",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellingImage = table.Column<byte[]>(type: "bytea", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellingGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellingGallery_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellingInhabitants",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellingInhabitants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellingInhabitants_Dwellers_DwellerId",
                        column: x => x.DwellerId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellingInhabitants_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberInConversations",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInConversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberInConversations_DwellerConversations_ConversationId",
                        column: x => x.ConversationId,
                        principalSchema: "dweller_schema",
                        principalTable: "DwellerConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberInConversations_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvidedServices",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellerServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsProvider = table.Column<bool>(type: "boolean", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ServiceReturned = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_DwellerServices_DwellerServiceId",
                        column: x => x.DwellerServiceId,
                        principalSchema: "dweller_schema",
                        principalTable: "DwellerServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BulletinScopes",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Visibility = table.Column<int>(type: "integer", nullable: false),
                    BulletinId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulletinScopes_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalSchema: "dweller_schema",
                        principalTable: "Bulletins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BulletinTags",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    BulletinId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulletinTags_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalSchema: "dweller_schema",
                        principalTable: "Bulletins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedItems",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellerItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsReturned = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_DwellerItems_DwellerItemId",
                        column: x => x.DwellerItemId,
                        principalSchema: "dweller_schema",
                        principalTable: "DwellerItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScopedDwellings",
                schema: "dweller_schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BulletinId = table.Column<Guid>(type: "uuid", nullable: false),
                    DwellingId = table.Column<Guid>(type: "uuid", nullable: false),
                    BulletinScopeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScopedDwellings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScopedDwellings_BulletinScopes_BulletinScopeId",
                        column: x => x.BulletinScopeId,
                        principalSchema: "dweller_schema",
                        principalTable: "BulletinScopes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScopedDwellings_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalSchema: "dweller_schema",
                        principalTable: "Bulletins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScopedDwellings_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalSchema: "dweller_schema",
                        principalTable: "Dwellings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_DwellerItemId",
                schema: "dweller_schema",
                table: "BorrowedItems",
                column: "DwellerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_DwellingId",
                schema: "dweller_schema",
                table: "BorrowedItems",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_DwellerId",
                schema: "dweller_schema",
                table: "Bulletins",
                column: "DwellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_PriorityId",
                schema: "dweller_schema",
                table: "Bulletins",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_StatusId",
                schema: "dweller_schema",
                table: "Bulletins",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BulletinScopes_BulletinId",
                schema: "dweller_schema",
                table: "BulletinScopes",
                column: "BulletinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BulletinTags_BulletinId",
                schema: "dweller_schema",
                table: "BulletinTags",
                column: "BulletinId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_DwellerId",
                schema: "dweller_schema",
                table: "DwellerEvents",
                column: "DwellerId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_DwellingId",
                schema: "dweller_schema",
                table: "DwellerEvents",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_EventScopeId",
                schema: "dweller_schema",
                table: "DwellerEvents",
                column: "EventScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerItems_OwnerOfItemId",
                schema: "dweller_schema",
                table: "DwellerItems",
                column: "OwnerOfItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerMessages_ConversationId",
                schema: "dweller_schema",
                table: "DwellerMessages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerMessages_DwellerId",
                schema: "dweller_schema",
                table: "DwellerMessages",
                column: "DwellerId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingGallery_DwellingId",
                schema: "dweller_schema",
                table: "DwellingGallery",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingInhabitants_DwellerId",
                schema: "dweller_schema",
                table: "DwellingInhabitants",
                column: "DwellerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DwellingInhabitants_DwellingId",
                schema: "dweller_schema",
                table: "DwellingInhabitants",
                column: "DwellingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberInConversations_ConversationId",
                schema: "dweller_schema",
                table: "MemberInConversations",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberInConversations_DwellingId",
                schema: "dweller_schema",
                table: "MemberInConversations",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_DwellerServiceId",
                schema: "dweller_schema",
                table: "ProvidedServices",
                column: "DwellerServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_DwellingId",
                schema: "dweller_schema",
                table: "ProvidedServices",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_ScopedDwellings_BulletinId",
                schema: "dweller_schema",
                table: "ScopedDwellings",
                column: "BulletinId");

            migrationBuilder.CreateIndex(
                name: "IX_ScopedDwellings_BulletinScopeId",
                schema: "dweller_schema",
                table: "ScopedDwellings",
                column: "BulletinScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScopedDwellings_DwellingId",
                schema: "dweller_schema",
                table: "ScopedDwellings",
                column: "DwellingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedItems",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "BulletinTags",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellerEvents",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellerMessages",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellingGallery",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellingInhabitants",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "MemberInConversations",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "ProvidedServices",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "ScopedDwellings",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellerItems",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellerScopes",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellerConversations",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "DwellerServices",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "BulletinScopes",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "Dwellings",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "Bulletins",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "BulletinPriorities",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "BulletinStatus",
                schema: "dweller_schema");

            migrationBuilder.DropTable(
                name: "Dwellers",
                schema: "dweller_schema");
        }
    }
}
