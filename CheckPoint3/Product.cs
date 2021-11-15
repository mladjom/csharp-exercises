using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Graph;

namespace CheckPoint3
{
    public class Product
    {
        static List<Product> products = new();

        List<Category> categories = new List<Category>
        {
            new Category { Id= 1, Name = "Laptop Computers" },
            new Category { Id= 2, Name = "Mobile Phones" }
        };

        List<Office> offices = new List<Office>
        {
            new Office { Id= 1, City = "Malmö", Country = "Sweden", Currency = "SEK" },
            new Office { Id= 2, City = "Novi Pazar", Country = "Serbia", Currency = "RSD" },
            new Office { Id= 3, City = "Utrecht", Country = "Nederlands", Currency = "EUR" },
        };

        public Product()
        {
        }
        public Product(string Name,
                        int Office,
                        string Category,
                        string Brand,
                        string Model,
                        double Price,
                        DateTime PurchasedAt,
                        int Stock)
        {
            this.Name = Name;
            this.Office = Office;
            this.Category = Category;
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
            this.PurchasedAt = PurchasedAt;
            this.Stock = Stock;
        }

        public string Name { get; set; }
        public int Office { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        //public string Category { get; set; }
        public double Price { get; set; }
        public DateTime PurchasedAt { get; set; }
        public int Stock { get; set; }

        public void Loop()
        {
            while (true)
            {

                Console.WriteLine("Name of the product?");
                Name = Console.ReadLine();
                while (string.IsNullOrEmpty(Name))
                {
                    Console.WriteLine("This is not valid input. Please write products name.");
                    Name = Console.ReadLine();
                }

            GetOfficeInput: Console.WriteLine("Choose office:");
                foreach (var office in offices)
                {
                    Console.WriteLine("[{0}] {1}, {2}", office.Id, office.City, office.Country);
                }
                switch (Console.ReadLine())
                {
                    case "1":
                        Office = 0;
                        break;
                    case "2":
                        Office = 1;
                        break;
                    case "3":
                        Office = 2;
                        break;
                    default: Console.WriteLine("Invalid Input. Try Again..."); goto GetOfficeInput;
                }
            GetCatInput: Console.WriteLine("Choose category:");
                foreach (var cat in categories)
                {
                    Console.WriteLine("[{0}] {1}", cat.Id, cat.Name);
                }
                switch (Console.ReadLine())
                {
                    case "1":
                        Category = categories[0].Name;
                        break;
                    case "2":
                        Category = categories[1].Name;
                        break;
                    default: Console.WriteLine("Invalid Input. Try Again..."); goto GetCatInput;
                }

                Console.WriteLine("Brand of the product?");
                Brand = Console.ReadLine();
                while (string.IsNullOrEmpty(Brand))
                {
                    Console.WriteLine("This is not valid input. Please write brand name.");
                    Brand = Console.ReadLine();
                }

                Console.WriteLine("Model of the product?");
                Model = Console.ReadLine();
                while (string.IsNullOrEmpty(Model))
                {
                    Console.WriteLine("This is not valid input. Please write products model.");
                    Model = Console.ReadLine();
                }


                Console.WriteLine("Products price in dolars '$'?");
                var price = Console.ReadLine();
                double validDouble;
                while (!double.TryParse(price, out validDouble))
                {
                    Console.WriteLine("This is not valid input. Please enter an integer value.");
                    price = Console.ReadLine();
                }

                Console.WriteLine("How many products are in stock?");
                var stock = Console.ReadLine();
                int validInt;
                while (!int.TryParse(stock, out validInt))
                {
                    Console.WriteLine("This is not valid input. Please enter an integer value.");
                    stock = Console.ReadLine();
                }

                Console.WriteLine("Product purchased? 'MM/dd/yyyy'");
                var purchasedAt = Console.ReadLine();
                DateTime validDate;
                while (!DateTime.TryParseExact(purchasedAt, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out validDate))
                {
                    Console.WriteLine("Not valid input. Please enter a date.");
                    purchasedAt = Console.ReadLine();
                }

                try
                {
                    Product product = new();
                    product.Name = Name;
                    product.Office = Office;
                    product.Category = Category;
                    product.Brand = Brand;
                    product.Model = Model;
                    product.Price = Convert.ToDouble(price);
                    product.Stock = Convert.ToInt32(stock);
                    product.PurchasedAt = Convert.ToDateTime(purchasedAt);
                    products.Add(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Name + " was added.");
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    throw;
                }
                Console.WriteLine("Press 'Enter' to continue or [q]uit.");
                switch (Helper.TrimAndLower(Console.ReadLine()))
                {
                    case "quit" or "q": Console.Clear(); return;
                    default: continue;
                }
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Products Added:");
            Console.ResetColor();
            Console.WriteLine("" +
                "Name".PadRight(25) +
                "att Office".PadRight(25) +
                "Category" + "".PadRight(25) +
                "Brand" + "".PadRight(25) +
                "Model" + "".PadRight(25) +
                "Price" + "".PadRight(25) +
                "Stock" + "".PadRight(25) +
                "Purchased");
            Console.WriteLine("-----------------------------------------------");

            List<Product> query = products
                .OrderBy(x => x.Office)
                .ThenByDescending(x => x.Category)
                .ThenBy(x => x.PurchasedAt)
                .ToList();

            DateTime now = new DateTime();
            now = DateTime.Now;

            foreach (Product product in query)
            {
                if (product.PurchasedAt.AddMonths(33) < now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (product.PurchasedAt.AddMonths(30) < now)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(
                    product.Name.PadRight(25) +
                    offices[product.Office].City + ", " + offices[product.Office].Country.PadRight(25) +
                    product.Category.PadRight(25) +
                    product.Brand.PadRight(25) +
                    product.Model.PadRight(25) +
                    Convert.ToString(product.Price).PadRight(25) +
                    Convert.ToString(product.Stock).PadRight(25) +
                    product.PurchasedAt);
                Console.WriteLine("-----------------------------------------------");
                Console.ResetColor();
            }
        }

    }
}
