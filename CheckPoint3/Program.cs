using System;

namespace CheckPoint3
{
    class Program
    {

        static void Main(string[] args)
        {
            Product product = new();
            Console.WriteLine("Asset Tracking");
   
        GetInput:
            Console.WriteLine("Choose [p]roduct or [q]uit.");
            switch (Helper.TrimAndLower(Console.ReadLine()))
            {
                case "product" or "p": product.Loop(); break;
                case "quit" or "q": Console.Clear(); return;
                default: Console.WriteLine("Invalid Input. Try Again..."); goto GetInput;
            }

            product.Show();
            goto GetInput;
        }
    }
}
