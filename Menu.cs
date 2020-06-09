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
            Console.Write("To Start:\nPlease enter an upper limit of numbers: ");
            var input = Console.ReadLine();
            int upperLimit;

            if (int.TryParse(input, out upperLimit))
            {
                if (upperLimit < 0)
                {
                    Console.WriteLine("The limit must not be a negative number");
                    Console.WriteLine();
                    SetLimit();
                }
                else
                {
                    Generator.UpperLimit = upperLimit;
                    Console.WriteLine();
                    Start();
                }
            }
            else
            {
                Console.WriteLine("This is not a number");
                Console.WriteLine();
                SetLimit();
            }
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Swiburne Bingo Club");
            Console.WriteLine("1. Draw next number");
            Console.WriteLine("2. View all drawn numbers");
            Console.WriteLine("3. Check specific number");
            Console.WriteLine("4. Exit");
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
                    Exit();
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection");
                    break;
            }
            Console.WriteLine();
        }

        public void DrawNextNumber()
        {
            int nextNumber = Generator.GenerateNumber();
            Console.WriteLine($"The next number is...\n{nextNumber}");

            Console.WriteLine();
            Console.ReadLine();
            Start();
        }

        public void ViewNumbers()
        {
            Console.WriteLine("1. Print chronologically");
            Console.WriteLine("2. Print numerically");
            int userSelect = int.Parse(Console.ReadLine());

            switch (userSelect) {
                case 1:
                    foreach ()
            }
        }

        public void CheckSpecNumber()
        {

        }

        public void Exit()
        {

        }
    }
}