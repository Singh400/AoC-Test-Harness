using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC._2015._14
{
    public sealed class Problem_2015_14 : ISolveProblem
    {
        public void Solve()
        {
            var input = File.ReadAllLines("../../_2015/_14/problem_14.txt");
            var part = DoPart(input);
            Console.WriteLine("Part One: {0}", part.Item1);
            Console.WriteLine("Part Two: {0}", part.Item2);
        }

        public static Tuple<int, int> DoPart(IEnumerable<string> input)
        {
            var reindeers = input.Select(line => new Reindeer(line)).ToList();

            for (var x = 1; x <= 2503; x++)
            {
                foreach (var reindeer in reindeers)
                {
                    reindeer.Fly();
                }

                reindeers = UpdateScores(reindeers);
            }

            var mostDistance = reindeers.Max(x => x.DistanceTravelled);
            var mostPoints = reindeers.Max(x => x.Points);
            return new Tuple<int, int>(mostDistance, mostPoints);
        }

        public static List<Reindeer> UpdateScores(List<Reindeer> reindeers)
        {
            var max = reindeers.Max(x => x.DistanceTravelled);

            foreach (var reindeer in reindeers)
            {
                if (reindeer.DistanceTravelled == max)
                {
                    reindeer.Points++;
                }
            }

            return reindeers;
        }
    }

    public sealed class Reindeer
    {
        private int KilometersPerSecond { get; }
        private int MaxFlightDuration { get; }
        private int _currentFlightDuration;
        private int RestDuration { get; }
        private int _currentRestDuration;
        public int DistanceTravelled { get; private set; }
        public int Points { get; set; }
        private bool _canFly = true;

        public Reindeer(string input)
        {
            var split = input.Split(' ');
            KilometersPerSecond = int.Parse(split[3]);
            MaxFlightDuration = int.Parse(split[6]);
            _currentFlightDuration = int.Parse(split[6]);
            RestDuration = int.Parse(split[13]);
            _currentRestDuration = int.Parse(split[13]);
        }

        public void Fly()
        {
            if (_canFly)
            {
                DistanceTravelled = KilometersPerSecond + DistanceTravelled;
                _currentFlightDuration--;

                if (_currentFlightDuration == 0)
                {
                    _canFly = false;
                    _currentFlightDuration = MaxFlightDuration;
                }
            }
            else
            {
                _currentRestDuration--;

                if (_currentRestDuration == 0)
                {
                    _canFly = true;
                    _currentRestDuration = RestDuration;
                }
            }
        }
    }
}
