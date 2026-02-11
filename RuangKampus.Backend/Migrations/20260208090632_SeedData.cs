using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RuangKampus.Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomLoans",
                columns: new[] { "Id", "BorrowerName", "DeletedAt", "EndTime", "IsDeleted", "Purpose", "RoomName", "StartTime", "Status" },
                values: new object[,]
                {
                    { 1, "Budi Santoso", null, new DateTime(2026, 2, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Pengerjaan Tugas Akhir", "Lab Komputer 1", new DateTime(2026, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Approved" },
                    { 2, "Siti Aminah", null, new DateTime(2026, 2, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), false, "Seminar Proposal", "Aula Utama", new DateTime(2026, 2, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 3, "Himpunan Mahasiswa", null, new DateTime(2026, 2, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "Rapat Bulanan", "Ruang Rapat 1", new DateTime(2026, 2, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), "Approved" },
                    { 4, "Dosen Tamu", null, new DateTime(2026, 2, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), false, "Kuliah Umum", "Auditorium", new DateTime(2026, 2, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 5, "Admin", null, new DateTime(2026, 2, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), false, "Testing Sistem", "Studio Musik", new DateTime(2026, 2, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), "Rejected" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomLoans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomLoans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomLoans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomLoans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomLoans",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
