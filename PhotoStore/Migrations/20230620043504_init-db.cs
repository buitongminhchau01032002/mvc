using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhotoStore.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 20, 11, 35, 4, 658, DateTimeKind.Local).AddTicks(8043), "https://images.unsplash.com/photo-1685625762287-5d08e37d5292?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxMHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60", "The desert with sand dunes", 1 },
                    { 2, new DateTime(2023, 6, 20, 11, 35, 4, 658, DateTimeKind.Local).AddTicks(8045), "https://images.unsplash.com/photo-1671600938989-40d68c9d1c05?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDI5fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=500&q=60", "Beach and mountains at sunset ", 1 },
                    { 3, new DateTime(2023, 6, 20, 11, 35, 4, 658, DateTimeKind.Local).AddTicks(8046), "https://images.unsplash.com/photo-1685016762514-2af20a9b0105?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDM4fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=500&q=60", "Small road inside a forest", 1 },
                    { 4, new DateTime(2023, 6, 20, 11, 35, 4, 658, DateTimeKind.Local).AddTicks(8050), "https://images.unsplash.com/photo-1671600939110-7b0625c25ef5?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDE0fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=500&q=60", "A peacock in a forest", 2 },
                    { 5, new DateTime(2023, 6, 20, 11, 35, 4, 658, DateTimeKind.Local).AddTicks(8052), "https://images.unsplash.com/photo-1686224736284-074484ae7c9b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDM5fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=600&q=60", "A side of the sky mountains ", 1 },
                    { 6, new DateTime(2023, 6, 20, 11, 35, 4, 658, DateTimeKind.Local).AddTicks(8053), "https://images.unsplash.com/photo-1686548812883-9d3777f4c137?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzfHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60", "A small river inside a forest", 2 },
                    { 7, new DateTime(2023, 6, 20, 11, 35, 4, 658, DateTimeKind.Local).AddTicks(8054), "https://images.unsplash.com/photo-1682685797818-c9dc151d241e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwyNnx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60", "The mountains in a desert", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "DisplayName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "https://hips.hearstapps.com/hmg-prod/images/domestic-cat-lies-in-a-basket-with-a-knitted-royalty-free-image-1592337336.jpg?crop=0.668xw:1.00xh;0.247xw,0&resize=1200:*", "Minh Chau", "96e79218965eb72c92a549dd5a330112", "minhchau" },
                    { 2, "https://t3.ftcdn.net/jpg/01/39/57/98/360_F_139579875_x5jJX0QBhdjzDJbjB9abyHK6k0xDr1nf.jpg", "Chau Minh", "96e79218965eb72c92a549dd5a330112", "chauminh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
