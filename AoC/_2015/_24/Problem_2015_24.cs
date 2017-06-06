using System;
using System.Collections.Generic;
using System.IO;
using Combinatorics.Collections;

namespace AoC._2015._24
{
    public sealed class Problem_2015_24 : ISolveProblem
    {
        public void Solve()
        {
            string[] input = File.ReadAllLines("../../_2015/_24/problem_24.txt");
            Console.WriteLine("Part One: {0}", DoPart(input, 3));
            Console.WriteLine("Part Two: {0}", DoPart(input, 4));
        }

        public static ulong DoPart(string[] input, int numberOfGroups)
        {
            int totalWeight = 0;
            ulong[] things = new ulong[input.Length];

            for (int index = 0; index < input.Length; index++)
            {
                var line = input[index];
                totalWeight += int.Parse(line);
                things[index] = ulong.Parse(line);
            }

            var groupWeight = totalWeight/numberOfGroups;
            IEnumerable<IList<ulong>> permutations = GetLowestCombinationsForSum(things, groupWeight);
            ulong min = ulong.MaxValue;

            foreach (IList<ulong> permutation in permutations)
            {
                int sum = 0;

                foreach (ulong i in permutation)
                {
                    sum += (int) i;
                }

                if (sum == groupWeight)
                {
                    ulong product = 1;

                    foreach (ulong i in permutation)
                    {
                        product *= i;
                    }

                    if (product < min)
                    {
                        min = product;
                    }
                }
            }

            return min;
        }

        public static Combinations<ulong> GetLowestCombinationsForSum(ulong[] list, int sum)
        {
            for (var index = 0; index < list.Length; index++)
            {
                Combinations<ulong> permutations = new Combinations<ulong>(list, index);

                foreach (IList<ulong> permutation in permutations)
                {
                    int total = 0;

                    foreach (var i in permutation)
                    {
                        total += (int) i;
                    }

                    if (total == sum)
                    {
                        return permutations;
                    }
                }
            }

            return new Combinations<ulong>(new List<ulong>(), 0);
        }
    }
}