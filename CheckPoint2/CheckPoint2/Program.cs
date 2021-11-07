using System;

namespace CheckPoint2
{
    class Program
    {
        static void Main(string[] args)
        {
            Category cat = new();
            Product product = new();

        GetInput:
            Console.WriteLine("Choose [c]ategory, [p]roduct, [s]earch or [q]uit.");
            switch (Helper.TrimAndLower(Console.ReadLine()))
            {
                case "category" or "c": cat.Loop(); break;
                case "product" or "p": product.Loop(); break;
                case "search" or "s": product.Search(); break;
                case "quit" or "q": Console.Clear(); return;
                default: Console.WriteLine("Invalid Input. Try Again..."); goto GetInput;
            }
            cat.Show();
            product.Show();
            goto GetInput;
        }
    }
}

