using System;
using System.Collections.Generic;
using System.Linq;
using MiniProject2.Models;
using System.Globalization;


namespace MiniProject2.Controllers
{
    class ProductController
    {
        static DataContext db = new DataContext();

        DateTime localDate = DateTime.Now;
        public static void Create()
        {
            Product product = new();
            product.Name = "Name";
            product.Category = new Category();
            db.Add(product);
            db.SaveChanges();
        }

        public static void Read()
        {
            //List<Product> products = db.Products.ToList();

            foreach (var p in db.Products)
            {
                Console.WriteLine("{0} {1}", p.Id, p.Name);
            }
            Console.ReadLine();
        }

        public static void Update()
        {
           // Read();
            Console.WriteLine("");
            Product product = db.Products.Find(4);
            product.Name = "Better Pen Drive";
            db.SaveChanges();
        }

        public static void Delete()
        {
            Read();
            Console.WriteLine("Write id to delete product.");
            Product product = db.Products.Find(1);
            db.Products.Remove(product);
            db.SaveChanges();
            Read();
        }

    }
}
