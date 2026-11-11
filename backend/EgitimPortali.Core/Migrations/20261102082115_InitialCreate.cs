using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgitimPortali.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SenderName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SenderEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizerUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerUnits", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriorityLevel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrganizerUnitId = table.Column<int>(type: "int", nullable: false),
                    IsPinned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsSilent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Slug = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LocationType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    OrganizerUnitId = table.Column<int>(type: "int", nullable: false),
                    PhysicalAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OnlineMeetingUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quota = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_OrganizerUnits_OrganizerUnitId",
                        column: x => x.OrganizerUnitId,
                        principalTable: "OrganizerUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedAt", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, true, false, "Eğitim" },
                    { 2, null, true, false, "Seminer" },
                    { 3, null, true, false, "Toplantı" }
                });

            migrationBuilder.InsertData(
                table: "OrganizerUnits",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "İnsan Kaynakları" },
                    { 2, false, "Bilgi Teknolojileri" }
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "CategoryId", "Content", "IsDeleted", "IsPinned", "IsSilent", "OrganizerUnitId", "PriorityLevel", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Kurum içi tüm eğitim ve etkinlik kayıtlarını artık bu sistem üzerinden yapabilirsiniz.", false, false, false, 0, "Normal", new DateTime(2026, 11, 2, 11, 21, 14, 930, DateTimeKind.Local).AddTicks(4663), "Yeni Eğitim Portalı Yayında!" },
                    { 2, 1, "Backend yeteneklerinizi geliştirmek için planlanan .NET Bootcamp kayıtlarını kaçırmayın.", false, false, false, 0, "Normal", new DateTime(2026, 11, 2, 11, 21, 14, 930, DateTimeKind.Local).AddTicks(8589), "C# Kampı Kayıtları Başladı" },
                    { 3, 1, "Yıl sonu proje demoları 31 Aralık tarihinde BİM Ana Konferans Salonunda gerçekleştirilecektir.", false, false, false, 0, "Normal", new DateTime(2026, 11, 2, 11, 21, 14, 930, DateTimeKind.Local).AddTicks(8596), "Stajyer Sunumları Geri Sayım" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "DeletedAt", "Description", "EndDate", "IsDeleted", "LocationType", "OnlineMeetingUrl", "OrganizerUnitId", "PhysicalAddress", "Quota", "Slug", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, "Sıfırdan ileri seviyeye .NET eğitimi.", new DateTime(2026, 12, 5, 17, 0, 0, 0, DateTimeKind.Utc), false, "Fiziksel", null, 1, "BİM Ana Konferans Salonu", 50, "csharp-net-bootcamp", new DateTime(2026, 12, 1, 10, 0, 0, 0, DateTimeKind.Utc), "C# ve .NET Bootcamp" },
                    { 2, 2, null, "EF Core ve MySQL performans ipuçları.", new DateTime(2026, 12, 20, 15, 0, 0, 0, DateTimeKind.Utc), false, "Online", "https://zoom.us/j/987654", 1, null, null, "veritabani-optimizasyonu", new DateTime(2026, 12, 20, 13, 0, 0, 0, DateTimeKind.Utc), "Veritabanı Optimizasyonu" },
                    { 3, 1, null, "Konteyner mimarisine giriş.", new DateTime(2026, 12, 22, 12, 0, 0, 0, DateTimeKind.Utc), false, "Fiziksel", null, 1, "Eğitim Sınıfı 1", 40, "docker-temelleri", new DateTime(2026, 12, 22, 10, 0, 0, 0, DateTimeKind.Utc), "Docker Temelleri" },
                    { 4, 2, null, "Kurum içi güvenlik kuralları.", new DateTime(2026, 12, 28, 16, 0, 0, 0, DateTimeKind.Utc), false, "Online", "https://zoom.us/j/112233", 2, null, 500, "siber-guvenlik-farkindaligi", new DateTime(2026, 12, 28, 14, 0, 0, 0, DateTimeKind.Utc), "Siber Güvenlik Farkındalığı" },
                    { 5, 3, null, "Stajyerlerin geliştirdiği Eğitim Portalı demosu.", new DateTime(2026, 12, 31, 14, 0, 0, 0, DateTimeKind.Utc), false, "Fiziksel", null, 1, "BİM Ana Konferans Salonu", 150, "stajyer-proje-sunumlari", new DateTime(2026, 12, 31, 10, 0, 0, 0, DateTimeKind.Utc), "Stajyer Proje Sunumları" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CategoryId",
                table: "Announcements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerUnitId",
                table: "Events",
                column: "OrganizerUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Slug",
                table: "Events",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrganizerUnits");
        }
    }
}
