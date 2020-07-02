using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentSite.WebAPI.Migrations
{
    public partial class initExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineOfTransport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineOfTransport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfAttractiveObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfAttractiveObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfResidentialBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfResidentialBuilding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    NumberOfBeds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttractiveObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    TypeOfAttractiveObjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractiveObjects", x => x.Id);
                    table.ForeignKey(
                        name: "fk_TypeOfAttractiveObjectId",
                        column: x => x.TypeOfAttractiveObjectId,
                        principalTable: "TypeOfAttractiveObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Floor = table.Column<int>(nullable: true),
                    NubmerOfFloors = table.Column<int>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    NumberOfRooms = table.Column<int>(nullable: true),
                    ArmoredDoor = table.Column<bool>(nullable: true),
                    TypeOfHeating = table.Column<string>(maxLength: 500, nullable: true),
                    Area = table.Column<string>(maxLength: 200, nullable: true),
                    NewlyBuilt = table.Column<bool>(nullable: true),
                    DateOfRenewal = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfPublication = table.Column<DateTime>(type: "datetime", nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    TypeOfResidentialBuildingId = table.Column<int>(nullable: true),
                    Rented = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialBuilding", x => x.Id);
                    table.ForeignKey(
                        name: "fk_CityRBId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_TypeOfResidentialBuildingIdId",
                        column: x => x.TypeOfResidentialBuildingId,
                        principalTable: "TypeOfResidentialBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Picture = table.Column<byte[]>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    ArmoredDoor = table.Column<bool>(nullable: true),
                    TypeOfHeating = table.Column<string>(maxLength: 500, nullable: true),
                    Area = table.Column<string>(maxLength: 200, nullable: true),
                    NewlyBuilt = table.Column<bool>(nullable: true),
                    DateOfRenewal = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfPublication = table.Column<DateTime>(type: "datetime", nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    TypeOfRoomId = table.Column<int>(nullable: true),
                    Rented = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "fk_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_TypeOfRoomId",
                        column: x => x.TypeOfRoomId,
                        principalTable: "TypeOfRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 500, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    TypeOfUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "fk_TypeOfUserId",
                        column: x => x.TypeOfUserId,
                        principalTable: "TypeOfUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineOfTransport_ResidentialBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentialBuildingId = table.Column<int>(nullable: true),
                    LineOfTransportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineOfTransport_ResidentialBuilding", x => x.Id);
                    table.ForeignKey(
                        name: "fk_LineOfTransportRBId",
                        column: x => x.LineOfTransportId,
                        principalTable: "LineOfTransport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ResidentialBuildingId",
                        column: x => x.ResidentialBuildingId,
                        principalTable: "ResidentialBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttractiveObjects_Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(nullable: true),
                    AttractiveObjectsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractiveObjects_Room", x => x.Id);
                    table.ForeignKey(
                        name: "fk_AttractiveObjectsId",
                        column: x => x.AttractiveObjectsId,
                        principalTable: "AttractiveObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineOfTransport_Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(nullable: true),
                    LineOfTransportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineOfTransport_Room", x => x.Id);
                    table.ForeignKey(
                        name: "fk_LineOfTransportId",
                        column: x => x.LineOfTransportId,
                        principalTable: "LineOfTransport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Room_LoTId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rented_ResidentialBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginRentalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndRentalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    ResidentialBuildingId = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rented_ResidentialBuilding", x => x.Id);
                    table.ForeignKey(
                        name: "fk_ResidentialBuilding_UserId",
                        column: x => x.ResidentialBuildingId,
                        principalTable: "ResidentialBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rented_Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginRentalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndRentalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    RoomId = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rented_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Room_RentedId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_User_RoomsId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialBuildingReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(nullable: true),
                    ResidentialBuildingId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialBuildingReview", x => x.Id);
                    table.ForeignKey(
                        name: "fk_ResidentialBuildingReviewId",
                        column: x => x.ResidentialBuildingId,
                        principalTable: "ResidentialBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_UserReviewId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(nullable: true),
                    RoomId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReview", x => x.Id);
                    table.ForeignKey(
                        name: "fk_RoomReviewId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_RoomUserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Blagaj" },
                    { 2, "Mostar" },
                    { 3, "Stolac" },
                    { 4, "Pocitelj" }
                });

            migrationBuilder.InsertData(
                table: "LineOfTransport",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "2" },
                    { 4, "13" },
                    { 5, "6" },
                    { 2, "11" },
                    { 1, "10" },
                    { 3, "12" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfResidentialBuilding",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Home" },
                    { 2, "Flat" },
                    { 3, "Cottage" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfRoom",
                columns: new[] { "Id", "Name", "NumberOfBeds" },
                values: new object[,]
                {
                    { 1, "Jednokrevetna", 1 },
                    { 2, "Dvokrevetna", 2 },
                    { 3, "Trokrevetna", 3 }
                });

            migrationBuilder.InsertData(
                table: "TypeOfUser",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Status", "TypeOfUserId", "Username" },
                values: new object[,]
                {
                    { 1, "user@gmail.com", "Desktop name", "Desktop last name", "+UyhM3uH6nHMlKYmOJtV8p2h7jI=", "mIdmCJ2LhhfYhGjOu9qQOg==", "0322 - 564 -456", true, 1, "desktop" },
                    { 2, "mobile@gmail.com", "Merima", "Ceranic", "wXQNmcZDJVPRwsyJar2OEjblDZ0=", "eUfwvG+IuFlNvZNzbdoNbQ==", "0322 - 564 -456", true, 2, "mobile" },
                    { 3, "jimm@gmail.com", "Jimm", "Tommy", "vPL5GLsg9wv8XrbTiKWdlGuWHN8=", "QqfU3qsNvpnz/JDog2GRSQ==", "0322 - 564 -456", true, 2, "jimm" },
                    { 4, "ammy@gmail.com", "Ammy", "Tomphson", "97Di1lbVO0sUysl2Zh4BVgcktPA=", "LmXEeohjgWIJdaDfyyyhMQ==", "0322 - 564 -456", true, 2, "ammy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttractiveObjects_TypeOfAttractiveObjectId",
                table: "AttractiveObjects",
                column: "TypeOfAttractiveObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractiveObjects_Room_AttractiveObjectsId",
                table: "AttractiveObjects_Room",
                column: "AttractiveObjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractiveObjects_Room_RoomId",
                table: "AttractiveObjects_Room",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LineOfTransport_ResidentialBuilding_LineOfTransportId",
                table: "LineOfTransport_ResidentialBuilding",
                column: "LineOfTransportId");

            migrationBuilder.CreateIndex(
                name: "IX_LineOfTransport_ResidentialBuilding_ResidentialBuildingId",
                table: "LineOfTransport_ResidentialBuilding",
                column: "ResidentialBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_LineOfTransport_Room_LineOfTransportId",
                table: "LineOfTransport_Room",
                column: "LineOfTransportId");

            migrationBuilder.CreateIndex(
                name: "IX_LineOfTransport_Room_RoomId",
                table: "LineOfTransport_Room",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rented_ResidentialBuilding_ResidentialBuildingId",
                table: "Rented_ResidentialBuilding",
                column: "ResidentialBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rented_ResidentialBuilding_UserId",
                table: "Rented_ResidentialBuilding",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rented_Rooms_RoomId",
                table: "Rented_Rooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rented_Rooms_UserId",
                table: "Rented_Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialBuilding_CityId",
                table: "ResidentialBuilding",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialBuilding_TypeOfResidentialBuildingId",
                table: "ResidentialBuilding",
                column: "TypeOfResidentialBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialBuildingReview_ResidentialBuildingId",
                table: "ResidentialBuildingReview",
                column: "ResidentialBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialBuildingReview_UserId",
                table: "ResidentialBuildingReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_CityId",
                table: "Room",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_TypeOfRoomId",
                table: "Room",
                column: "TypeOfRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReview_RoomId",
                table: "RoomReview",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReview_UserId",
                table: "RoomReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeOfUserId",
                table: "User",
                column: "TypeOfUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractiveObjects_Room");

            migrationBuilder.DropTable(
                name: "LineOfTransport_ResidentialBuilding");

            migrationBuilder.DropTable(
                name: "LineOfTransport_Room");

            migrationBuilder.DropTable(
                name: "Rented_ResidentialBuilding");

            migrationBuilder.DropTable(
                name: "Rented_Rooms");

            migrationBuilder.DropTable(
                name: "ResidentialBuildingReview");

            migrationBuilder.DropTable(
                name: "RoomReview");

            migrationBuilder.DropTable(
                name: "AttractiveObjects");

            migrationBuilder.DropTable(
                name: "LineOfTransport");

            migrationBuilder.DropTable(
                name: "ResidentialBuilding");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TypeOfAttractiveObject");

            migrationBuilder.DropTable(
                name: "TypeOfResidentialBuilding");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "TypeOfRoom");

            migrationBuilder.DropTable(
                name: "TypeOfUser");
        }
    }
}
