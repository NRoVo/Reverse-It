using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здаров Братуха! Го катнем в игруху! Тема такая, есть короче циферки от 1 до 9.\n" +
                              "Но вот они, пидарасы, потерялись и выстроились в неправильном порядке! Ууу сука!\n" +
                              "Ну хули делать! Поможем этим утыркам. Ты, кароч, можешь сам циферки от 1 до 9 в\n" +
                              "строку ниже загонять! Почти как хуй в пизду. И, типа, какое число ебанешь, столько\n" +
                              "циферок считая слева направо встанут в обратном текущему порядке.");
            var array = BuildArray();

            while (!IsArraySorted(array))
            {
                PrintArray(array);
                var numberToReverse = GetNumberToReverse();
                ReverseIt(array, numberToReverse);
                Console.WriteLine();
            }
            
            PrintArray(array);
            Console.WriteLine("Пизда ты умник! Молодец!");
            Console.ReadKey();
        }
        
        private static bool IsArraySorted(int[] array)
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
            var numbers = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
            
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
                if (numbers[index] == index + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(numbers[index] + " ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        private static int GetNumberToReverse()
        {
            int number;
            while (true)
            {
                Console.Write("Ебани колличество циферок, которые хочешь развернуть, Братуха: ");
                var input = Console.ReadLine();
                var isNumeric = Int32.TryParse(input, out number);
                
                if (isNumeric && number >= 1 && number <= 9)
                {
                    break;
                }
                else if (isNumeric)
                {
                    Console.WriteLine("Далбаёбина! Выбирай циферки от 1 до 9, бля!");
                }
                else
                {
                    Console.WriteLine("Ты шо, ёб твою мать, не знаешь шо такое цифры?");
                }
            }
            return number;
        }

        private static void ReverseIt(int[] numbers, int numberToReverse)
        {
            var side1 = 0;
            var side2 = numberToReverse - 1;

            while (side1 < side2)
            {
                var temp = numbers[side1];
                numbers[side1] = numbers[side2];
                numbers[side2] = temp;

                side1++;
                side2--;
            }
        }
    }
}
