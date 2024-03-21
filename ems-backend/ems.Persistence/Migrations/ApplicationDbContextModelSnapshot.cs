﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ems.Persistence.Configuration;

#nullable disable

namespace ems.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ems.Common.Entities.APILogs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Exception")
                        .HasColumnType("text");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QueryString")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("RequestAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RequestBody")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("ResponseAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ResponseBody")
                        .HasColumnType("text");

                    b.Property<int>("StatusCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("APILogs", "Logging");
                });

            modelBuilder.Entity("ems.Common.Entities.CancellationPolicy", b =>
                {
                    b.Property<int>("CancellationPolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CancellationPolicyId"));

                    b.Property<string>("CancellationName")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<decimal>("CancellationValue")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("CancellationValueTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int?>("DisplaySortOrder")
                        .HasColumnType("integer");

                    b.Property<int?>("FromHour")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRefundable")
                        .HasColumnType("boolean");

                    b.Property<string>("RefundPolicy")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("ToHour")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CancellationPolicyId");

                    b.ToTable("CancellationPolicy");
                });

            modelBuilder.Entity("ems.Common.Entities.CostMasterAuditLog", b =>
                {
                    b.Property<int>("CostMasterAuditLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CostMasterAuditLogId"));

                    b.Property<decimal?>("Cost")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IPAddress")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal?>("MinimumSell")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal?>("RackRate")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("TicketCategoryPaxTypeMappingId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CostMasterAuditLogId");

                    b.ToTable("CostMasterAuditLog");
                });

            modelBuilder.Entity("ems.Common.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<DateTime>("FromDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("SubTitle")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ToDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("ems.Common.Entities.EventAgentWiseSellMaster", b =>
                {
                    b.Property<int>("EventAgentWiseSellMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventAgentWiseSellMasterId"));

                    b.Property<int?>("AgentId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EventCostMasterId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("MarkupAmount")
                        .HasPrecision(18, 7)
                        .HasColumnType("numeric(18,7)");

                    b.Property<int?>("MarkupTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("SellAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EventAgentWiseSellMasterId");

                    b.ToTable("EventAgentWiseSellMaster");
                });

            modelBuilder.Entity("ems.Common.Entities.EventCostMaster", b =>
                {
                    b.Property<int>("EventCostMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventCostMasterId"));

                    b.Property<decimal>("Cost")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("MinimumSell")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("RackRate")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int?>("TicketCategoryPaxTypeMappingId")
                        .HasColumnType("integer");

                    b.HasKey("EventCostMasterId");

                    b.ToTable("EventCostMaster");
                });

            modelBuilder.Entity("ems.Common.Entities.EventDetail", b =>
                {
                    b.Property<int>("EventDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventDetailId"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DefaultImageUrl")
                        .HasMaxLength(516)
                        .HasColumnType("character varying(516)");

                    b.Property<int>("EventAccessId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Latitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("numeric(9,6)");

                    b.Property<decimal>("Longitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("numeric(9,6)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TimezoneId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("EventDetailId");

                    b.ToTable("EventDetail");
                });

            modelBuilder.Entity("ems.Common.Entities.EventMedia", b =>
                {
                    b.Property<int>("EventMediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventMediaId"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<int?>("DisplaySortOrder")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(526)
                        .HasColumnType("character varying(526)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Url")
                        .HasMaxLength(516)
                        .HasColumnType("character varying(516)");

                    b.HasKey("EventMediaId");

                    b.HasIndex("EventId");

                    b.ToTable("EventMedia");
                });

            modelBuilder.Entity("ems.Common.Entities.EventSellMasterAuditLog", b =>
                {
                    b.Property<int>("EventSellMasterAuditLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventSellMasterAuditLogId"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EventCostMasterId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("MarkupAmount")
                        .HasPrecision(18, 7)
                        .HasColumnType("numeric(18,7)");

                    b.Property<int?>("MarkupTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ReferenceId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("SellAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EventSellMasterAuditLogId");

                    b.ToTable("EventSellMasterAuditLog");
                });

            modelBuilder.Entity("ems.Common.Entities.EventTarrifWiseSellMaster", b =>
                {
                    b.Property<int>("EventTarrifWiseSellMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventTarrifWiseSellMasterId"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EventCostMasterId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("MarkupAmount")
                        .HasPrecision(18, 7)
                        .HasColumnType("numeric(18,7)");

                    b.Property<int?>("MarkupTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("SellAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("TarrifId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EventTarrifWiseSellMasterId");

                    b.ToTable("EventTarrifWiseSellMaster");
                });

            modelBuilder.Entity("ems.Common.Entities.FilePath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("FilePath");
                });

            modelBuilder.Entity("ems.Common.Entities.FormatConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FormatConfiguration");
                });

            modelBuilder.Entity("ems.Common.Entities.JwtRefreshToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId");

                    b.ToTable("UserJwtRefreshToken");
                });

            modelBuilder.Entity("ems.Common.Entities.MailAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AttachmentPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MailId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MailId");

                    b.ToTable("MailAttachment");
                });

            modelBuilder.Entity("ems.Common.Entities.MailMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CC")
                        .HasColumnType("text");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("FromMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MessageBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ToMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("MailMaster");
                });

            modelBuilder.Entity("ems.Common.Entities.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateOnly?>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("Village")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("ems.Common.Entities.ServiceConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MailId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Port")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ServiceConfiguration");
                });

            modelBuilder.Entity("ems.Common.Entities.TicketCategory", b =>
                {
                    b.Property<int>("TicketCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TicketCategoryId"));

                    b.Property<int>("CancellationPolicyId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EventOptionTimeSlotId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("IsAmountOff")
                        .HasPrecision(18, 3)
                        .HasColumnType("numeric(18,3)");

                    b.Property<int?>("IsFeatured")
                        .HasColumnType("integer");

                    b.Property<int?>("IsPdfTicket")
                        .HasColumnType("integer");

                    b.Property<decimal?>("IsPercentageOff")
                        .HasPrecision(18, 3)
                        .HasColumnType("numeric(18,3)");

                    b.Property<bool?>("IsRefundable")
                        .HasColumnType("boolean");

                    b.Property<int?>("MaxQuantity")
                        .HasColumnType("integer");

                    b.Property<int?>("MinQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal?>("QuantitySold")
                        .HasPrecision(18, 3)
                        .HasColumnType("numeric(18,3)");

                    b.Property<string>("SeatmapDataColor")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("VisibilityTypeId")
                        .HasColumnType("integer");

                    b.HasKey("TicketCategoryId");

                    b.ToTable("TicketCategory");
                });

            modelBuilder.Entity("ems.Common.Entities.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VenueId"));

                    b.Property<string>("Address")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("Latitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("numeric(9,6)");

                    b.Property<string>("Longitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("VenueId");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("ems.Common.Entities.EventMedia", b =>
                {
                    b.HasOne("ems.Common.Entities.Event", "Event")
                        .WithMany("EventFileList")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ems.Common.Entities.JwtRefreshToken", b =>
                {
                    b.HasOne("ems.Common.Entities.Registration", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("ems.Common.Entities.JwtRefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ems.Common.Entities.MailAttachment", b =>
                {
                    b.HasOne("ems.Common.Entities.MailMaster", "MailMaster")
                        .WithMany("Attachments")
                        .HasForeignKey("MailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MailMaster");
                });

            modelBuilder.Entity("ems.Common.Entities.MailMaster", b =>
                {
                    b.HasOne("ems.Common.Entities.Event", "Rayna")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.Navigation("Rayna");
                });

            modelBuilder.Entity("ems.Common.Entities.Event", b =>
                {
                    b.Navigation("EventFileList");
                });

            modelBuilder.Entity("ems.Common.Entities.MailMaster", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("ems.Common.Entities.Registration", b =>
                {
                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}
