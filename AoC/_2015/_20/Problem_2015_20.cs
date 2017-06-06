using System;
using System.Collections.Generic;

namespace AoC._2015._20
{
    public class Problem_2015_20 : ISolveProblem
    {
        private const int _numberOfPresents = 34000000;

        public void Solve()
        {
            Console.WriteLine($"Part One: {PartOne()}");
            Console.WriteLine($"Part Two: {PartTwo()}");
        }

        public int PartOne()
        {
            for (int houseNumber = 1; houseNumber < int.MaxValue; houseNumber++)
            {
                List<int> elves = GetElvesThatVisitedHouseNumber(houseNumber);

                int numberOfPresents = 0;

                foreach (int elf in elves)
                {
                    numberOfPresents += elf * 10;
                }

                if (numberOfPresents >= _numberOfPresents)
                {
                    return houseNumber;
                }
            }

            return 0;
        }

        public int PartTwo()
        {
            Dictionary<int, int> elfTracker = new Dictionary<int, int>(); // elf, times

            for (int houseNumber = 1; houseNumber < int.MaxValue; houseNumber++)
            {
                List<int> elves = GetElvesThatVisitedHouseNumber(houseNumber);

                int numberOfPresents = 0;

                foreach (int elf in elves)
                {
                    if (elfTracker.ContainsKey(elf) == false)
                    {
                        elfTracker[elf] = 0;
                    }

                    elfTracker[elf]++;

                    if (elfTracker[elf] < 50)
                    {
                        numberOfPresents += elf * 11;
                    }
                }

                if (numberOfPresents >= _numberOfPresents)
                {
                    return houseNumber;
                }
            }

            return 0;
        }

        // http://stackoverflow.com/a/239877
        public List<int> GetElvesThatVisitedHouseNumber(int number)
        {
            List<int> factors = new List<int>();

            int max = (int) Math.Sqrt(number);

            for (int factor = 1; factor <= max; factor++)
            {
                if (number%factor == 0)
                {
                    factors.Add(factor);

                    int item = number/factor;

                    if (factor != item)
                    {
                        factors.Add(item);
                    }
                }
            }

            return factors;
        }
    }
}