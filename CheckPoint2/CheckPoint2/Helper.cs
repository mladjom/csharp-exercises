using System;

namespace CheckPoint2
{
    public delegate bool TryParse<T>(string @string, out T value);
    public static class Helper
    {
        public static T GetInput<T>(
            TryParse<T> tryParse,
            string prompt = null,
            string invalidMessage = null,
            Predicate<T> validation = null)
        {
            _ = tryParse ?? throw new ArgumentNullException(nameof(tryParse));
        GetInput:
            Console.WriteLine(prompt ?? $"Input a {typeof(T).Name} value: ");
            if (!tryParse(Console.ReadLine(), out T value) || !(validation is null || validation(value)))
            {
                Console.WriteLine(invalidMessage ?? $"Invalid input. Try again...");
                goto GetInput;
            }
            else
            {
                return value;
            }
        }
        public static string TrimAndLower(string str)
        {
            return str.Trim().ToLower();
        }
    }
}
