using System;
using System.Collections.Generic;
using System.IO;

namespace AoC._2016._07
{
    public class Problem_2016_07 : ISolveProblem
    {
        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_07/problem_07.txt");
            Tuple<int, int> doPart = DoPart(lines);
            Console.WriteLine($"Part One: {doPart.Item1}");
            Console.WriteLine($"Part Two: {doPart.Item2}");
        }

        private Tuple<int, int> DoPart(string[] lines)
        {
            int tlsCounter = 0;
            int sslCounter = 0;

            foreach (string line in lines)
            {
                if (SupportTls(line))
                {
                    tlsCounter++;
                }

                if (SupportsSsl(line))
                {
                    sslCounter++;
                }
            }

            return new Tuple<int, int>(tlsCounter, sslCounter);
        }

        private static string[] ParseLine(string line) => line.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

        public bool SupportTls(string line)
        {
            string[] parts = ParseLine(line);
            int outside = 0;

            for (int i = 0; i < parts.Length; i += 2)
            {
                outside += FindABBAs(parts[i]);
            }

            int inside = 0;

            for (int i = 1; i < parts.Length; i += 2)
            {
                inside += FindABBAs(parts[i]);
            }

            return outside > 0 && inside == 0;
        }

        public bool SupportsSsl(string line)
        {
            string[] parts = ParseLine(line);
            List<string> outside = new List<string>();

            for (int i = 0; i < parts.Length; i += 2)
            {
                outside.AddRange(FindABAs(parts[i]));
            }

            List<string> inside = new List<string>();

            for (int i = 1; i < parts.Length; i += 2)
            {
                inside.AddRange(FindABAs(parts[i]));
            }

            bool result = MeetsSslCriteria(outside, inside);
            return result;
        }

        private bool MeetsSslCriteria(IList<string> outsideList, IList<string> insideList)
        {
            bool matchingPairs = false;

            for (int outsideIndex = 0; outsideIndex < outsideList.Count; outsideIndex++)
            {
                string outside = outsideList[outsideIndex]; // aba
                char out1 = outside[0]; // a
                char out2 = outside[1]; // b
                // char out3 = outside[2]; // a

                for (int insideIndex = 0; insideIndex < insideList.Count; insideIndex++)
                {
                    string inside = insideList[insideIndex]; // bab
                    char in1 = inside[0]; // b
                    char in2 = inside[1]; // a
                    // char in3 = inside[2]; // b

                    if (out1 == in2 && out2 == in1)
                    {
                        matchingPairs = true;
                        break;
                    }
                }

                if (matchingPairs)
                {
                    break;
                }
            }

            return matchingPairs;
        }

        private static List<string> FindABAs(string input)
        {
            List<string> list = new List<string>();

            for (int index = 0; index < input.Length - 2; index++)
            {
                char first = input[index]; // a
                char second = input[index + 1]; // b
                char third = input[index + 2]; // a

                if (first == third && first != second)
                {
                    list.Add(string.Join(string.Empty, first, second, third));
                }
            }

            return list;
        }

        private static int FindABBAs(string input)
        {
            int counter = 0;

            for (int index = 0; index < input.Length - 3; index++)
            {
                char first = input[index]; // a
                char second = input[index + 1]; // b
                char third = input[index + 2]; // b
                char fourth = input[index + 3]; // a

                if (first == fourth && second == third && first != second)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}