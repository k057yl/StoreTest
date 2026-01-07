using StoreService.Data;
using StoreService.Models;

namespace StoreService
{
    public static class DbSeeder
    {
        public static void Seed(StoreDbContext db)
        {
            if (db.Categories.Any()) return;

            var cat1 = new Category { Name = "Electronics" };
            var cat2 = new Category { Name = "Books" };
            db.Categories.AddRange(cat1, cat2);

            var prod1 = new Product { Name = "Laptop", SKU = "LP123", Price = 1000, Category = cat1 };
            var prod2 = new Product { Name = "Novel", SKU = "BK001", Price = 20, Category = cat2 };
            db.Products.AddRange(prod1, prod2);

            var client = new Client
            {
                FullName = "Ivan Petrov",
                BirthDate = new DateTime(1990, 1, 7, 0, 0, 0, DateTimeKind.Utc),
                RegistrationDate = DateTime.UtcNow
            };
            db.Clients.Add(client);

            var purchase = new Purchase
            {
                Number = "P001",
                Date = DateTime.UtcNow,
                TotalAmount = prod1.Price + prod2.Price * 2,
                Client = client,
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem { Product = prod1, Quantity = 1, Price = prod1.Price },
                    new PurchaseItem { Product = prod2, Quantity = 2, Price = prod2.Price }
                }
            };
            db.Purchases.Add(purchase);

            db.SaveChanges();
        }
    }
}