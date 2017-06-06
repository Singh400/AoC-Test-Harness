using System;
using System.Collections.Generic;
using System.IO;

namespace AoC._2016._01
{
    public sealed class Problem_2016_01 : ISolveProblem
    {
        public void Solve()
        {
            string input = File.ReadAllText("../../_2016/_01/problem_01.txt");
            Tuple<int, int> process = Process(input);
            Console.WriteLine($"Part One: {process.Item1}");
            Console.WriteLine($"Part Two: {process.Item2}");
        }

        private static Tuple<int, int> Process(string input)
        {
            string[] instructions = input.Split(',');
            Ninja ninja = new Ninja();

            foreach (string instruction in instructions)
            {
                ninja.Move(instruction.Trim());
            }
            
            return new Tuple<int, int>(ninja.LastBlockNumber, ninja.FirstBlockVisitedTwice);
        }
    }

    internal sealed class Ninja
    {
        private char _currentDirection;
        private int _x;
        private int _y;
        private readonly List<string> _locations = new List<string>();

        private const char North = 'N';
        private const char East = 'E';
        private const char South = 'S';
        private const char West = 'W';
        private const char Right = 'R';
        private const char Left = 'L';

        internal Ninja()
        {
            _currentDirection = North;
            _x = 0;
            _y = 0;
        }

        internal void Move(string instruction)
        {
            char turnTo = instruction[0];
            int numberOfBlocks = int.Parse(instruction.Substring(1, instruction.Length - 1));
            
            if (_currentDirection == North)
            {
                if (turnTo == Right)
                {
                    Move(numberOfBlocks, East, () => _x += 1);
                }

                if (turnTo == Left)
                {
                    Move(numberOfBlocks, West, () => _x -= 1);
                }

                return;
            }

            if (_currentDirection == South)
            {
                if (turnTo == Right)
                {
                    Move(numberOfBlocks, West, () => _x -= 1);
                }

                if (turnTo == Left)
                {
                    Move(numberOfBlocks, East, () => _x += 1);
                }

                return;
            }

            if (_currentDirection == East)
            {
                if (turnTo == Right)
                {
                    Move(numberOfBlocks, South, () => _y -= 1);
                }

                if (turnTo == Left)
                {
                    Move(numberOfBlocks, North, () => _y += 1);
                }

                return;
            }

            if (_currentDirection == West)
            {
                if (turnTo == Right)
                {
                    Move(numberOfBlocks, North, () => _y += 1);
                }

                if (turnTo == Left)
                {
                    Move(numberOfBlocks, South, () => _y -= 1);
                }

                return;
            }
        }

        private void Move(int numberOfBlocks, char newDirection, Action modifyPosition)
        {
            for (int i = 0; i < numberOfBlocks; i++)
            {
                modifyPosition.Invoke();
                AuditPosition();
            }

            _currentDirection = newDirection;
        }

        private void AuditPosition()
        {
            if (FirstBlockVisitedTwice != 0)
            {
                return;
            }

            string pos = _x + "," + _y;

            if (_locations.Contains(pos))
            {
                FirstBlockVisitedTwice = LastBlockNumber;
            }
            else
            {
                _locations.Add(pos);
            }
        }

        internal int LastBlockNumber => Math.Abs(_x) + Math.Abs(_y);

        internal int FirstBlockVisitedTwice { get; private set; }
    }
}