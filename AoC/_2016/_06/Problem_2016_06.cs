using System;
using System.Collections.Generic;
using System.IO;

namespace AoC._2016._06
{
    public class Problem_2016_06 : ISolveProblem
    {
        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_06/problem_06.txt");
            Console.WriteLine($"Part One: {Recover(lines, new FindMostCommonLetter())}");
            Console.WriteLine($"Part Two: {Recover(lines, new FindLeastCommonLetter())}");
        }

        public string Recover(string[] lines, IFinder finder)
        {
            int firstLineLength = lines[0].Length;
            char[] message = new char[firstLineLength];

            for (int pos = 0; pos < firstLineLength; pos++)
            {
                foreach (string line in lines)
                {
                    finder.RegisterLetter(line[pos]);
                }

                message[pos] = finder.Execute();
            }

            return new string(message);
        }
    }

    internal sealed class FindMostCommonLetter : IFinder
    {
        private readonly Dictionary<char, int> dict = new Dictionary<char, int>();

        public char Execute()
        {
            int maxOccurs = int.MinValue;
            char theLetter = '\0';

            foreach (KeyValuePair<char, int> pair in dict)
            {
                if (pair.Value > maxOccurs)
                {
                    theLetter = pair.Key;
                    maxOccurs = pair.Value;
                }
            }

            dict.Clear();
            return theLetter;
        }

        public void RegisterLetter(char letter)
        {
            if (dict.ContainsKey(letter))
            {
                dict[letter]++;
            }
            else
            {
                dict[letter] = 1;
            }
        }
    }

    internal sealed class FindLeastCommonLetter : IFinder
    {
        private readonly Dictionary<char, int> dict = new Dictionary<char, int>();

        public char Execute()
        {
            int minOccurs = int.MaxValue;
            char theLetter = '\0';

            foreach (KeyValuePair<char, int> pair in dict)
            {
                if (pair.Value < minOccurs)
                {
                    theLetter = pair.Key;
                    minOccurs = pair.Value;
                }
            }

            dict.Clear();
            return theLetter;
        }

        public void RegisterLetter(char letter)
        {
            if (dict.ContainsKey(letter))
            {
                dict[letter]++;
            }
            else
            {
                dict[letter] = 1;
            }
        }
    }

    public interface IFinder
    {
        char Execute();
        void RegisterLetter(char letter);
    }
}