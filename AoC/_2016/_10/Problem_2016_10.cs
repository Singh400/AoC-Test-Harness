using System;
using System.Collections.Generic;
using System.IO;

namespace AoC._2016._10
{
    public class Problem_2016_10 : ISolveProblem
    {
        private readonly Dictionary<int, Bot> dict = new Dictionary<int, Bot>();

        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_10/problem_10.txt");
            Setup(lines);
            Console.WriteLine($"Part One: {PartOne()}");
            Console.WriteLine($"Part Two: {PartTwo()}");
        }

        public int PartOne()
        {
            bool control = true;
            int answer = -1;

            while (control)
            {
                foreach (KeyValuePair<int, Bot> pair in dict)
                {
                    Bot bot = pair.Value;

                    if (bot.CanProceed)
                    {
                        int high = bot.HighValue;
                        int low = bot.LowValue;

                        if (high == 61 && low == 17)
                        {
                            answer = pair.Key;
                            control = false;
                            break;
                        }

                        dict[bot.HighTo].Take(high);
                        dict[bot.LowTo].Take(low);
                        bot.Clear();
                    }
                }
            }

            return answer;
        }

        public int PartTwo()
        {
            int counter = 0;
            int sum = 1;

            while (counter != 3)
            {
                foreach (KeyValuePair<int, Bot> pair in dict)
                {
                    Bot bot = pair.Value;

                    if (bot.CanProceed)
                    {
                        for (int bin = 0; bin < 3; bin++)
                        {
                            if (bin == bot.OutBinId)
                            {
                                counter++;
                                sum *= bot.LowValue;
                            }
                        }

                        int botIdHigh = bot.HighTo;
                        int botIdLow = bot.LowTo;

                        if (dict.ContainsKey(botIdHigh))
                        {
                            dict[botIdHigh].Take(bot.HighValue);
                        }

                        if (dict.ContainsKey(botIdLow))
                        {
                            dict[botIdLow].Take(bot.LowValue);
                        }

                        bot.Clear();
                    }
                }
            }

            return sum;
        }

        private void AddBot(params int[] ids)
        {
            foreach (int id in ids)
            {
                if (dict.ContainsKey(id) == false)
                {
                    dict[id] = new Bot();
                }
            }
        }

        private void Setup(string[] lines)
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split();

                if (parts[0] == "value")
                {
                    int botId = int.Parse(parts[5]);
                    AddBot(botId);
                    dict[botId].Take(int.Parse(parts[1]));
                }

                if (parts[0] == "bot")
                {
                    int giveBotId = int.Parse(parts[1]);
                    int takeLowBotId = int.Parse(parts[6]);
                    int takeHighBotId = int.Parse(parts[11]);
                    AddBot(giveBotId, takeLowBotId, takeHighBotId);

                    if (parts[3] == "low" && parts[5] == "bot")
                    {
                        dict[giveBotId].LowTo = takeLowBotId;
                    }

                    if (parts[8] == "high" && parts[10] == "bot")
                    {
                        dict[giveBotId].HighTo = takeHighBotId;
                    }

                    if (parts[5] == "output")
                    {
                        dict[giveBotId].OutBinId = takeLowBotId;
                    }
                }
            }
        }
    }

    internal sealed class Bot
    {
        private int _x = -1;
        private int _y = -1;
        internal int LowTo { get; set; } = -1;
        internal int HighTo { get; set; } = -1;
        internal int OutBinId { get; set; } = -1;
        internal int LowValue => Math.Min(_x, _y);
        internal int HighValue => Math.Max(_x, _y);
        internal bool CanProceed => _x != -1 && _y != -1;

        internal void Take(int input)
        {
            if (_x == -1)
            {
                _x = input;
                return;
            }

            if (_y == -1)
            {
                _y = input;
                return;
            }
        }

        internal void Clear()
        {
            _x = -1;
            _y = -1;
        }
    }
}