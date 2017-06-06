using System;
using System.Collections.Generic;
using System.IO;

namespace AoC._2016._08
{
    public class Problem_2016_08 : ISolveProblem
    {
        private readonly char[][] array = new char[numberOfRows][];
        private const int numberOfColumns = 50;
        private const int numberOfRows = 6;

        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2016/_08/problem_08.txt");
            Setup();
            Console.WriteLine($"Part One: {PartOne(lines)}");
            Console.WriteLine("Part Two:");
            PrintArray();
        }

        private void Setup()
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                array[row] = new char[numberOfColumns];

                for (int col = 0; col < numberOfColumns; col++)
                {
                    array[row][col] = '.';
                }
            }
        }

        private static string[] SplitBy(string input, string seperator) => input.Split(new[] {seperator}, StringSplitOptions.RemoveEmptyEntries);

        private int PartOne(string[] lines)
        {
            int sum = 0;

            foreach (string line in lines)
            {
                string[] parts = SplitBy(line, " ");
                string instruction = parts[1];

                if (parts.Length == 2)
                {
                    string[] ab = SplitBy(instruction, "x");
                    int columnsWide = int.Parse(ab[0]);
                    int rowsLong = int.Parse(ab[1]);
                    sum += columnsWide*rowsLong;
                    DrawRec(rowsLong, columnsWide);
                    continue;
                }

                int loopMax = int.Parse(parts[4]);
                int id = int.Parse(SplitBy(parts[2], "=")[1]);
                Action colAction = () => ShiftColumnDown(id, loopMax);
                Action rowAction = () => ShiftRowRight(id, loopMax);
                Action actionToTake = instruction == "row" ? rowAction : colAction;
                actionToTake.Invoke();
            }

            return sum;
        }

        private void ShiftRowRight(int row, int loopMax)
        {
            List<char> list = new List<char>();

            for (int x = 0; x < loopMax; x++)
            {
                list.Add('.');
            }

            for (int index = 0; index < array[row].Length; index++)
            {
                char[] col = array[row];
                list.Add(col[index]);
                col[index] = '.';
            }

            while (list.Count != 0)
            {
                for (int index = 0; index < array[row].Length; index++)
                {
                    if (list.Count == 0)
                    {
                        break;
                    }

                    array[row][index] = list[0];
                    list.RemoveAt(0);
                }
            }
        }

        private void ShiftColumnDown(int col, int loopMax)
        {
            List<char> list = new List<char>();

            for (int x = 0; x < loopMax; x++)
            {
                list.Add('.');
            }

            for (int index = 0; index < array.Length; index++)
            {
                char[] row = array[index];
                list.Add(row[col]);
                row[col] = '.';
            }

            while (list.Count != 0)
            {
                for (int index = 0; index < array.Length; index++)
                {
                    if (list.Count == 0)
                    {
                        break;
                    }

                    array[index][col] = list[0];
                    list.RemoveAt(0);
                }
            }
        }

        private void PrintArray()
        {
            foreach (char[] row in array)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private void DrawRec(int row, int col)
        {
            for (int y = 0; y < row; y++)
            {
                for (int x = 0; x < col; x++)
                {
                    array[y][x] = '#';
                }
            }
        }
    }
}