using System;
using MiniProject2.Controllers;

namespace MiniProject2.Helpers
{
    class General
    {

        public static void Menu()
        {
            ProductController product = new();
        GetInput:
            Console.WriteLine("Choose [c]reate, [r]ead, [u]update, [d]elete  or [q]uit.");
            switch (TrimAndLower(Console.ReadLine()))
            {
                case "create" or "c": product.Create(); break;
                case "read" or "r": ProductController.Read(); break;
                case "update" or "u": product.Update(); break;
                case "delete" or "d": product.Delete(); break;
                case "quit" or "q": Console.Clear(); return;
                default: Console.WriteLine("Invalid Input. Try Again..."); goto GetInput;
            }
            goto GetInput;

        }

        public static string TrimAndLower(string str)
        {
            return str.Trim().ToLower();
        }

    }
}
