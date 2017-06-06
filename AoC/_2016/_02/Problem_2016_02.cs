using System;
using System.IO;
using System.Text;

namespace AoC._2016._02
{
    public sealed class Problem_2016_02 : ISolveProblem
    {
        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_02/problem_02.txt");
            Console.WriteLine($"Part One: {Process(lines, new SimpleNumberPad())}");
            Console.WriteLine($"Part Two: {Process(lines, new ComplexNumberPad())}");
        }

        public string Process(string[] lines, INumberPad numberPad)
        {
            Ninja ninja = new Ninja(numberPad);
            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                ninja.Process(line);
                sb.Append(ninja.EntryKey);
            }

            return sb.ToString();
        }
    }

    internal sealed class ComplexNumberPad : INumberPad
    {
        private readonly char[][] _numberPad;
        private int _row;
        private int _col;
        private const char Up = 'U';
        private const char Right = 'R';
        private const char Down = 'D';
        private const char Left = 'L';

        public ComplexNumberPad()
        {
            _numberPad = new char[5][];
            _numberPad[0] = new[] {'X', 'X', '1', 'X', 'X'};
            _numberPad[1] = new[] {'X', '2', '3', '4', 'X'};
            _numberPad[2] = new[] {'5', '6', '7', '8', '9'};
            _numberPad[3] = new[] {'X', 'A', 'B', 'C', 'X'};
            _numberPad[4] = new[] {'X', 'X', 'D', 'X', 'X'};
            _row = 2;
            _col = 0;
        }

        public void Process(char letter)
        {
            if (letter == Up)
            {
                if (_row > 0)
                {
                    _row -= 1;

                    if (EntryKey == "X")
                    {
                        _row += 1;
                    }
                }
            }

            if (letter == Right)
            {
                if (_col < 4)
                {
                    _col += 1;

                    if (EntryKey == "X")
                    {
                        _col -= 1;
                    }
                }
            }

            if (letter == Down)
            {
                if (_row < 4)
                {
                    _row += 1;

                    if (EntryKey == "X")
                    {
                        _row -= 1;
                    }
                }
            }

            if (letter == Left)
            {
                if (_col > 0)
                {
                    _col -= 1;

                    if (EntryKey == "X")
                    {
                        _col += 1;
                    }
                }
            }
        }

        public string EntryKey => _numberPad[_row][_col].ToString();
    }

    internal sealed class Ninja
    {
        private readonly INumberPad _numberPad;
        
        internal Ninja(INumberPad numberPad)
        {
            _numberPad = numberPad;
        }

        internal void Process(string line)
        {
            string trimmed = line.Trim();

            foreach (char letter in trimmed)
            {
                _numberPad.Process(letter);
            }
        }

        internal string EntryKey => _numberPad.EntryKey;
    }

    public interface INumberPad
    {
        void Process(char letter);
        string EntryKey { get; }
    }

    internal sealed class SimpleNumberPad : INumberPad
    {
        private readonly int[][] _numberPad = new int[3][];
        private int _row;
        private int _col;
        private const char Up = 'U';
        private const char Right = 'R';
        private const char Down = 'D';
        private const char Left = 'L';

        internal SimpleNumberPad()
        {
            _numberPad[0] = new[] { 1, 2, 3 };
            _numberPad[1] = new[] { 4, 5, 6 };
            _numberPad[2] = new[] { 7, 8, 9 };
            _row = 1;
            _col = 1;
        }

        public void Process(char letter)
        {
            if (letter == Up)
            {
                if (_row > 0)
                {
                    _row -= 1;
                }
            }

            if (letter == Right)
            {
                if (_col < 2)
                {
                    _col += 1;
                }
            }

            if (letter == Down)
            {
                if (_row < 2)
                {
                    _row += 1;
                }
            }

            if (letter == Left)
            {
                if (_col > 0)
                {
                    _col -= 1;
                }
            }
        }

        public string EntryKey => _numberPad[_row][_col].ToString();
    }
}