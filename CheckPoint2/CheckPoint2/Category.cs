using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckPoint2
{
    class Category
    {
        public string Name { get; set; }

        public List<Category> Categories = new List<Category>();

        public void Loop()
        {
            while (true)
            {
                Console.WriteLine("What is the name of the categoryto be added?");
                string name = Console.ReadLine();
                while (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("This is not valid input. Please Write the Name.");
                    name = Console.ReadLine();
                }
                try
                {
                    Category cat = new();
                    cat.Name = name;
                    Categories.Add(cat);
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
            Console.WriteLine("Categories Added:");
            Console.ResetColor();
            Console.WriteLine("Category Name");
            Console.WriteLine("-------------");

            foreach (Category cat in Categories)
            {
                Console.WriteLine(cat.Name);
                Console.WriteLine("------------");

            }
        }
    }
}
