using System;
using System.Collections.Generic;
using System.IO;

namespace AoC._2015._03
{
    public sealed class Problem_2015_03 : ISolveProblem
    {
        public void Solve()
        {
            var input = File.ReadAllText("../../_2015/_03/problem_03.txt");
            Console.WriteLine("Part One: {0}", PartOne(input));
            Console.WriteLine("Part Two: {0}", PartTwo(input));
        }

        private static int PartOne(string input)
        {
            var list = new HashSet<string>();
            var santa = new Santa();
            list.Add(santa.Position);

            foreach (var instruction in input)
            {
                santa.Move(instruction);
                list.Add(santa.Position);
            }

            return list.Count;
        }

        private static int PartTwo(string input)
        {
            var list = new HashSet<string>();
            var santa = new Santa();
            var roboSanta = new Santa();
            list.Add(santa.Position);
            list.Add(roboSanta.Position);

            for (var i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    santa.Move(input[i]);
                    list.Add(santa.Position);
                }

                if (i % 2 != 0)
                {
                    roboSanta.Move(input[i]);
                    list.Add(roboSanta.Position);
                }
            }

            return list.Count;
        }
    }

    internal sealed class Santa
    {
        private int _x;
        private int _y;

        internal string Position => _x + ", " + _y;

        internal void Move(char input)
        {
            if(input.Equals('>'))
            {
                _x = _x + 1;
            }

            if (input.Equals('<'))
            {
                _x = _x - 1;
            }

            if (input.Equals('^'))
            {
                _y = _y + 1;
            }

            if(input.Equals('v'))
            {
                _y = _y - 1;
            }
        }
    }
}
