using System;
using System.Text;

namespace AoC._2015._10
{
    public sealed class Problem_2015_10 : ISolveProblem
    {
        private const string Input = "1113222113";

        public void Solve()
        {
            Console.WriteLine("Part One: {0}", DoPart(Input, 40));
            Console.WriteLine("Part Two: {0}", DoPart(Input, 50));
        }

        public static int DoPart(string input, int limit)
        {
            for (int x = 0; x < limit; x++)
            {
                input = LookAndSay(input);
            }

            return input.Length;
        }

        public static string LookAndSay(string originalInput)
        {
            var counter = 0;
            var sb = new StringBuilder();
            // This is a dirty hack, otherwise the loop does not read until the end of the input...
            var paddedInput = originalInput + "z";
            var toMatch = paddedInput[0];

            for (var x = 0; x < paddedInput.Length; x++)
            {
                var current = paddedInput[x];

                if (current.Equals(toMatch))
                {
                    counter++;
                }
                else
                {
                    sb.Append(counter);
                    sb.Append(toMatch);
                    counter = 0;
                    x--;
                    toMatch = current;
                }
            }

            return sb.ToString();
        }
    }
}