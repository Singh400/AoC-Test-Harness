using System;
using System.IO;

namespace AoC._2016._03
{
    public sealed class Problem_2016_03 : ISolveProblem
    {
        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_03/problem_03.txt");
            Console.WriteLine($"Part One: {PartOne(lines)}");
            Console.WriteLine($"Part Two: {PartTwo(lines)}");
        }

        private static int PartOne(string[] lines)
        {
            int counter = 0;

            foreach (string line in lines)
            {
                int[] parts = ParseLine(line);

                if (IsValidTrangle(parts[0], parts[1], parts[2]))
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int PartTwo(string[] lines)
        {
            int counter = 0;

            for (int index = 0; index < lines.Length; index += 3)
            {
                int[] firstLine = ParseLine(lines[index]);
                int[] secondLine = ParseLine(lines[index + 1]);
                int[] thirdLine = ParseLine(lines[index + 2]);

                for (int x = 0; x < firstLine.Length; x++)
                {
                    if (IsValidTrangle(firstLine[x], secondLine[x], thirdLine[x]))
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static int[] ParseLine(string line)
        {
            string[] strings = line.Trim().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            int[] nums = new int[strings.Length];

            for (int index = 0; index < strings.Length; index++)
            {
                nums[index] = int.Parse(strings[index].Trim());
            }

            return nums;
        }

        private static bool IsValidTrangle(int a, int b, int c) => a + b > c && a + c > b && b + c > a;
    }
}