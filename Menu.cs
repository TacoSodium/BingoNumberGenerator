using System;
using System.Collections.Generic;
using System.Linq;

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

            switch (userSelect)
            {
                case 1:
                    Console.WriteLine();
                    DrawNextNumber();
                    break;
                case 2:
                Console.WriteLine();
                    ViewNumbers();
                    break;
                case 3:
                Console.WriteLine();
                    CheckSpecNumber();
                    break;
                case 4:
                Console.WriteLine();
                    CheckNumbers();
                    break;
                case 5:
                Console.WriteLine();
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

        //draws number
        public void DrawNextNumber()
        {
            Generator.GenerateNumber();
            int index = Generator.NumbersCalled.Count - 1;

            Console.WriteLine($"The next number is...");
            Console.WriteLine(Generator.NumbersCalled[index]);
            Console.WriteLine();
            Start();
        }

        //prints and exports list
        public void ViewNumbers()
        {
            Console.WriteLine("1. Print chronologically");
            Console.WriteLine("2. Print numerically");
            Console.WriteLine("3. Export list");
            int userSelect = int.Parse(Console.ReadLine());

            switch (userSelect)
            {
                case 1:
                    //prints chronologically
                    foreach (var number in Generator.NumbersCalled)
                    {
                        Console.Write($"{number}\t");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Start();
                    break;
                case 2:
                    //prints numerically
                    Generator.NumbersCalled.Sort();
                    foreach (var number in Generator.NumbersCalled)
                    {
                        Console.Write($"{number}\t");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Start();
                    break;
                case 3:
                    //exports list
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection");
                    Console.WriteLine();
                    ViewNumbers();
                    break;
            }
        }

        //checks one number
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

        //checks multiple numbers
        public void CheckNumbers()
        {
            Console.WriteLine("This are is under construction");
            Start();

            var input = Console.ReadLine();

            List<int> checkList = new List<int>();

            if (IsValid(input) == true)
            {
                int number = int.Parse(input);

                checkList.Add(number);

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

        //shows statistics
        public void Statistics()
        {
            double numberAverage = 0;

            for (int i = 0; i < Generator.NumbersCalled.Count; i++)
            {
                double numberTotal =+ Generator.NumbersCalled[i];
                numberAverage = numberTotal / Generator.NumbersCalled.Count;
            }

            numberAverage = Math.Round(numberAverage, 2);
            
            Console.WriteLine($"Total numbers drawn: {Generator.NumbersCalled.Count}");
            Console.WriteLine($"Average of numbers drawn: {numberAverage}");
            Console.WriteLine();
            Start();
        }

        //validates inputs
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