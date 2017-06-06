using System;
using System.IO;

namespace AoC._2015._23
{
    public class Problem_2015_23 : ISolveProblem
    {
        private string[][] cleansedLines;

        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2015/_23/problem_23.txt");
            Setup(lines);
            Console.WriteLine("Part One: {0}", DoPart());
            Console.WriteLine("Part Two: {0}", DoPart(1));
        }

        private void Setup(string[] lines)
        {
            cleansedLines = new string[lines.Length][];

            for (int index = 0; index < lines.Length; index++)
            {
                string line = lines[index];

                if (line.Contains(","))
                {
                    line = line.Replace(",", string.Empty);
                }

                cleansedLines[index] = line.Split();
            }
        }

        public int DoPart(uint valueOfA = 0)
        {
            int b = 0;

            for (int index = 0; index < cleansedLines.Length; index++)
            {
                string[] dump = cleansedLines[index];
                string instruction = dump[0];
                string register = dump[1];

                if (instruction.Equals("hlf"))
                {
                    if (register.Equals("a"))
                    {
                        valueOfA /= 2;
                    }
                }
                else if (instruction.Equals("tpl"))
                {
                    if (register.Equals("a"))
                    {
                        valueOfA *= 3;
                    }
                }
                else if (instruction.Equals("inc"))
                {
                    if (register.Equals("a"))
                    {
                        valueOfA++;
                    }
                    else if (register.Equals("b"))
                    {
                        b++;
                    }
                }
                else if (instruction.Equals("jmp"))
                {
                    index--;
                    index += int.Parse(dump[1]);
                }
                else if (instruction.Equals("jie"))
                {
                    if (register.Equals("a") && valueOfA % 2 == 0)
                    {
                        index--;
                        index += int.Parse(dump[2]);
                    }
                }
                else if (instruction.Equals("jio"))
                {
                    if (register.Equals("a") && valueOfA == 1)
                    {
                        index--;
                        index += int.Parse(dump[2]);
                    }
                }
            }

            return b;
        }
    }
}