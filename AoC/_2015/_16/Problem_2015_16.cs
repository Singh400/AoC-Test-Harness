using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC._2015._16
{
    public sealed class Problem_2015_16 : ISolveProblem
    {
        public void Solve()
        {
            var input = File.ReadAllLines("../../_2015/_16/problem_16.txt");
            Console.WriteLine("Part One: {0}", PartOne(input));
            Console.WriteLine("Part Two: {0}", PartTwo(input));
        }

        private static string PartTwo(IEnumerable<string> input)
        {
            var sues = input.Select(line => new Sue(line)).ToList();
            var exactMatches = new Dictionary<string, int>();
            exactMatches.Add("children", 3);
            exactMatches.Add("samoyeds", 2);
            exactMatches.Add("akitas", 0);
            exactMatches.Add("vizslas", 0);
            exactMatches.Add("cars", 2);
            exactMatches.Add("perfumes", 1);

            var fewerMatches = new Dictionary<string, int>();
            fewerMatches.Add("pomeranians", 3);
            fewerMatches.Add("goldfish", 5);

            var greaterMatches = new Dictionary<string, int>();
            greaterMatches.Add("cats", 7);
            greaterMatches.Add("trees", 3);

            var toReturn = string.Empty;

            foreach (var sue in sues)
            {
                var counter = 0;

                foreach (var key in exactMatches.Keys)
                {
                    if (sue.Properties.ContainsKey(key) && sue.Properties[key] == exactMatches[key])
                    {
                        counter++;
                    }
                }

                foreach (var key in greaterMatches.Keys)
                {
                    if (sue.Properties.ContainsKey(key) && sue.Properties[key] > greaterMatches[key])
                    {
                        counter++;
                    }
                }

                foreach (var key in fewerMatches.Keys)
                {
                    if (sue.Properties.ContainsKey(key) && sue.Properties[key] < fewerMatches[key])
                    {
                        counter++;
                    }
                }

                if (counter >= 3)
                {
                    toReturn = sue.Name;
                }
            }

            return toReturn;
        }

        private static string PartOne(IEnumerable<string> input)
        {
            var sues = input.Select(line => new Sue(line)).ToList();

            var exactMatches = new Dictionary<string, int>();
            exactMatches.Add("children", 3);
            exactMatches.Add("samoyeds", 2);
            exactMatches.Add("akitas", 0);
            exactMatches.Add("vizslas", 0);
            exactMatches.Add("cars", 2);
            exactMatches.Add("perfumes", 1);
            exactMatches.Add("trees", 3);
            exactMatches.Add("goldfish", 5);
            exactMatches.Add("pomeranians", 3);
            exactMatches.Add("cats", 7);

            var toReturn = string.Empty;

            foreach (var sue in sues)
            {
                var counter = 0;

                foreach (var key in exactMatches.Keys)
                {
                    if (sue.Properties.ContainsKey(key) && sue.Properties[key] == exactMatches[key])
                    {
                        counter++;
                    }
                }

                if (counter >= 3)
                {
                    toReturn = sue.Name;
                }
            }

            return toReturn;
        }
    }

    public sealed class Sue
    {
        public string Name { get; set; }
        public Dictionary<string, int> Properties = new Dictionary<string, int>();

        public Sue(string input)
        {
            var dump = input.Replace(",", ":").Split(':');
            Name = dump[0].Trim();
            Properties.Add(dump[1].Trim(), int.Parse(dump[2].Trim()));
            Properties.Add(dump[3].Trim(), int.Parse(dump[4].Trim()));
            Properties.Add(dump[5].Trim(), int.Parse(dump[6].Trim()));
        }
    }
}