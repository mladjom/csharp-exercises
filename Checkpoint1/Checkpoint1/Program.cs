using System;
using System.Linq;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'");
            Console.WriteLine(
                "Accepteras bara ett namn som består av bokstäver -bindestreck - siffror.\n" +
                "Siffer - delen måste vara ett heltal mellan 200 och 500.\n\r" +
                "Exempel på giltiga produktnamn:\n" +
                "   CE-400\n" +
                "   XX-480\n" +
                "   LABAN-231\n"
            );

            Console.ResetColor();

            ResizeArrayWithArrayResize();

            Console.ReadLine();
        }

        // Resize an Array With the Array.Resize() Method
        static void ResizeArrayWithArrayResize()
        {
            string[] productsArray = new string[0];
            int index = 0;

            while (true)
            {
                Console.Write("Ange produkt namn: ");
                string data = Console.ReadLine();
                bool isHyphen = data.Contains("-");
                bool isLetter = data.Any(Char.IsLetter);
                bool isDigit = data.Any(Char.IsDigit);

                if (data.ToLower().Trim() == "exit") break;

                if (string.IsNullOrEmpty(data))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du får inte ange ett tomt värde.");
                    Console.ResetColor();
                }

                else if (!isHyphen || !isLetter || !isDigit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Accepteras bara ett namn som består av bokstäver -bindestreck - siffror.");
                    Console.ResetColor();
                }

                else
                {
                    int hyphenPosition = data.IndexOf("-");
                    string lettersFirst = data.Substring(0, hyphenPosition);
                    string numbersLast = data.Substring(hyphenPosition + 1, +(data.Length - hyphenPosition - 1));

                    if (!lettersFirst.All(Char.IsLetter))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktig format på vänstra delen.");
                        Console.ResetColor();
                    }

                    if (!numbersLast.All(Char.IsDigit))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktig format på högra delen.");
                        Console.ResetColor();
                    }

                    else
                    {
                        int numVal = Int32.Parse(numbersLast);
                        if (numVal < 200 || numVal > 500)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Den numeriska delen måste vara melan 200 och 500.");
                            Console.ResetColor();
                        }

                        else
                        {
                            Array.Resize(ref productsArray, index + 1);
                            productsArray[index] = data;
                            index++;
                        }

                    }
                }
            }

            Console.WriteLine("Du angav följande produkter (sorterade):");
            Array.Sort(productsArray);
            foreach (var item in productsArray)
            {
                Console.WriteLine("* {0}", item);
            }

        }
    }
}
