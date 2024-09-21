using AlzaProduct.Persistent.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace AlzaProduct.Persistent.EF.SeedData;

internal static class ProductsSeed
{
    public static ModelBuilder SeedProducts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
           new Product { Id = 1, Name = "Wireless Mouse", ImgUri = "mouse.jpg", Price = 29.99M, Description = "Ergonomic wireless mouse with high precision." },
           new Product { Id = 2, Name = "Gaming Keyboard", ImgUri = "keyboard.jpg", Price = 79.99M, Description = "Mechanical keyboard with RGB lighting." },
           new Product { Id = 3, Name = "4K Monitor", ImgUri = "monitor.jpg", Price = 299.99M, Description = "27-inch 4K monitor with IPS panel and ultra-thin bezels." },
           new Product { Id = 4, Name = "USB-C Hub", ImgUri = "usbc_hub.jpg", Price = 39.99M, Description = "6-in-1 USB-C hub with HDMI, USB 3.0, and card reader." },
           new Product { Id = 5, Name = "Noise Cancelling Headphones", ImgUri = "headphones.jpg", Price = 199.99M, Description = "Over-ear headphones with active noise cancelling and Bluetooth." },
           new Product { Id = 6, Name = "Portable SSD", ImgUri = "ssd.jpg", Price = 99.99M, Description = "500GB portable SSD with USB 3.1 support." },
           new Product { Id = 7, Name = "Smartwatch", ImgUri = "smartwatch.jpg", Price = 249.99M, Description = "Waterproof smartwatch with heart rate monitor and GPS." },
           new Product { Id = 8, Name = "Smart Home Hub", ImgUri = "smarthub.jpg", Price = 149.99M, Description = "Centralized smart home hub with voice assistant integration." },
           new Product { Id = 9, Name = "Bluetooth Speaker", ImgUri = "speaker.jpg", Price = 59.99M, Description = "Portable Bluetooth speaker with 12-hour battery life." },
           new Product { Id = 10, Name = "Wireless Charger", ImgUri = "wireless_charger.jpg", Price = 19.99M, Description = "Fast wireless charger compatible with most smartphones." },
           new Product { Id = 11, Name = "Laptop Stand", ImgUri = "laptop_stand.jpg", Price = 24.99M, Description = "Adjustable aluminum laptop stand for better ergonomics." },
           new Product { Id = 12, Name = "Gaming Chair", ImgUri = "gaming_chair.jpg", Price = 189.99M, Description = "Ergonomic gaming chair with lumbar support and adjustable height." },
           new Product { Id = 13, Name = "Graphics Tablet", ImgUri = "graphics_tablet.jpg", Price = 149.99M, Description = "Professional graphics tablet with pen and multi-touch support." },
           new Product { Id = 14, Name = "Smart Thermostat", ImgUri = "thermostat.jpg", Price = 129.99M, Description = "Wi-Fi enabled smart thermostat with energy-saving features." },
           new Product { Id = 15, Name = "Electric Kettle", ImgUri = "kettle.jpg", Price = 49.99M, Description = "Stainless steel electric kettle with temperature control." },
           new Product { Id = 16, Name = "Coffee Maker", ImgUri = "coffee_maker.jpg", Price = 89.99M, Description = "Automatic drip coffee maker with programmable timer." },
           new Product { Id = 17, Name = "Air Purifier", ImgUri = "air_purifier.jpg", Price = 179.99M, Description = "HEPA air purifier with multi-stage filtration and quiet operation." },
           new Product { Id = 18, Name = "Fitness Tracker", ImgUri = "fitness_tracker.jpg", Price = 69.99M, Description = "Water-resistant fitness tracker with step counting and sleep tracking." },
           new Product { Id = 19, Name = "Action Camera", ImgUri = "action_camera.jpg", Price = 299.99M, Description = "4K action camera with waterproof casing and image stabilization." },
           new Product { Id = 20, Name = "Robot Vacuum", ImgUri = "robot_vacuum.jpg", Price = 399.99M, Description = "Smart robot vacuum with app control and mapping technology." }
       );

        return modelBuilder;
    }
}
