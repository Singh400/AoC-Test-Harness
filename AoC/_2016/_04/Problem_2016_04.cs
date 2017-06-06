using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC._2016._04
{
    public class Problem_2016_04 : ISolveProblem
    {
        private readonly SortedDictionary<char, int> _dict = new SortedDictionary<char, int>();
        private readonly StringBuilder _sb = new StringBuilder();

        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_04/problem_04.txt");
            Console.WriteLine($"Part One: {PartOne(lines)}");
            Console.WriteLine($"Part Two: {PartTwo(lines)}");
        }

        public int PartOne(string[] lines)
        {
            int counter = 0;

            foreach (string line in lines)
            {
                counter += IsARealRoom(line);
            }

            return counter;
        }

        public int PartTwo(string[] lines)
        {
            int sectorId = 0;

            foreach (string line in lines)
            {
                if (Decrypt(line).Contains("object"))
                {
                    sectorId = int.Parse(line.Substring(line.Length - 10, 3));
                    break;
                }
            }

            return sectorId;
        }

        public string Decrypt(string realRoom)
        {
            char[] encrypted = realRoom.Substring(0, realRoom.Length - 11).ToCharArray();
            int sectorId = int.Parse(realRoom.Substring(realRoom.Length - 10, 3));

            for (int i = 0; i < encrypted.Length; i++)
            {
                for (int j = 0; j < sectorId; j++)
                {
                    char input = encrypted[i];

                    if (input == '-')
                    {
                        continue;
                    }

                    encrypted[i] = IncrementLetter(input);
                }
            }

            return new string(encrypted);
        }

        private static char IncrementLetter(char input)
        {
            if (input == 'z')
            {
                return 'a';
            }

            return (char)(input + 1);
        }

        public int IsARealRoom(string line)
        {
            string originalChecksum = line.Substring(line.Length - 6, 5);
            string encrypted = line.Substring(0, line.Length - 11);

            if (CreateCheckSum(encrypted) == originalChecksum)
            {
                return int.Parse(line.Substring(line.Length - 10, 3));
            }

            return 0;
        }

        public string CreateCheckSum(string input)
        {
            _dict.Clear();
            _sb.Clear();

            foreach (char letter in input)
            {
                if (letter == '-')
                {
                    continue;
                }

                if (_dict.ContainsKey(letter))
                {
                    _dict[letter]++;
                }
                else
                {
                    _dict[letter] = 1;
                }
            }

            while (_sb.Length != 5)
            {
                int highest = int.MinValue;
                char letter = ' ';

                foreach (KeyValuePair<char, int> pair in _dict)
                {
                    if (pair.Value > highest)
                    {
                        highest = pair.Value;
                        letter = pair.Key;
                    }
                }

                _sb.Append(letter);
                _dict.Remove(letter);
            }

            return _sb.ToString();
        }
    }
}