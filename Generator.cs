using System;
using System.Collections.Generic;

namespace bingoNumberGenerator
{
    public class Generator
    {
        public int UpperLimit;
        public List<int> NumbersCalled;
        public List<int> SortedList;

        public Generator()
        {
            this.UpperLimit = 90;
            this.NumbersCalled = new List<int>();
            this.SortedList = new List<int>();
        }

        //gernerates new number
        public void GenerateNumber()
        {
            List<int> duplicates = new List<int>();
            Random randomNumber = new Random();

            int nextNumber = randomNumber.Next(1, this.UpperLimit);

            if (this.NumbersCalled.Contains(nextNumber))
            {
                duplicates.Add(nextNumber);
                GenerateNumber();
            }
            else
            {
                NumbersCalled.Add(nextNumber);
                SortedList.Add(nextNumber);
            }
            
            SortedList.Sort();
        }
    }
}