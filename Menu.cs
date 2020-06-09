using System;
using System.Collections.Generic;

namespace bingoNumberGenerator
{
    public class Menu
    {
        Generator Generator;

        public Menu()
        {
            this.Generator = new Generator();
        }

        //sets upper limit
        public void SetLimit()
        {
            Console.Write("Please enter an upper limit of numbers: ");
            var input = Console.ReadLine();

            if (IsValid(input) == true)
            {
                int upperLimit = int.Parse(input);
                Generator.UpperLimit = upperLimit;
                Console.WriteLine();
                Start();
            }
            else
            {
                Console.WriteLine("The limit must be a positive number");
                Console.WriteLine();
                SetLimit();
            }
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Swinburne Bingo Club");
            Console.WriteLine("1. Draw next number");
            Console.WriteLine("2. View all drawn numbers");
            Console.WriteLine("3. Check specific number");
            Console.WriteLine("4. Check multiple numbers");
            Console.WriteLine("5. Statistics");
            Console.WriteLine("6. Exit");
            int userSelect = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (userSelect)
            {
                case 1:
                    DrawNextNumber();
                    break;
                case 2:
                    ViewNumbers();
                    break;
                case 3:
                    CheckSpecNumber();
                    break;
                case 4:
                    CheckNumbers();
                    break;
                case 5:
                    Statistics();
                    break;
                case 6:
                    Console.WriteLine("Goodbye");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection");
                    break;
            }
        }

        public void DrawNextNumber()
        {
            Console.WriteLine($"The next number is...");
            Console.WriteLine(Generator.GenerateNumber());
            Console.WriteLine();
            Start();
        }

        public void ViewNumbers()
        {
            Console.WriteLine("1. Print chronologically");
            Console.WriteLine("2. Print numerically");
            int userSelect = int.Parse(Console.ReadLine());

            switch (userSelect)
            {
                case 1:
                    foreach (var number in Generator.NumbersCalled)
                    {
                        Console.Write($"{number}\t");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Start();
                    break;
                case 2:
                    Generator.NumbersCalled.Sort();
                    foreach (var number in Generator.NumbersCalled)
                    {
                        Console.Write($"{number}\t");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Start();
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection");
                    Console.WriteLine();
                    ViewNumbers();
                    break;
            }
        }

        public void CheckSpecNumber()
        {
            var input = Console.ReadLine();

            if (IsValid(input) == true)
            {
                int number = int.Parse(input);

                if (Generator.NumbersCalled.Contains(number))
                {
                    Console.WriteLine("This number has been called");
                }
                else
                {
                    Console.WriteLine("This number hasn't been called yet");
                }

                Console.WriteLine();
                Start();
            }
            else
            {
                Console.WriteLine("Pleas enter a positive number");
                Console.WriteLine();
                CheckSpecNumber();
            }
        }

        public void CheckNumbers()
        {
            Console.WriteLine("This are is under construction");
            Start();
        }

        public void Statistics()
        {
            Console.WriteLine("This are is under construction");
            Start();
        }

        public bool IsValid(string input)
        {
            int number;

            if (int.TryParse(input, out number))
            {
                if (number < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}