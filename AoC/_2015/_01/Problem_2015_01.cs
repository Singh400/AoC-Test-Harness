using System;
using System.IO;

namespace AoC._2015._01
{
    public sealed class Problem_2015_01 : ISolveProblem
    {
        public void Solve()
        {
            string input = File.ReadAllText("../../_2015/_01/problem_01.txt");
            Console.WriteLine("Part One: {0}", PartOne(input));
            Console.WriteLine("Part Two: {0}", PartTwo(input));
        }

        internal static int ParseCharacter(char character) => character.Equals('(') ? 1 : -1;

        internal static int PartOne(string input)
        {
            int result = 0;

            foreach (var instruction in input)
            {
                result += ParseCharacter(instruction);
            }

            return result;
        }

        internal static int PartTwo(string input)
        {
            var currentFloor = 0;
            var index = 0;

            foreach (var instruction in input)
            {
                index++;
                currentFloor += ParseCharacter(instruction);
                if (currentFloor == -1) break;
            }

            return index;
        }
    }
}