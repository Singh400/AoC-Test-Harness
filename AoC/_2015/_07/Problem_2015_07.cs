using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace AoC._2015._07
{
    public sealed class Problem_2015_07 : ISolveProblem
    {
        public void Solve()
        {
            string[] partOne = File.ReadAllLines("../../_2015/_07/problem_07_part_one.txt");
            string[] partTwo = File.ReadAllLines("../../_2015/_07/problem_07_part_two.txt");
            Console.WriteLine("Part One: {0}", DoPart(partOne));
            Console.WriteLine("Part Two: {0}", DoPart(partTwo));
        }

        private static int DoPart(string[] input)
        {
            var list = new List<Expression>();
            var dict = new Dictionary<string, int>();

            foreach (var line in input)
            {
                var split = line.Split(new[] {"->"}, StringSplitOptions.None);
                var fullExpression = split[0].Trim();
                var wire = split[1].Trim();
                var bits = fullExpression.Split(' ');

                int value;
                if (int.TryParse(fullExpression, out value))
                {
                    dict.Add(wire, value);
                }

                if (bits.Length == 3)
                {
                    list.Add(new Expression
                    {
                        LeftValue = bits[0],
                        Operation = bits[1],
                        RightValue = bits[2],
                        TargetWire = wire
                    });
                }

                // For NOT expressions only
                if (bits.Length == 2)
                {
                    list.Add(new Expression
                    {
                        Operation = bits[0],
                        RightValue = bits[1],
                        TargetWire = wire
                    });
                }
            }

            while (dict.ContainsKey("lx") == false)
            {
                foreach (var expression in list)
                {
                    if (expression.IsCalculable() && dict.ContainsKey(expression.TargetWire) == false)
                    {
                        var value = expression.Calculate().Value;
                        dict.Add(expression.TargetWire, value);
                    }

                    if (dict.ContainsKey(expression.LeftValue))
                    {
                        expression.LeftValue = dict[expression.LeftValue].ToString();
                    }

                    if (dict.ContainsKey(expression.RightValue))
                    {
                        expression.RightValue = dict[expression.RightValue].ToString();
                    }
                }
            }

            return dict["lx"];
        }
    }

    public sealed class Expression
    {
        public string Operation { get; set; } = string.Empty;
        public string LeftValue { get; set; } = string.Empty;
        public string RightValue { get; set; } = string.Empty;
        public string TargetWire { get; set; } = string.Empty;

        public override string ToString() => $"{LeftValue} {Operation} {RightValue}";

        public bool IsCalculable()
        {
            int right;

            if (Operation.Equals("NOT", StringComparison.OrdinalIgnoreCase))
            {
                return int.TryParse(RightValue, out right);
            }

            int left;
            var isCalculable = int.TryParse(LeftValue, out left) && int.TryParse(RightValue, out right);
            return isCalculable;
        }

        public int? Calculate()
        {
            if (Operation.Equals("OR", StringComparison.OrdinalIgnoreCase))
            {
                return int.Parse(LeftValue) | int.Parse(RightValue);
            }

            if (Operation.Equals("RSHIFT", StringComparison.OrdinalIgnoreCase))
            {
                return int.Parse(LeftValue) >> int.Parse(RightValue);
            }

            if (Operation.Equals("LSHIFT", StringComparison.OrdinalIgnoreCase))
            {
                return int.Parse(LeftValue) << int.Parse(RightValue);
            }

            if (Operation.Equals("AND", StringComparison.OrdinalIgnoreCase))
            {
                return int.Parse(LeftValue) & int.Parse(RightValue);
            }

            if (Operation.Equals("NOT", StringComparison.OrdinalIgnoreCase))
            {
                return ~int.Parse(RightValue);
            }

            return null;
        }
    }
}