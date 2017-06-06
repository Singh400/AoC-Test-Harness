using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC._2015._05
{
    public sealed class Problem_2015_05 : ISolveProblem
    {
        private readonly List<char> _vowels = new List<char>{ 'a', 'e', 'i', 'o', 'u' };
        private readonly string[] _badStrings = { "ab", "cd", "pq", "xy" };

        public void Solve()
        {
            string[] input = File.ReadAllLines("../../_2015/_05/problem_05.txt");
            Tuple<int, int> tuple = Part(input);
            Console.WriteLine("Part One: {0}", tuple.Item1);
            Console.WriteLine("Part Two: {0}", tuple.Item2);
        }

        public Tuple<int, int> Part(string[] input)
        {
            int partOneCounter = 0;
            int partTwoCounter = 0;

            foreach (var line in input)
            {
                if (IsANiceStringPartOne(line))
                {
                    partOneCounter++;
                }

                if (IsANiceStringPartTwo(line))
                {
                    partTwoCounter++;
                }
            }

            return new Tuple<int, int>(partOneCounter, partTwoCounter);
        }

        public bool IsANiceStringPartOne(string input) => HasBadStrings(input) == false && HasAtLeastThreeVowels(input) && HasAPairOfLetters(input);

        public bool IsANiceStringPartTwo(string input) => HasDuplicatePairOfLetters(input) && HasAPairOfLettersWithALetterBetween(input);

        public bool HasAtLeastThreeVowels(string input)
        {
            int counter = 0;

            foreach (var letter in input)
            {
                if (_vowels.Contains(letter))
                {
                    counter++;
                }
            }

            return counter >= 3;
        }

        public bool HasAPairOfLetters(string input)
        {
            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                var format = letter.ToString() + letter;

                if (input.Contains(format))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasBadStrings(string input)
        {
            foreach (var badString in _badStrings)
            {
                if (input.Contains(badString))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasDuplicatePairOfLetters(string input)
        {
            var pairs = new List<string>();

            for (var index = 0; index < input.Length; index++)
            {
                if (index + 1 >= input.Length) break;
                var pair = input[index].ToString() + input[index + 1];
                pairs.Add(pair);
            }

            foreach (var pair in pairs)
            {
                var sb = new StringBuilder(input);
                sb.Replace(pair, string.Empty);

                if (input.Length - sb.ToString().Length >= 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasAPairOfLettersWithALetterBetween(string input)
        {
            for (var leftLetter = 'a'; leftLetter <= 'z'; leftLetter++)
            {
                for (var rightLetter = 'a'; rightLetter <= 'z'; rightLetter++)
                {
                    var format = leftLetter.ToString() + rightLetter + leftLetter;

                    if (input.Contains(format))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}