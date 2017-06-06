using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Combinatorics.Collections;

namespace AoC._2015._13
{
    public sealed class Problem_2015_13 : ISolveProblem
    {
        public void Solve()
        {
            var partOne = File.ReadAllLines("../../_2015/_13/problem_13_part_one.txt");
            var partTwo = File.ReadAllLines("../../_2015/_13/problem_13_part_two.txt");
            Console.WriteLine("Part One: {0}", DoPart(partOne));
            Console.WriteLine("Part Two: {0}", DoPart(partTwo));
        }

        public static int DoPart(IEnumerable<string> input)
        {
            var peoplesSet = new HashSet<string>();
            var list = input.Select(person => new Instruction(person)).ToList();
            var dict = new Dictionary<string, int>();

            foreach (var instruction in list)
            {
                dict.Add(instruction.ToString(), instruction.Happiness);
                peoplesSet.Add(instruction.FirstPerson);
                peoplesSet.Add(instruction.SecondPerson);
            }

            var permutations = new Permutations<string>(peoplesSet.ToList());
            var max = int.MinValue;
            var processor = new Processor(dict);

            foreach (var permutation in permutations)
            {
                permutation.Add(permutation[0]);
                var result = processor.Do(permutation);

                if (result > max)
                {
                    max = result;
                }
            }

            return max;
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
            var count = 0;

            for (var x = 0; x < permutation.Count; x++)
            {
                if (x + 1 >= permutation.Count) break;
                var leftToRight = $"{permutation[x]}, {permutation[x + 1]}";
                count += _dict[leftToRight];
            }

            var local = permutation.Reverse().ToList();

            for (var x = 0; x < local.Count; x++)
            {
                if (x + 1 >= local.Count) break;
                var leftToRight = $"{local[x]}, {local[x + 1]}";
                count += _dict[leftToRight];
            }

            return count;
        }
    }

    public sealed class Instruction
    {
        public string FirstPerson { get; }
        public string SecondPerson { get; }
        public int Happiness { get; }

        public Instruction(string input)
        {
            FirstPerson = input.Split(' ')[0].Trim();
            SecondPerson = input.Split(' ')[10].Replace(".", string.Empty).Trim();

            if (input.Split(' ')[2].Trim().Equals("lose"))
            {
                Happiness = int.Parse(input.Split(' ')[3].Trim())*-1;
            }
            else
            {
                Happiness = int.Parse(input.Split(' ')[3].Trim());
            }
        }

        public override string ToString() => $"{FirstPerson}, {SecondPerson}";
    }
}