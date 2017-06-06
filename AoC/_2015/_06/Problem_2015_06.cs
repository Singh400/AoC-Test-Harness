using System;
using System.IO;

namespace AoC._2015._06
{
    public sealed class Problem_2015_06 : ISolveProblem
    {
        private const int Limit = 1000;

        public void Solve()
        {
            string[] input = File.ReadAllLines("../../_2015/_06/problem_06.txt");
            Tuple<int, int> doPart = DoPart(input);
            Console.WriteLine("Part One: {0}", doPart.Item1);
            Console.WriteLine("Part Two: {0}", doPart.Item2);
        }

        public static Tuple<int, int> DoPart(string[] input)
        {
            Instruction[] instructions = new Instruction[input.Length];

            for (int index = 0; index < input.Length; index++)
            {
                instructions[index] = ParseLine(input[index]);
            }

            int[,] lights = new int[Limit, Limit];
            bool[,] status = new bool[Limit, Limit];

            foreach (Instruction instruction in instructions)
            {
                for (int row = instruction.RowStart; row <= instruction.RowFinish; row++)
                {
                    for (int col = instruction.ColumnStart; col <= instruction.ColumnFinish; col++)
                    {
                        int lite = lights[row, col];
                        bool state = status[row, col];

                        if (instruction.Operation == 1)
                        {
                            state = true;
                            lite += 1;
                        }

                        if (instruction.Operation == 0)
                        {
                            state = false;

                            if (lite > 0)
                            {
                                lite -= 1;
                            }
                        }

                        if (instruction.Operation == 2)
                        {
                            state = !state;
                            lite += 2;
                        }

                        lights[row, col] = lite;
                        status[row, col] = state;
                    }
                }
            }

            var brightnesss = 0;
            var turnedOn = 0;

            for (var row = 0; row < Limit; row++)
            {
                for (var col = 0; col < Limit; col++)
                {
                    brightnesss += lights[row, col];

                    if (status[row, col])
                    {
                        turnedOn++;
                    }
                }
            }

            return new Tuple<int, int>(turnedOn, brightnesss);
        }

        public static Instruction ParseLine(string input)
        {
            var instruction = new Instruction();
            var split = input.Split(' ');
            string[] ons = new string[2];
            string[] offs = new string[2];

            if (input.StartsWith("turn on"))
            {
                ons = split[2].Split(',');
                offs = split[4].Split(',');
                instruction.Operation = 1;
            }

            if (input.StartsWith("turn off"))
            {
                ons = split[2].Split(',');
                offs = split[4].Split(',');
                instruction.Operation = 0;
            }

            if (input.StartsWith("toggle"))
            {
                ons = split[1].Split(',');
                offs = split[3].Split(',');
                instruction.Operation = 2;
            }

            instruction.RowStart = int.Parse(ons[0]);
            instruction.RowFinish = int.Parse(offs[0]);
            instruction.ColumnStart = int.Parse(ons[1]);
            instruction.ColumnFinish = int.Parse(offs[1]);

            return instruction;
        }
    }

    public sealed class Instruction
    {
        public int Operation { get; set; }
        public int ColumnStart { get; set; }
        public int ColumnFinish { get; set; }
        public int RowStart { get; set; }
        public int RowFinish { get; set; }
    }
}