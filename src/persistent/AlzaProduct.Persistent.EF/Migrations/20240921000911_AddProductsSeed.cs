using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlzaProduct.Persistent.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Ergonomic wireless mouse with high precision.", "mouse.jpg", "Wireless Mouse", 29.99m },
                    { 2, "Mechanical keyboard with RGB lighting.", "keyboard.jpg", "Gaming Keyboard", 79.99m },
                    { 3, "27-inch 4K monitor with IPS panel and ultra-thin bezels.", "monitor.jpg", "4K Monitor", 299.99m },
                    { 4, "6-in-1 USB-C hub with HDMI, USB 3.0, and card reader.", "usbc_hub.jpg", "USB-C Hub", 39.99m },
                    { 5, "Over-ear headphones with active noise cancelling and Bluetooth.", "headphones.jpg", "Noise Cancelling Headphones", 199.99m },
                    { 6, "500GB portable SSD with USB 3.1 support.", "ssd.jpg", "Portable SSD", 99.99m },
                    { 7, "Waterproof smartwatch with heart rate monitor and GPS.", "smartwatch.jpg", "Smartwatch", 249.99m },
                    { 8, "Centralized smart home hub with voice assistant integration.", "smarthub.jpg", "Smart Home Hub", 149.99m },
                    { 9, "Portable Bluetooth speaker with 12-hour battery life.", "speaker.jpg", "Bluetooth Speaker", 59.99m },
                    { 10, "Fast wireless charger compatible with most smartphones.", "wireless_charger.jpg", "Wireless Charger", 19.99m },
                    { 11, "Adjustable aluminum laptop stand for better ergonomics.", "laptop_stand.jpg", "Laptop Stand", 24.99m },
                    { 12, "Ergonomic gaming chair with lumbar support and adjustable height.", "gaming_chair.jpg", "Gaming Chair", 189.99m },
                    { 13, "Professional graphics tablet with pen and multi-touch support.", "graphics_tablet.jpg", "Graphics Tablet", 149.99m },
                    { 14, "Wi-Fi enabled smart thermostat with energy-saving features.", "thermostat.jpg", "Smart Thermostat", 129.99m },
                    { 15, "Stainless steel electric kettle with temperature control.", "kettle.jpg", "Electric Kettle", 49.99m },
                    { 16, "Automatic drip coffee maker with programmable timer.", "coffee_maker.jpg", "Coffee Maker", 89.99m },
                    { 17, "HEPA air purifier with multi-stage filtration and quiet operation.", "air_purifier.jpg", "Air Purifier", 179.99m },
                    { 18, "Water-resistant fitness tracker with step counting and sleep tracking.", "fitness_tracker.jpg", "Fitness Tracker", 69.99m },
                    { 19, "4K action camera with waterproof casing and image stabilization.", "action_camera.jpg", "Action Camera", 299.99m },
                    { 20, "Smart robot vacuum with app control and mapping technology.", "robot_vacuum.jpg", "Robot Vacuum", 399.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
