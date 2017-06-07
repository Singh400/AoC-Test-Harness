using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AoC._2016._09
{
    public class Problem_2016_09 : ISolveProblem
    {
        public void Solve()
        {
            string line = File.ReadAllText("../../_2016/_09/problem_09.txt");
            string[] lens = File.ReadAllLines("../../_2016/_09/lengths.txt");
            Do(lens);
            string[] times = File.ReadAllLines("../../_2016/_09/times.txt");
            Do(times);
            //Console.WriteLine($"Part One: {PartOne(line)}");
            Console.WriteLine($"Part Two: {Explode(line.ToCharArray())}");
        }

        private void Do(string[] aa)
        {

            BigInteger bi = BigInteger.One;

            foreach (var s in aa)
            {
                bi *= int.Parse(s);
            }

            Console.WriteLine(bi);
        }

        public int PartOne(string originalLine)
        {
            string section = GetNextSection(originalLine);

            if (section == string.Empty)
            {
                return originalLine.Length;
            }

            int section_startPosition = originalLine.IndexOf(section, StringComparison.InvariantCultureIgnoreCase);
            string lineWithoutSection = originalLine.Remove(section_startPosition, section.Length);
            string[] instructions = section.Split(new[] {"x", "(", ")"}, StringSplitOptions.RemoveEmptyEntries);
            int length = int.Parse(instructions[0]);
            int times = int.Parse(instructions[1]);
            string chunkToRepeat = lineWithoutSection.Substring(section_startPosition, length);
            int chunkToRepeat_startPosition = lineWithoutSection.IndexOf(chunkToRepeat, StringComparison.InvariantCultureIgnoreCase);
            string lineWithNoSectionOrRepeat = lineWithoutSection.Remove(chunkToRepeat_startPosition, chunkToRepeat.Length);

            var sb = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                sb.Append('#', chunkToRepeat.Length);
            }

            var decompress = lineWithNoSectionOrRepeat.Insert(chunkToRepeat_startPosition, sb.ToString());
            return PartOne(decompress);
        }

        public string GetNextSection(string line)
        {
            string toReturn = string.Empty;
            bool openSeen = false;
            bool closeSeen = false;

            for (int index = 0; index < line.Length; index++)
            {
                char character = line[index];

                if (openSeen == false && character == '(')
                {
                    openSeen = true;
                    toReturn += character;
                    continue;
                }

                if (closeSeen == false && character == ')')
                {
                    closeSeen = true;
                    toReturn += character;
                    continue;
                }

                if (openSeen && closeSeen)
                {
                    break;
                }

                if (openSeen)
                {
                    toReturn += character;
                }
            }

            return toReturn;
        }

        public SectionDetails GetNextSectionRec(string line, int start = 0)
        {
            string toReturn = string.Empty;
            bool openSeen = false;
            bool closeSeen = false;
            int startSeen = 0;
            int finishedSeen = 0;

            for (int index = start; index < line.Length; index++)
            {
                char character = line[index];

                if (openSeen == false && character == '(')
                {
                    openSeen = true;
                    startSeen = index;
                    toReturn += character;
                    continue;
                }

                if (closeSeen == false && character == ')')
                {
                    closeSeen = true;
                    finishedSeen = index;
                    toReturn += character;
                    continue;
                }

                if (openSeen && closeSeen)
                {
                    if (character == '(')
                    {
                        return GetNextSectionRec(line, index);
                    }

                    break;
                }

                if (openSeen)
                {
                    toReturn += character;
                }
            }

            return new SectionDetails
            {
                FinishPos = finishedSeen,
                Section = toReturn,
                StartPos = startSeen
            };
        }

        public class SectionDetails
        {
            public string Section { get; set; }
            public int StartPos { get; set; }
            public int FinishPos { get; set; }
        }

        public long Explode(char[] line, long times = 1L)
        {
            if (line.Contains('(') == false)
            {
                return line.Length * times;
            }

            long count = 0;

            for (int index = 0; index < line.Length; index++)
            {
                if (line[index] == '(')
                {
                    string marker = new string(line.Skip(index + 1).TakeWhile(ch => ch != ')').ToArray());
                    string[] instructions = marker.Split('x');
                    int length = int.Parse(instructions[0]);
                    int skip = index + marker.Length + 2; // 2 = ()
                    char[] array = line.Skip(skip).Take(length).ToArray();
                    var i = int.Parse(instructions[1]);
                    count += Explode(array, i);
                    //Console.WriteLine($"Marker: {marker} Count {count}");
                    //File.AppendAllText("../../_2016/_09/times.txt", i + Environment.NewLine);
                    index = skip + length - 1;
                }
                else
                {
                    count++;
                }
            }
            //Console.WriteLine(count * times);
            return count*times;
        }
    }
}