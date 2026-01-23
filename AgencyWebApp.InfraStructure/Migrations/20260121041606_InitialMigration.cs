using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgencyWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirPlaneName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FlightNumber = table.Column<int>(type: "int", nullable: false),
                    FromCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    HomeLatitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    HomeLongitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    StartLatitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    StartLongitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Bookings_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourPoint_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirPlaneName", "ArrivalTime", "DepartureTime", "FlightNumber", "FromCity", "FromLatitude", "FromLongitude", "Price", "Status", "ToCity", "ToLatitude", "ToLongitude" },
                values: new object[,]
                {
                    { 1, "Boeing 737-800", new DateTime(2026, 5, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 101, "Moscow (DME)", 55.4103m, 37.9024m, 250.00m, "Scheduled", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 2, "Airbus A320", new DateTime(2026, 5, 12, 16, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), 202, "Istanbul (IST)", 41.2753m, 28.7519m, 320.00m, "Scheduled", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 3, "Boeing 737-300", new DateTime(2026, 5, 15, 8, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 303, "Dushanbe (DYU)", 38.5433m, 68.8249m, 45.00m, "Active", "Khujand (LBD)", 40.2152m, 69.6944m },
                    { 4, "Boeing 737-800", new DateTime(2026, 5, 19, 2, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), 404, "Dubai (DXB)", 25.2532m, 55.3657m, 380.00m, "Scheduled", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 5, "Airbus A321", new DateTime(2026, 5, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 505, "Tashkent (TAS)", 41.2575m, 69.2817m, 110.00m, "Active", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 6, "Boeing 737-800", new DateTime(2026, 5, 22, 11, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), 606, "Almaty (ALA)", 43.3520m, 77.0115m, 140.00m, "Scheduled", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 7, "Boeing 787 Dreamliner", new DateTime(2026, 5, 26, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), 707, "Frankfurt (FRA)", 50.0333m, 8.5705m, 650.00m, "Delayed", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 8, "Airbus A320", new DateTime(2026, 5, 28, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 28, 4, 0, 0, 0, DateTimeKind.Unspecified), 808, "Delhi (DEL)", 28.5562m, 77.1000m, 290.00m, "Scheduled", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 9, "Boeing 737-800", new DateTime(2026, 6, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 909, "Munich (MUC)", 48.3537m, 11.7750m, 580.00m, "Active", "Dushanbe (DYU)", 38.5433m, 68.8249m },
                    { 10, "Embraer 190", new DateTime(2026, 6, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 110, "Urumqi (URC)", 43.9071m, 87.4742m, 420.00m, "Scheduled", "Dushanbe (DYU)", 38.5433m, 68.8249m }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Country", "Description", "Latitude", "Longitude", "Name", "PhotoUrl", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "14 Rudaki Ave", "Dushanbe", "Tajikistan", "A luxury 5-star hotel in the heart of the capital with traditional Tajik architecture.", 38.5737m, 68.7938m, "Dushanbe Serena Hotel", "https://images.unsplash.com/photo-1566073771259-6a8506099945?auto=format&fit=crop&w=800", 160.00m, 5 },
                    { 2, "26/1 Ismoili Somoni Ave", "Dushanbe", "Tajikistan", "Modern lakeside hotel perfect for business and leisure travelers.", 38.5858m, 68.7725m, "Hyatt Regency Dushanbe", "https://images.unsplash.com/photo-1551882547-ff43c63e1c04?auto=format&fit=crop&w=800", 185.00m, 5 },
                    { 3, "63 Nisor Muhammad St", "Dushanbe", "Tajikistan", "Boutique hotel featuring Tajik national fabrics and a beautiful garden.", 38.5601m, 68.8120m, "Atlas Hotel", "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?auto=format&fit=crop&w=800", 85.00m, 4 },
                    { 4, "22 Kamoli Khujandi St", "Khujand", "Tajikistan", "The best apartments in Khujand city center with a river view.", 40.2825m, 69.6221m, "Armon Aparthotel", "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?auto=format&fit=crop&w=800", 75.00m, 4 },
                    { 5, "15 Lenin St", "Khujand", "Tajikistan", "Classic hotel located near the historical Panjshanbe Bazaar.", 40.2790m, 69.6300m, "Sugdiyon Hotel", "https://images.unsplash.com/photo-1561501900-3701fa6a0864?auto=format&fit=crop&w=800", 55.00m, 3 },
                    { 6, "Kalaikhumb Village", "Darvoz", "Tajikistan", "The gateway to the Pamirs. Luxury comfort in a remote mountain setting.", 38.4571m, 70.7831m, "Karon Palace", "https://images.unsplash.com/photo-1445019980597-93fa8acb246c?auto=format&fit=crop&w=800", 95.00m, 5 },
                    { 7, "52 Lenin St", "Khorog", "Tajikistan", "Famous Pamiri guesthouse known for its hospitality and traditional food.", 37.4896m, 71.5511m, "Lal Hotel", "https://images.unsplash.com/photo-1582719478250-c89cae4df85b?auto=format&fit=crop&w=800", 65.00m, 4 },
                    { 8, "10 Vahdat Ave", "Bokhtar", "Tajikistan", "A comfortable central hotel for travelers exploring the Khatlon region.", 37.8364m, 68.7802m, "Grand Hotel Bokhtar", "https://images.unsplash.com/photo-1495365200479-c4ed1d35e1aa?auto=format&fit=crop&w=800", 60.00m, 3 },
                    { 9, "3 Loik Sherali St", "Dushanbe", "Tajikistan", "Cozy and quiet boutique hotel located in a premium residential area.", 38.5900m, 68.7850m, "Seven In Boutique", "https://images.unsplash.com/photo-1571896349842-33c89424de2d?auto=format&fit=crop&w=800", 90.00m, 4 },
                    { 10, "48 Ayni St", "Dushanbe", "Tajikistan", "Premium hospitality close to the airport and Dushanbe city center.", 38.5672m, 68.8051m, "Hilton Dushanbe", "https://images.unsplash.com/photo-1590490360182-c33d57733427?auto=format&fit=crop&w=800", 145.00m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "HomeLatitude", "HomeLongitude", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "alisher@mail.tj", "Алишер Саидов", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 2, "madina@gmail.com", "Мадина Каримова", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 3, "bakhtier@list.ru", "Бахтиёр Назаров", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 4, "nigina@yandex.ru", "Нигина Рахимова", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 5, "parviz@outlook.com", "Парвиз Ходжаев", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 6, "zarina@mail.tj", "Зарина Олимова", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 7, "rustam@google.com", "Рустам Эшонов", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 8, "sitora@inbox.ru", "Ситора Джумаева", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 9, "firdavs@rambler.ru", "Фирдавс Гафуров", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 },
                    { 10, "lola@tj-travel.tj", "Лола Шарипова", null, null, "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje", 1 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "FlightId", "HotelId", "Status", "TourId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2026, 1, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), null, 1, true, null, 2 },
                    { 3, new DateTime(2026, 1, 14, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, null, false, null, 3 },
                    { 5, new DateTime(2026, 1, 16, 16, 45, 0, 0, DateTimeKind.Unspecified), null, 2, true, null, 5 },
                    { 8, new DateTime(2026, 1, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "FlightId", "HotelId", "Text", "TourId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Dushanbe Serena Hotel is the best place to stay. Very professional staff.", null, 2 },
                    { 3, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "The flight from Moscow to Dushanbe was on time and very comfortable.", null, 3 },
                    { 5, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Great service at Hyatt Regency. The breakfast selection was amazing.", null, 5 },
                    { 8, new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "Somon Air flight to Khujand was quick and smooth. No complaints.", null, 8 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "Duration", "HotelId", "PhotoUrl", "Price", "Rating", "Region", "StartLatitude", "StartLongitude", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "A legendary road trip through the high-altitude Pamir mountains and Khorog city.", 7, 7, "https://images.unsplash.com/photo-1581414441460-7058866e409b?auto=format&fit=crop&w=800", 550.00m, 5, "GBAO", 38.5737m, 68.7938m, true, "Pamir Highway Adventure" },
                    { 2, "Explore the ruins of Sarazm and the stunning Seven Lakes (Haft Kul).", 3, 4, "https://images.unsplash.com/photo-1541829070764-84a7d30dee6b?auto=format&fit=crop&w=800", 120.00m, 5, "Sughd", 39.4969m, 67.6103m, true, "Ancient Panjakent & Lakes" },
                    { 3, "Visit the National Museum, Ismoili Somoni monument, and local bazaars.", 2, 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/National_Museum_of_Tajikistan.jpg/800px-National_Museum_of_Tajikistan.jpg", 85.00m, 4, "Dushanbe", 38.5858m, 68.7725m, true, "Dushanbe City Weekend" },
                    { 4, "Visit the lake of Alexander the Great and the famous 'Fan Niagara' waterfall.", 3, 2, "https://images.unsplash.com/photo-1563290328-9710279603e8?auto=format&fit=crop&w=800", 150.00m, 5, "Fann Mountains", 39.0833m, 68.3667m, true, "Iskanderkul Lake Escape" },
                    { 5, "Relax at the famous Soviet-era balneological steam sanatorium.", 10, 10, "https://images.unsplash.com/photo-1544161515-4ab6ce6db874?auto=format&fit=crop&w=800", 300.00m, 4, "Varzob", 38.8953m, 68.7914m, true, "Khoja-Obigarm Wellness" },
                    { 6, "High-altitude nomadic life, yaks, and moon-like landscapes near the Chinese border.", 12, 6, "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?auto=format&fit=crop&w=800", 750.00m, 5, "East Pamir", 38.1702m, 73.9647m, true, "Murghab: Roof of the World" },
                    { 7, "Historical tour to the 5th-century fortress and the Syr Darya river.", 2, 5, "https://images.unsplash.com/photo-1523393160341-9c869066666d?auto=format&fit=crop&w=800", 90.00m, 4, "Sughd", 40.2825m, 69.6221m, true, "Khujand Fortress Tour" },
                    { 8, "Eco-trip to one of the most beautiful and remote valleys in Tajikistan.", 5, 8, "https://images.unsplash.com/photo-1501785888041-af3ef285b470?auto=format&fit=crop&w=800", 210.00m, 5, "Khatlon", 38.2167m, 69.8333m, true, "Sari Khosor Nature" },
                    { 9, "A day trip to the reconstructed palace of the medieval Kings of Khuttal.", 1, 9, "https://images.unsplash.com/photo-1590059132218-22ca52103723?auto=format&fit=crop&w=800", 45.00m, 4, "Khatlon", 37.7772m, 69.5539m, true, "Hulbuk Fortress History" },
                    { 10, "The most popular recreation area near Dushanbe for rivers and hiking.", 1, 3, "https://images.unsplash.com/photo-1470770841072-f978cf4d019e?auto=format&fit=crop&w=800", 35.00m, 5, "RRP", 38.7411m, 68.8144m, true, "Varzob Gorge Day Trip" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "FlightId", "HotelId", "Status", "TourId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 7, true, 1, 1 },
                    { 4, new DateTime(2026, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, 4, 4 },
                    { 6, new DateTime(2026, 1, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 9, true, 9, 6 },
                    { 7, new DateTime(2026, 1, 18, 18, 20, 0, 0, DateTimeKind.Unspecified), null, 4, true, 2, 7 },
                    { 9, new DateTime(2026, 1, 20, 13, 10, 0, 0, DateTimeKind.Unspecified), null, 10, true, 5, 9 },
                    { 10, new DateTime(2026, 1, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "FlightId", "HotelId", "Text", "TourId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, "The Pamir Highway tour was a life-changing experience! Highly recommend.", 1, 1 },
                    { 4, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Iskanderkul Lake is breathtaking. The tour guide was very knowledgeable.", 4, 4 },
                    { 6, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, "Hulbuk Fortress is a hidden gem in Khatlon. A must-visit for history lovers.", 9, 6 },
                    { 7, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Panjakent ruins are impressive. Seven Lakes tour was a bit tiring but worth it.", 2, 7 },
                    { 9, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, "The sanatorium in Khoja-Obigarm is unique. Perfect for health and relaxation.", 5, 9 },
                    { 10, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Awesome day trip to Varzob Gorge. Great way to escape the city heat!", 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TourId",
                table: "Bookings",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FlightId",
                table: "Reviews",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HotelId",
                table: "Reviews",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TourId",
                table: "Reviews",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPoint_TourId",
                table: "TourPoint",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_HotelId",
                table: "Tours",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TourPoint");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
