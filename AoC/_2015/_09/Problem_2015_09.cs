using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Combinatorics.Collections;

namespace AoC._2015._09
{
    public sealed class Problem_2015_09 : ISolveProblem
    {
        public void Solve()
        {
            var input = File.ReadAllLines("../../_2015/_09/problem_09.txt");
            var part = DoPart(input);
            Console.WriteLine("Part One: {0}", part.Item1);
            Console.WriteLine("Part Two: {0}", part.Item2);
        }

        public static Tuple<int, int> DoPart(IEnumerable<string> input)
        {
            var dict = new Dictionary<string, int>();
            var instructions = input.Select(line => new Instruction(line));
            var citiesSet = new HashSet<string>();

            foreach (var instruction in instructions)
            {
                citiesSet.Add(instruction.CityA);
                citiesSet.Add(instruction.CityB);
                dict.Add(instruction.FirstRotation, instruction.Weight);
                dict.Add(instruction.SecondRotation, instruction.Weight);
            }

            var permutations = new Permutations<string>(citiesSet.ToList());
            var max = int.MinValue;
            var min = int.MaxValue;
            var processor = new Processor(dict);

            foreach (var permutation in permutations)
            {
                var result = processor.Do(permutation);

                if (result > max)
                {
                    max = result;
                }

                if (result < min)
                {
                    min = result;
                }
            }

            return new Tuple<int, int>(min, max);
        }
    }

    public sealed class Processor
    {
        private readonly Dictionary<string, int> _dict;

        public Processor(Dictionary<string, int> dict)
        {
            _dict = dict;
        }

        public int Do(IList<string> permutation)
        {
            var counter = 0;

            for (var x = 0; x < permutation.Count; x++)
            {
                if (x + 1 >= permutation.Count) break;
                var format = $"{permutation[x]}, {permutation[x + 1]}";
                counter += _dict[format];
            }

            return counter;
        }
    }

    public sealed class Instruction
    {
        public string CityA { get; }
        public string CityB { get; }
        public int Weight { get; }

        public Instruction(string input)
        {
            string[] parts = input.Split();
            CityA = parts[0];
            CityB = parts[2];
            Weight = int.Parse(parts[4]);
        }

        public string FirstRotation => $"{CityA}, {CityB}";
        public string SecondRotation => $"{CityB}, {CityA}";
    }
}