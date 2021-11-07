using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoint2
{
    class Product
    {
        public string Name;
        public double Price;

        static List<Product> Products = new();

        public void Loop()
        {
            while (true)
            {
                Console.WriteLine("What is the name of the product to be added?");
                string name = Console.ReadLine();
                while (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("This is not valid input. Please write products name.");
                    name = Console.ReadLine();
                }
                var price = Helper.GetInput<double>(
                    prompt: "What is products price?",
                    invalidMessage: "This is not valid input. Please enter an integer value.",
                    tryParse: double.TryParse);
                try
                {
                    Product product = new();
                    product.Name = name;
                    product.Price = Convert.ToDouble(price);
                    Products.Add(product);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(name + " was added.");
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
            Console.WriteLine("Product Name" + "".PadRight(15) + "Product Price");
            Console.WriteLine("-----------------------------------------------");

            List<Product> sorted = Products.OrderBy(x => x.Price).ToList();
            foreach (Product product in sorted)
            {
                Console.WriteLine(product.Name + "".PadRight(15) + product.Price);
                Console.WriteLine("-----------------------------------------------");
            }
            double sumOfAllPricies = Products.Sum(x => x.Price);
            Console.WriteLine("You have added {0} worth of products\n", sumOfAllPricies);
        }

        public void Search()
        {
            while (true)
            {
                List<Product> sorted = Products.OrderBy(x => x.Price).ToList();
                Console.WriteLine("Type to search products");
                string query = Console.ReadLine();
                bool result = Products.Any(x => x.Name == query);
                if (result)
                {
                    var matches = Products.Where(x => x.Name == query);
                    sorted.RemoveAll(x => x.Name == query);
                    foreach (var match in matches)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(match.Name + "".PadRight(20) + match.Price);
                        Console.ResetColor();
                    }
                Console.WriteLine("-----------------------------------------------");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No matches");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------------------");
                }

                foreach (var product in sorted)
                {
                    Console.WriteLine(product.Name + "".PadRight(20) + product.Price);
                }

                Console.WriteLine("Press 'Enter' to continue or [q]uit.");
                switch (Helper.TrimAndLower(Console.ReadLine()))
                {
                    case "quit" or "q": Console.Clear(); return;
                    default: continue;
                }

            }

        }
    }
}
