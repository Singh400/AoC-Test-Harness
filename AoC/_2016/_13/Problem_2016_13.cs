using System;

namespace AoC._2016._13
{
    public class Problem_2016_13 : ISolveProblem
    {
        private const int length = 41;
        // col == x
        // row == y
        public void Solve()
        {
            
            char[][] floorPlan = new char[length][];

            for (int row = 0; row < floorPlan.Length; row++)
            {
                floorPlan[row] = new char[length];

                for (int col = 0; col < floorPlan[row].Length; col++)
                {
                    int answer = SolveForumale(col, row) + 1350;
                    string binaryAnswer = Convert.ToString(answer, 2);
                    floorPlan[row][col] = WallOrOpen(binaryAnswer);
                }
            }

            floorPlan[1][1] = 'X';
            floorPlan[39][31] = 'X';

            foreach (char[] ints in floorPlan)
            {
                Console.WriteLine(string.Join("", ints));
            }
        }

        public char WallOrOpen(string input)
        {
            int counter = 0;

            foreach (var letter in input)
            {
                if (letter == '1')
                {
                    counter++;
                }
            }

            return counter % 2 == 0 ? '.' : '#';
        }

        public int SolveForumale(int x, int y) => (x * x) + (3 * x) + (2 * x * y) + y + (y * y);
    }
}