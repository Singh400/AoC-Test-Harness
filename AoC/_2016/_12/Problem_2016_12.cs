using System;
using System.Collections.Generic;
using System.IO;

namespace AoC._2016._12
{
    public class Problem_2016_12 : ISolveProblem
    {
        private string[][] linesSplit;

        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_12/problem_12.txt");
            Setup(lines);
            Console.WriteLine($"Part One: {Part()}");
            Console.WriteLine($"Part Two: {Part(1)}");
        }

        public void Setup(string[] lines)
        {
            linesSplit = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                linesSplit[i] = lines[i].Split();
            }
        }

        public int Part(int valueOfC = 0)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict["a"] = 0;
            dict["b"] = 0;
            dict["c"] = valueOfC;
            dict["d"] = 0;

            for (int index = 0; index < linesSplit.Length; index++)
            {
                string[] parts = linesSplit[index];
                string instruction = parts[0];

                if (instruction == "cpy")
                {
                    int value;

                    if (int.TryParse(parts[1], out value))
                    {
                        dict[parts[2]] = value;
                    }
                    else
                    {
                        dict[parts[2]] = dict[parts[1]];
                    }
                }
                else if (instruction == "inc")
                {
                    dict[parts[1]]++;
                }
                else if (instruction == "dec")
                {
                    dict[parts[1]]--;
                }
                else if (instruction == "jnz")
                {
                    int x;

                    if (int.TryParse(parts[1], out x))
                    {
                    }
                    else
                    {
                        x = dict[parts[1]];
                    }

                    if (x != 0)
                    {
                        if (x < 0)
                        {
                            index++;
                            index -= int.Parse(parts[2]);
                        }

                        if (x > 0)
                        {
                            index--;
                            index += int.Parse(parts[2]);
                        }
                    }
                }
            }

            return dict["a"];
        }
    }
}