using System;
using System.Text;
using System.Collections.Generic;

namespace bingoNumberGenerator
{
    public class Menu
    {
        Generator Generator;
        List<int> CheckList;

        public Menu()
        {
            this.Generator = new Generator();
            this.CheckList = new List<int>();
        }

        //sets upper limit
        public void SetLimit()
        {
            Console.WriteLine("Please enter an upper limit of numbers");
            string input = Console.ReadLine();

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
            string input = Console.ReadLine();

            if (IsValid(input) == true)
            {
                int userSelect = int.Parse(input);

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
                        Console.WriteLine("Enter \"stop\" when finished");
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
                        Console.WriteLine();
                        Start();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid selection");
                Console.WriteLine();
                Start();
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
            string input = Console.ReadLine();

            if (IsValid(input) == true)
            {
                int userSelect = int.Parse(input);

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
                        foreach (var number in Generator.SortedList)
                        {
                            Console.Write($"{number}\t");
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Start();
                        break;
                    case 3:
                        Console.WriteLine();
                        ExportList();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        Console.WriteLine();
                        ViewNumbers();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid selection");
                Console.WriteLine();
                ViewNumbers();
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
                Console.WriteLine("Please enter a positive number");
                Console.WriteLine();
                CheckSpecNumber();
            }
        }

        //checks multiple numbers
        public void CheckNumbers()
        {
            var input = Console.ReadLine();

            if (IsValid(input) == true)
            {
                int number = int.Parse(input);

                if (number <= Generator.UpperLimit)
                {
                    this.CheckList.Add(number);
                }
                else
                {
                    Console.WriteLine($"Numbers must be less than or equal to {Generator.UpperLimit}");
                }

                CheckNumbers();
            }
            else if (input.ToUpper() == "STOP")
            {
                Console.WriteLine();

                for (int i = 0; i < this.CheckList.Count; i++)
                {
                    if (Generator.NumbersCalled.Contains(this.CheckList[i]))
                    {
                        Console.WriteLine($"{this.CheckList[i]} has been called");
                    }
                    else
                    {
                        Console.WriteLine($"{this.CheckList[i]} hasn't been called yet");
                    }
                }

                Console.WriteLine();
                this.CheckList.Clear();
                Start();
            }
            else
            {
                Console.WriteLine("Please enter a positive number or \"stop\"");
                CheckNumbers();
            }
        }

        //shows statistics
        public void Statistics()
        {
            double numberAverage = 0;
            double numberTotal = 0;

            for (int i = 0; i < Generator.NumbersCalled.Count; i++)
            {
                numberTotal += Generator.NumbersCalled[i];
                numberAverage = numberTotal / Generator.NumbersCalled.Count;
            }

            numberAverage = Math.Round(numberAverage, 2);

            Console.WriteLine($"Total numbers drawn: {Generator.NumbersCalled.Count}");
            Console.WriteLine($"Average of numbers drawn: {numberAverage}");
            Console.WriteLine();
            Start();
        }

        //exports list
        public void ExportList()
        {
            StringBuilder stringBuild = new StringBuilder();
            foreach (int number in Generator.NumbersCalled) {
                stringBuild.Append(number).Append("  ");
            }
            string listString = stringBuild.ToString();

            System.IO.File.WriteAllText("drawn_numbers.txt", listString);

            Console.WriteLine("Text file exported");
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