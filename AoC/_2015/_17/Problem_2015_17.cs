using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Combinatorics.Collections;

namespace AoC._2015._17
{
    public sealed class Problem_2015_17 : ISolveProblem
    {
        public void Solve()
        {
            var input = File.ReadAllLines("../../_2015/_17/problem_17.txt");
            var partOne = PartOne(input);
            Console.WriteLine("Part One: {0}", partOne.Item1);
            Console.WriteLine("Part Two: {0}", PartTwo(input, partOne.Item2));
        }

        private static int PartTwo(IEnumerable<string> input, int item2)
        {
            var list = input.Select(int.Parse).ToList();
            var permutations = new Combinations<int>(list, item2);
            return permutations.Count(permutation => permutation.Sum() == 150);
        }

        public static Tuple<int, int> PartOne(IEnumerable<string> input)
        {
            var list = input.Select(int.Parse).ToList();
            var counter = 0;
            var min = int.MaxValue;

            for (var x = 1; x <= list.Count; x++)
            {
                var permutations = new Combinations<int>(list, x);

                foreach (var permutation in permutations)
                {
                    if (permutation.Sum() != 150) continue;

                    if (x < min)
                    {
                        min = x;
                    }

                    counter++;
                }
            }
            
            return new Tuple<int, int>(counter, min);
        }
    }
}