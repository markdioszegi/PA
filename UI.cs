using System;
using System.Collections.Generic;

namespace Refrigerator
{
    public static class UI
    {
        public static void PrintLine(string message)
        {
            System.Console.WriteLine(message);
        }
        public static void PrintContents(List<Consumable> consumables)
        {
            if (consumables.Count <= 0)
            {
                PrintInfo("Fridge is empty!");
                return;
            }
            PrintInfo("Contents: ");
            int i = 1;
            foreach (var consumable in consumables)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.Write($"{i}. ");
                Console.ResetColor();
                UI.PrintLine(consumable.ToString());
                i++;
            }
        }
        public static void PrintInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write("INFO ");
            Console.ResetColor();
            System.Console.WriteLine(message);
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("ERROR ");
            Console.ResetColor();
            System.Console.WriteLine(message);
        }
    }
}