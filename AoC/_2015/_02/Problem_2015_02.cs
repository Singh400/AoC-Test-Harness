using System;
using System.IO;

namespace AoC._2015._02
{
    public sealed class Problem_2015_02 : ISolveProblem
    {
        public void Solve()
        {
            string[] input = File.ReadAllLines("../../_2015/_02/problem_02.txt");
            Tuple<int, int> doPart = DoPart(input);
            Console.WriteLine("Part One: {0}", doPart.Item1);
            Console.WriteLine("Part Two: {0}", doPart.Item2);
        }

        private static Tuple<int, int> DoPart(string[] input)
        {
            int wrappingPaper = 0;
            int ribbonNeeded = 0;

            foreach (string s in input)
            {
                Dimension dim = new Dimension(s);
                wrappingPaper += dim.SurfaceArea();
                ribbonNeeded += dim.RibbonNeeded();
            }

            return new Tuple<int, int>(wrappingPaper, ribbonNeeded);
        }
    }

    internal sealed class Dimension
    {
        private readonly int _length;
        private readonly int _width;
        private readonly int _height;
        private readonly int[] _nums;

        internal Dimension(string test)
        {
            string[] x = test.Split('x');
            _length = int.Parse(x[0]);
            _width = int.Parse(x[1]);
            _height = int.Parse(x[2]);
            _nums = new[] {_length, _width, _height};
            Array.Sort(_nums);
        }

        internal int SurfaceArea()
        {
            var a = _length * _width;
            var b = _width * _height;
            var c = _height * _length;
            int[] local = {a, b, c};
            Array.Sort(local);
            var smallest = local[0];
            return 2*a + 2*b + 2*c + smallest;
        }

        internal int RibbonNeeded()
        {
            var ribbon = _nums[0]*2 + _nums[1]*2;
            var sum = _length*_width*_height;
            return ribbon + sum;
        }
    }
}