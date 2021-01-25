using System;
using System.Collections.Generic;

namespace ReverseIt
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to game \"Reverse it\"! Choose the quantity of digits from left to right to reverse."+
                              " Your goal is to place all of them in right ascending order from left to right.");
            var array = BuildArray();

            while (!IsArraySorted(array))
            {
                PrintArray(array);
                var numberToReverse = GetNumberToReverse();
                Array.Reverse(array, 0, numberToReverse);
                Console.WriteLine();
            }
            
            PrintArray(array);
            Console.WriteLine("Congradulations! You won!");
            Console.ReadKey();
        }
        
        private static bool IsArraySorted(IReadOnlyList<int> array)
        {
            for (var index = 0; index < 9; index++)
            {
                if (array[index] != index + 1)
                {
                    return false;
                }
            }
            return true;
        }

        private static int[] BuildArray()
        {
            var random = new Random();
            var numbers = new int[9];
            
            for (var number = 1; number <= 9; number++)
            {
                int spot;
                do
                {
                    spot = random.Next(9);
                } while (numbers[spot] != 0);

                numbers[spot] = number;
            }

            return numbers;
        }

        private static void PrintArray(int[] numbers)
        {
            for (var index = 0; index < numbers.Length; index++)
            {
                Console.ForegroundColor = numbers[index] == index + 1 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"{numbers[index].ToString()} ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        private static int GetNumberToReverse()
        {
            int number;
            while (true)
            {
                Console.Write("Type the quantity of digits from left to right that you would like to reverse: ");
                var input = Console.ReadLine();
                var isNumeric = int.TryParse(input, out number);
                
                if (isNumeric && number >= 1 && number <= 9)
                {
                    break;
                }

                Console.WriteLine(isNumeric
                    ? "Choose please the quantity from 1 to 9."
                    : "That was not a number!");
            }
            return number;
        }
    }
}
