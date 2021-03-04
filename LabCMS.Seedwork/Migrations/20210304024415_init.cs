using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LabCMS.Seedwork.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentHourlyRates",
                columns: table => new
                {
                    EquipmentNo = table.Column<string>(type: "text", nullable: false),
                    EquipmentName = table.Column<string>(type: "text", nullable: false),
                    MachineCategory = table.Column<string>(type: "text", nullable: false),
                    HourlyRate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentHourlyRates", x => x.EquipmentNo);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordMD5MD5 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    No = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameInFIN = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "TestFields",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestFields", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    No = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "MachineDownRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    EquipmentNo = table.Column<string>(type: "text", nullable: false),
                    MachineDownDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MachineRepairedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineDownRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineDownRecords_People_UserId",
                        column: x => x.UserId,
                        principalTable: "People",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUsageRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User = table.Column<string>(type: "text", nullable: false),
                    TestNo = table.Column<string>(type: "text", nullable: false),
                    EquipmentNo = table.Column<string>(type: "text", nullable: false),
                    TestType = table.Column<string>(type: "text", nullable: true),
                    ProjectNo = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<long>(type: "bigint", nullable: false),
                    EndTime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUsageRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageRecords_EquipmentHourlyRates_EquipmentNo",
                        column: x => x.EquipmentNo,
                        principalTable: "EquipmentHourlyRates",
                        principalColumn: "EquipmentNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentUsageRecords_Projects_ProjectNo",
                        column: x => x.ProjectNo,
                        principalTable: "Projects",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixtureDomainRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AuthLevel = table.Column<int>(type: "integer", nullable: false),
                    ResponseTestFieldName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureDomainRoles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_FixtureDomainRoles_People_UserId",
                        column: x => x.UserId,
                        principalTable: "People",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixtureDomainRoles_TestFields_ResponseTestFieldName",
                        column: x => x.ResponseTestFieldName,
                        principalTable: "TestFields",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    No = table.Column<int>(type: "integer", nullable: false),
                    ProjectShortName = table.Column<string>(type: "text", nullable: false),
                    TestFieldName = table.Column<string>(type: "text", nullable: false),
                    SetIndex = table.Column<string>(type: "text", nullable: false),
                    StorageInformation = table.Column<string>(type: "text", nullable: false),
                    InFixtureRoom = table.Column<bool>(type: "boolean", nullable: false),
                    ShelfNo = table.Column<int>(type: "integer", nullable: false),
                    FloorNo = table.Column<int>(type: "integer", nullable: false),
                    AssetNo = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.No);
                    table.ForeignKey(
                        name: "FK_Fixtures_TestFields_TestFieldName",
                        column: x => x.TestFieldName,
                        principalTable: "TestFields",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixtureCheckoutRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantUserId = table.Column<string>(type: "text", nullable: true),
                    FixtureNo = table.Column<int>(type: "integer", nullable: false),
                    CheckoutDate = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverCompany = table.Column<string>(type: "text", nullable: false),
                    Receiver = table.Column<string>(type: "text", nullable: false),
                    PlanndReturnDate = table.Column<long>(type: "bigint", nullable: false),
                    TestRoomApproverUserId = table.Column<string>(type: "text", nullable: true),
                    FixtureRoomApproverId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TimeStamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureCheckoutRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixtureCheckoutRecords_FixtureDomainRoles_ApplicantUserId",
                        column: x => x.ApplicantUserId,
                        principalTable: "FixtureDomainRoles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixtureCheckoutRecords_FixtureDomainRoles_FixtureRoomApprov~",
                        column: x => x.FixtureRoomApproverId,
                        principalTable: "FixtureDomainRoles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixtureCheckoutRecords_FixtureDomainRoles_TestRoomApproverU~",
                        column: x => x.TestRoomApproverUserId,
                        principalTable: "FixtureDomainRoles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixtureCheckoutRecords_Fixtures_FixtureNo",
                        column: x => x.FixtureNo,
                        principalTable: "Fixtures",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixtureCheckinRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckoutRecordId = table.Column<int>(type: "integer", nullable: false),
                    ApplicantUserId = table.Column<string>(type: "text", nullable: true),
                    FixtureNo = table.Column<int>(type: "integer", nullable: false),
                    CheckinDate = table.Column<long>(type: "bigint", nullable: false),
                    FixtureRoomApproverId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TimeStamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureCheckinRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixtureCheckinRecords_FixtureCheckoutRecords_CheckoutRecord~",
                        column: x => x.CheckoutRecordId,
                        principalTable: "FixtureCheckoutRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixtureCheckinRecords_FixtureDomainRoles_ApplicantUserId",
                        column: x => x.ApplicantUserId,
                        principalTable: "FixtureDomainRoles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixtureCheckinRecords_FixtureDomainRoles_FixtureRoomApprove~",
                        column: x => x.FixtureRoomApproverId,
                        principalTable: "FixtureDomainRoles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixtureCheckinRecords_Fixtures_FixtureNo",
                        column: x => x.FixtureNo,
                        principalTable: "Fixtures",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "No", "Comment" },
                values: new object[,]
                {
                    { "1.0.0", "Initial Version" },
                    { "1.0.1", "Include source code in nuget package" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageRecords_EquipmentNo",
                table: "EquipmentUsageRecords",
                column: "EquipmentNo");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageRecords_ProjectNo",
                table: "EquipmentUsageRecords",
                column: "ProjectNo");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsageRecords_StartTime",
                table: "EquipmentUsageRecords",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckinRecords_ApplicantUserId",
                table: "FixtureCheckinRecords",
                column: "ApplicantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckinRecords_CheckoutRecordId",
                table: "FixtureCheckinRecords",
                column: "CheckoutRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckinRecords_FixtureNo",
                table: "FixtureCheckinRecords",
                column: "FixtureNo");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckinRecords_FixtureRoomApproverId",
                table: "FixtureCheckinRecords",
                column: "FixtureRoomApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckoutRecords_ApplicantUserId",
                table: "FixtureCheckoutRecords",
                column: "ApplicantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckoutRecords_FixtureNo",
                table: "FixtureCheckoutRecords",
                column: "FixtureNo");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckoutRecords_FixtureRoomApproverId",
                table: "FixtureCheckoutRecords",
                column: "FixtureRoomApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureCheckoutRecords_TestRoomApproverUserId",
                table: "FixtureCheckoutRecords",
                column: "TestRoomApproverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureDomainRoles_ResponseTestFieldName",
                table: "FixtureDomainRoles",
                column: "ResponseTestFieldName");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TestFieldName",
                table: "Fixtures",
                column: "TestFieldName");

            migrationBuilder.CreateIndex(
                name: "IX_MachineDownRecords_UserId",
                table: "MachineDownRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentUsageRecords");

            migrationBuilder.DropTable(
                name: "FixtureCheckinRecords");

            migrationBuilder.DropTable(
                name: "MachineDownRecords");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "EquipmentHourlyRates");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "FixtureCheckoutRecords");

            migrationBuilder.DropTable(
                name: "FixtureDomainRoles");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "TestFields");
        }
    }
}
