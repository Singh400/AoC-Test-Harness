using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AoC._2015._12
{
    public sealed class Problem_2015_12 : ISolveProblem
    {
        public void Solve()
        {
            var input = File.ReadAllText("../../_2015/_12/problem_12.txt");
            Console.WriteLine("Part One: {0}", PartOne(input));
            Console.WriteLine("Part Two: {0}", PartTwo(input));
        }

        /// <summary>
        /// Solution adapted from: https://www.reddit.com/r/adventofcode/comments/3wh73d/day_12_solutions/cxw7z9h
        /// </summary>
        public static int PartTwo(string input)
        {
            dynamic json = JsonConvert.DeserializeObject(input);
            return GetSum(json, "red");
        }

        public static int PartOne(string input)
        {
            var sb = new StringBuilder(input);
            sb.Replace("[", string.Empty);
            sb.Replace("{", string.Empty);
            sb.Replace("\"", string.Empty);
            sb.Replace(":", string.Empty);
            sb.Replace("}", string.Empty);
            sb.Replace("]", string.Empty);

            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                sb.Replace(letter.ToString(), string.Empty);
            }

            var lines = sb.ToString().Split(',');
            var sum = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                sum = sum + int.Parse(line);
            }

            return sum;
        }

        public static int GetSum(JObject json, string avoid = null)
        {
            var shouldAvoid = json.Properties()
                .Select(a => a.Value).OfType<JValue>()
                .Select(v => v.Value).Contains(avoid);

            if (shouldAvoid) return 0;

            return json.Properties().Sum((dynamic a) => GetSum(a.Value, avoid));
        }

        public static int GetSum(JArray array, string avoid) => array.Sum((dynamic a) => GetSum(a, avoid));

        public static int GetSum(JValue value, string avoid) => value.Type == JTokenType.Integer ? int.Parse(value.Value.ToString()) : 0;
    }
}