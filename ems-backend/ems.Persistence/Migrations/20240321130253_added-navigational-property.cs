using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ems.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addednavigationalproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SellAmount",
                table: "EventTarrifWiseSellMaster",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TimezoneId",
                table: "EventDetail",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellAmount",
                table: "EventAgentWiseSellMaster",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EventAgenda",
                columns: table => new
                {
                    EventAgendaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Track = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    AgendaTypeId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Summary = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAgenda", x => x.EventAgendaId);
                    table.ForeignKey(
                        name: "FK_EventAgenda_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDescriptionSection",
                columns: table => new
                {
                    EventDescriptionSectionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(526)", maxLength: 526, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDescriptionSection", x => x.EventDescriptionSectionId);
                    table.ForeignKey(
                        name: "FK_EventDescriptionSection_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventOptionMaster",
                columns: table => new
                {
                    EventOptionMasterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    OptionName = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Track = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    FromDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ToDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    CutOff = table.Column<int>(type: "integer", nullable: true),
                    FreeSell = table.Column<bool>(type: "boolean", nullable: true),
                    MinPax = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MaxPax = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DisableChild = table.Column<bool>(type: "boolean", nullable: true),
                    DisableInfant = table.Column<bool>(type: "boolean", nullable: true),
                    InstantConfirmation = table.Column<bool>(type: "boolean", nullable: true),
                    Requiredhrs = table.Column<bool>(type: "boolean", nullable: true),
                    IsOnlineCheckIn = table.Column<bool>(type: "boolean", nullable: true),
                    IsWaiverFrom = table.Column<bool>(type: "boolean", nullable: true),
                    Minquantity = table.Column<int>(type: "integer", nullable: true),
                    MultiPax = table.Column<int>(type: "integer", nullable: true),
                    Inclusion = table.Column<string>(type: "text", nullable: true),
                    Exclusion = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOptionMaster", x => x.EventOptionMasterId);
                    table.ForeignKey(
                        name: "FK_EventOptionMaster_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterDataMapping",
                columns: table => new
                {
                    MasterDataMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GroupValue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StatusFlag = table.Column<int>(type: "integer", nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDataMapping", x => x.MasterDataMappingId);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Floor = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    SeatingTypeId = table.Column<int>(type: "integer", nullable: false),
                    SeatMapData = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Section_TicketCategory_TicketCategoryId",
                        column: x => x.TicketCategoryId,
                        principalTable: "TicketCategory",
                        principalColumn: "TicketCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    TagTypeId = table.Column<int>(type: "integer", nullable: false),
                    TagKeyword = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    TicketCategoryId = table.Column<int>(type: "integer", nullable: false),
                    TicketAdditionalTypeId = table.Column<int>(type: "integer", nullable: false),
                    RegistrationTimeLimit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TicketIssueTypeId = table.Column<int>(type: "integer", nullable: true),
                    ShowTicketAvailability = table.Column<int>(type: "integer", nullable: true),
                    AllowDuplicateAttendees = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketCategory_TicketCategoryId",
                        column: x => x.TicketCategoryId,
                        principalTable: "TicketCategory",
                        principalColumn: "TicketCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventOptionTimeSlot",
                columns: table => new
                {
                    EventOptionTimeSlotId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventOptionMasterId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    FromDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ToDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOptionTimeSlot", x => x.EventOptionTimeSlotId);
                    table.ForeignKey(
                        name: "FK_EventOptionTimeSlot_EventOptionMaster_EventOptionMasterId",
                        column: x => x.EventOptionMasterId,
                        principalTable: "EventOptionMaster",
                        principalColumn: "EventOptionMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketCategoryPaxTypeMapping",
                columns: table => new
                {
                    TicketCategoryPaxTypeMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketCategoryId = table.Column<int>(type: "integer", nullable: false),
                    PaxTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategoryPaxTypeMapping", x => x.TicketCategoryPaxTypeMappingId);
                    table.ForeignKey(
                        name: "FK_TicketCategoryPaxTypeMapping_MasterDataMapping_PaxTypeId",
                        column: x => x.PaxTypeId,
                        principalTable: "MasterDataMapping",
                        principalColumn: "MasterDataMappingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketCategoryPaxTypeMapping_TicketCategory_TicketCategoryId",
                        column: x => x.TicketCategoryId,
                        principalTable: "TicketCategory",
                        principalColumn: "TicketCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    SeatMapData = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    AvailabilityId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventOptionTagMapping",
                columns: table => new
                {
                    EventOptionTagMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventOptionMasterId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOptionTagMapping", x => x.EventOptionTagMappingId);
                    table.ForeignKey(
                        name: "FK_EventOptionTagMapping_EventOptionMaster_EventOptionMasterId",
                        column: x => x.EventOptionMasterId,
                        principalTable: "EventOptionMaster",
                        principalColumn: "EventOptionMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventOptionTagMapping_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTagMapping",
                columns: table => new
                {
                    EventTagMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTagMapping", x => x.EventTagMappingId);
                    table.ForeignKey(
                        name: "FK_EventTagMapping_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTagMapping_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueEventTimeSlotMapping",
                columns: table => new
                {
                    VenueEventTimeSlotMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventOptionTimeSlotId = table.Column<int>(type: "integer", nullable: false),
                    VenueId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueEventTimeSlotMapping", x => x.VenueEventTimeSlotMappingId);
                    table.ForeignKey(
                        name: "FK_VenueEventTimeSlotMapping_EventOptionTimeSlot_EventOptionTi~",
                        column: x => x.EventOptionTimeSlotId,
                        principalTable: "EventOptionTimeSlot",
                        principalColumn: "EventOptionTimeSlotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenueEventTimeSlotMapping_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategory_CancellationPolicyId",
                table: "TicketCategory",
                column: "CancellationPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategory_EventOptionTimeSlotId",
                table: "TicketCategory",
                column: "EventOptionTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategory_PaymentMethodId",
                table: "TicketCategory",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTarrifWiseSellMaster_EventCostMasterId",
                table: "EventTarrifWiseSellMaster",
                column: "EventCostMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_EventAccessId",
                table: "EventDetail",
                column: "EventAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_EventId",
                table: "EventDetail",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_VenueId",
                table: "EventDetail",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCostMaster_TicketCategoryPaxTypeMappingId",
                table: "EventCostMaster",
                column: "TicketCategoryPaxTypeMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAgentWiseSellMaster_EventCostMasterId",
                table: "EventAgentWiseSellMaster",
                column: "EventCostMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CategoryId",
                table: "Event",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_InventoryId",
                table: "Event",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TypeId",
                table: "Event",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostMasterAuditLog_TicketCategoryPaxTypeMappingId",
                table: "CostMasterAuditLog",
                column: "TicketCategoryPaxTypeMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_CancellationPolicy_CancellationValueTypeId",
                table: "CancellationPolicy",
                column: "CancellationValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAgenda_EventId",
                table: "EventAgenda",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDescriptionSection_EventId",
                table: "EventDescriptionSection",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOptionMaster_EventId",
                table: "EventOptionMaster",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOptionTagMapping_EventOptionMasterId",
                table: "EventOptionTagMapping",
                column: "EventOptionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOptionTagMapping_TagId",
                table: "EventOptionTagMapping",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOptionTimeSlot_EventOptionMasterId",
                table: "EventOptionTimeSlot",
                column: "EventOptionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTagMapping_EventId",
                table: "EventTagMapping",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTagMapping_TagId",
                table: "EventTagMapping",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SectionId",
                table: "Seat",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_TicketCategoryId",
                table: "Section",
                column: "TicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EventId",
                table: "Ticket",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketCategoryId",
                table: "Ticket",
                column: "TicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategoryPaxTypeMapping_PaxTypeId",
                table: "TicketCategoryPaxTypeMapping",
                column: "PaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategoryPaxTypeMapping_TicketCategoryId",
                table: "TicketCategoryPaxTypeMapping",
                column: "TicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueEventTimeSlotMapping_EventOptionTimeSlotId",
                table: "VenueEventTimeSlotMapping",
                column: "EventOptionTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueEventTimeSlotMapping_VenueId",
                table: "VenueEventTimeSlotMapping",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationPolicy_MasterDataMapping_CancellationValueTypeId",
                table: "CancellationPolicy",
                column: "CancellationValueTypeId",
                principalTable: "MasterDataMapping",
                principalColumn: "MasterDataMappingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostMasterAuditLog_TicketCategoryPaxTypeMapping_TicketCateg~",
                table: "CostMasterAuditLog",
                column: "TicketCategoryPaxTypeMappingId",
                principalTable: "TicketCategoryPaxTypeMapping",
                principalColumn: "TicketCategoryPaxTypeMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_MasterDataMapping_CategoryId",
                table: "Event",
                column: "CategoryId",
                principalTable: "MasterDataMapping",
                principalColumn: "MasterDataMappingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_MasterDataMapping_InventoryId",
                table: "Event",
                column: "InventoryId",
                principalTable: "MasterDataMapping",
                principalColumn: "MasterDataMappingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_MasterDataMapping_TypeId",
                table: "Event",
                column: "TypeId",
                principalTable: "MasterDataMapping",
                principalColumn: "MasterDataMappingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAgentWiseSellMaster_EventCostMaster_EventCostMasterId",
                table: "EventAgentWiseSellMaster",
                column: "EventCostMasterId",
                principalTable: "EventCostMaster",
                principalColumn: "EventCostMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCostMaster_TicketCategoryPaxTypeMapping_TicketCategory~",
                table: "EventCostMaster",
                column: "TicketCategoryPaxTypeMappingId",
                principalTable: "TicketCategoryPaxTypeMapping",
                principalColumn: "TicketCategoryPaxTypeMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventDetail_Event_EventId",
                table: "EventDetail",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventDetail_MasterDataMapping_EventAccessId",
                table: "EventDetail",
                column: "EventAccessId",
                principalTable: "MasterDataMapping",
                principalColumn: "MasterDataMappingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventDetail_Venue_VenueId",
                table: "EventDetail",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTarrifWiseSellMaster_EventCostMaster_EventCostMasterId",
                table: "EventTarrifWiseSellMaster",
                column: "EventCostMasterId",
                principalTable: "EventCostMaster",
                principalColumn: "EventCostMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategory_CancellationPolicy_CancellationPolicyId",
                table: "TicketCategory",
                column: "CancellationPolicyId",
                principalTable: "CancellationPolicy",
                principalColumn: "CancellationPolicyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategory_EventOptionTimeSlot_EventOptionTimeSlotId",
                table: "TicketCategory",
                column: "EventOptionTimeSlotId",
                principalTable: "EventOptionTimeSlot",
                principalColumn: "EventOptionTimeSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategory_MasterDataMapping_PaymentMethodId",
                table: "TicketCategory",
                column: "PaymentMethodId",
                principalTable: "MasterDataMapping",
                principalColumn: "MasterDataMappingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancellationPolicy_MasterDataMapping_CancellationValueTypeId",
                table: "CancellationPolicy");

            migrationBuilder.DropForeignKey(
                name: "FK_CostMasterAuditLog_TicketCategoryPaxTypeMapping_TicketCateg~",
                table: "CostMasterAuditLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_MasterDataMapping_CategoryId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_MasterDataMapping_InventoryId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_MasterDataMapping_TypeId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAgentWiseSellMaster_EventCostMaster_EventCostMasterId",
                table: "EventAgentWiseSellMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCostMaster_TicketCategoryPaxTypeMapping_TicketCategory~",
                table: "EventCostMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_EventDetail_Event_EventId",
                table: "EventDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_EventDetail_MasterDataMapping_EventAccessId",
                table: "EventDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_EventDetail_Venue_VenueId",
                table: "EventDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTarrifWiseSellMaster_EventCostMaster_EventCostMasterId",
                table: "EventTarrifWiseSellMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategory_CancellationPolicy_CancellationPolicyId",
                table: "TicketCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategory_EventOptionTimeSlot_EventOptionTimeSlotId",
                table: "TicketCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategory_MasterDataMapping_PaymentMethodId",
                table: "TicketCategory");

            migrationBuilder.DropTable(
                name: "EventAgenda");

            migrationBuilder.DropTable(
                name: "EventDescriptionSection");

            migrationBuilder.DropTable(
                name: "EventOptionTagMapping");

            migrationBuilder.DropTable(
                name: "EventTagMapping");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketCategoryPaxTypeMapping");

            migrationBuilder.DropTable(
                name: "VenueEventTimeSlotMapping");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "MasterDataMapping");

            migrationBuilder.DropTable(
                name: "EventOptionTimeSlot");

            migrationBuilder.DropTable(
                name: "EventOptionMaster");

            migrationBuilder.DropIndex(
                name: "IX_TicketCategory_CancellationPolicyId",
                table: "TicketCategory");

            migrationBuilder.DropIndex(
                name: "IX_TicketCategory_EventOptionTimeSlotId",
                table: "TicketCategory");

            migrationBuilder.DropIndex(
                name: "IX_TicketCategory_PaymentMethodId",
                table: "TicketCategory");

            migrationBuilder.DropIndex(
                name: "IX_EventTarrifWiseSellMaster_EventCostMasterId",
                table: "EventTarrifWiseSellMaster");

            migrationBuilder.DropIndex(
                name: "IX_EventDetail_EventAccessId",
                table: "EventDetail");

            migrationBuilder.DropIndex(
                name: "IX_EventDetail_EventId",
                table: "EventDetail");

            migrationBuilder.DropIndex(
                name: "IX_EventDetail_VenueId",
                table: "EventDetail");

            migrationBuilder.DropIndex(
                name: "IX_EventCostMaster_TicketCategoryPaxTypeMappingId",
                table: "EventCostMaster");

            migrationBuilder.DropIndex(
                name: "IX_EventAgentWiseSellMaster_EventCostMasterId",
                table: "EventAgentWiseSellMaster");

            migrationBuilder.DropIndex(
                name: "IX_Event_CategoryId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_InventoryId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_TypeId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_CostMasterAuditLog_TicketCategoryPaxTypeMappingId",
                table: "CostMasterAuditLog");

            migrationBuilder.DropIndex(
                name: "IX_CancellationPolicy_CancellationValueTypeId",
                table: "CancellationPolicy");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellAmount",
                table: "EventTarrifWiseSellMaster",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "TimezoneId",
                table: "EventDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellAmount",
                table: "EventAgentWiseSellMaster",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
