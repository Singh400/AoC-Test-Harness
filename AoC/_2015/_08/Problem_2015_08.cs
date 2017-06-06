using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC._2015._08
{
    public sealed class Problem_2015_08 : ISolveProblem
    {
        public void Solve()
        {
            var input = File.ReadAllLines("../../_2015/_08/problem_08.txt");
            Console.WriteLine("Part One: {0}", PartOne(input));
            Console.WriteLine("Part Two: {0}", PartTwo(input));
        }

        public static int DetectSpecialCharacters(string input)
        {
            var counter = input.Length;

            foreach (var character in input)
            {
                if (character.Equals('\\'))
                {
                    counter = counter + 1;
                }

                if (character.Equals('\"'))
                {
                    counter = counter + 1;
                }
            }

            return counter + 2;
        }

        public static int PartTwo(IEnumerable<string> input)
        {
            var newTotal = 0;
            var oldTotal = 0;

            foreach (var line in input)
            {
                var newLength = DetectSpecialCharacters(line);
                var oldLength = line.Length;
                newTotal += newLength;
                oldTotal += oldLength;
            }

            return newTotal - oldTotal;
        }

        public static int PartOne(IEnumerable<string> input)
        {
            var literal = 0;
            var actual = 0;

            foreach (var line in input)
            {
                var x = Regex.Unescape(line);
                literal = literal + line.Length;
                actual = actual + (x.Length - 2);
            }

            return literal - actual;
        }
    }
}