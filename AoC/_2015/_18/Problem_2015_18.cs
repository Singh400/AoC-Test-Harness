using System;
using System.IO;

namespace AoC._2015._18
{
    public class Problem_2015_18 : ISolveProblem
    {
        public void Solve()
        {
            string[] lines = File.ReadAllLines("../../_2015/_18/problem_18.txt");
            Console.WriteLine($"Part One: {PartOne(lines)}");
            Console.WriteLine($"Part Two: {PartTwo(lines)}");

            byte[] bytes = File.ReadAllBytes("../../_2015/_18/problem_18.txt");
            Console.WriteLine($"Part One: {PartOne(bytes)}");
        }

        private int PartOne(byte[] bytes)
        {
            byte[][] startingArray = CreateByteArray();
            int rowStart = 1;
            int byteCounter = 1;

            for (int line = 0; line < bytes.Length; line += 102)
            {
                for (int pos = line; pos < 100 + line; pos++)
                {
                    startingArray[rowStart][byteCounter++] = bytes[pos];
                }

                rowStart++;
                byteCounter = 1;
            }

            for (int x = 0; x < 100; x++)
            {
                byte[][] newCopy = CreateByteArray();

                for (int row = 1; row < startingArray.Length - 1; row++)
                {
                    for (int col = 1; col < startingArray[row].Length - 1; col++)
                    {
                        Decide(row: row, col: col, arrayToRead: startingArray, arrayToWrite: newCopy);
                    }
                }

                SwitchOffBadXs(newCopy);

                startingArray = newCopy;
            }

            return CountLightsOn(startingArray);
        }

        private int PartOne(string[] lines)
        {
            char[][] startingArray = CreateArray();
            int rowStart = 1;

            foreach (string line in lines)
            {
                char[] split = ("X" + line + "X").ToCharArray();
                startingArray[rowStart++] = split;
            }

            for (int x = 0; x < 100; x++)
            {
                char[][] newCopy = CreateArray();

                for (int row = 1; row < startingArray.Length - 1; row++)
                {
                    for (int col = 1; col < startingArray[row].Length - 1; col++)
                    {
                        Decide(row: row, col: col, arrayToRead: startingArray, arrayToWrite: newCopy);
                    }
                }

                SwitchOffBadXs(newCopy);

                startingArray = newCopy;
            }

            return CountLightsOn(startingArray);
        }

        private int PartTwo(string[] lines)
        {
            char[][] startingArray = CreateArray();

            int rowStart = 1;

            foreach (string line in lines)
            {
                char[] split = ("X" + line + "X").ToCharArray();
                startingArray[rowStart++] = split;
            }

            HackCornerLightsOn(startingArray);

            for (int x = 0; x < 100; x++)
            {
                char[][] newCopy = CreateArray();

                for (int row = 1; row < startingArray.Length - 1; row++)
                {
                    for (int col = 1; col < startingArray[row].Length - 1; col++)
                    {
                        Decide(row: row, col: col, arrayToRead: startingArray, arrayToWrite: newCopy);
                    }
                }

                SwitchOffBadXs(newCopy);
                HackCornerLightsOn(newCopy);
                startingArray = newCopy;
            }

            return CountLightsOn(startingArray);
        }

        private void HackCornerLightsOn(char[][] local)
        {
            local[1][1] = '#'; // top left
            local[1][100] = '#'; // top right
            local[100][100] = '#'; // bottom right
            local[100][1] = '#'; // bottom left
        }

        private int CountLightsOn(char[][] local)
        {
            int counter = 0;

            foreach (char[] row in local)
            {
                foreach (char light in row)
                {
                    if (light == '#')
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private int CountLightsOn(byte[][] local)
        {
            int counter = 0;

            foreach (byte[] row in local)
            {
                foreach (byte light in row)
                {
                    if (light == 35)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private void SwitchOffBadXs(char[][] local)
        {
            for (int row = 1; row < local.Length - 1; row++)
            {
                for (int col = 1; col < local[row].Length - 1; col++)
                {
                    if (local[row][col] == 'X')
                    {
                        local[row][col] = '.';
                    }
                }
            }
        }

        private void SwitchOffBadXs(byte[][] local)
        {
            for (int row = 1; row < local.Length - 1; row++)
            {
                for (int col = 1; col < local[row].Length - 1; col++)
                {
                    if (local[row][col] == 88)
                    {
                        local[row][col] = 46;
                    }
                }
            }
        }

        private char[][] CreateArray()
        {
            char[][] local = new char[102][];

            for (int row = 0; row < local.Length; row++)
            {
                local[row] = new char[102];

                for (int col = 0; col < local[row].Length; col++)
                {
                    local[row][col] = 'X';
                }
            }

            return local;
        }

        private byte[][] CreateByteArray()
        {
            byte[][] local = new byte[102][];

            for (int row = 0; row < local.Length; row++)
            {
                local[row] = new byte[102];

                for (int col = 0; col < local[row].Length; col++)
                {
                    local[row][col] = 88;
                }
            }

            return local;
        }

        private void Decide(int row, int col, char[][] arrayToRead, char[][] arrayToWrite)
        {
            char _1 = GetValueOfCell(row - 1, col - 1, arrayToRead);
            char _2 = GetValueOfCell(row - 1, col, arrayToRead);
            char _3 = GetValueOfCell(row - 1, col + 1, arrayToRead);
            char _4 = GetValueOfCell(row, col - 1, arrayToRead);
            char _5 = GetValueOfCell(row, col, arrayToRead);
            char _6 = GetValueOfCell(row, col + 1, arrayToRead);
            char _7 = GetValueOfCell(row + 1, col - 1, arrayToRead);
            char _8 = GetValueOfCell(row + 1, col, arrayToRead);
            char _9 = GetValueOfCell(row + 1, col + 1, arrayToRead);

            char[] loop = {_1, _2, _3, _4, _6, _7, _8, _9};

            int on = 0;

            foreach (char state in loop)
            {
                if (state == '#') // on
                {
                    on++;
                }
            }

            if (_5 == '#') // on
            {
                if (on == 2 || on == 3)
                {
                    arrayToWrite[row][col] = '#'; // on
                }
                else
                {
                    arrayToWrite[row][col] = '.'; // off
                }
            }

            if (_5 == '.') // off
            {
                if (on == 3)
                {
                    arrayToWrite[row][col] = '#';
                }
            }
        }

        private void Decide(int row, int col, byte[][] arrayToRead, byte[][] arrayToWrite)
        {
            byte _1 = GetValueOfCell(row - 1, col - 1, arrayToRead);
            byte _2 = GetValueOfCell(row - 1, col, arrayToRead);
            byte _3 = GetValueOfCell(row - 1, col + 1, arrayToRead);
            byte _4 = GetValueOfCell(row, col - 1, arrayToRead);
            byte _5 = GetValueOfCell(row, col, arrayToRead);
            byte _6 = GetValueOfCell(row, col + 1, arrayToRead);
            byte _7 = GetValueOfCell(row + 1, col - 1, arrayToRead);
            byte _8 = GetValueOfCell(row + 1, col, arrayToRead);
            byte _9 = GetValueOfCell(row + 1, col + 1, arrayToRead);

            byte[] loop = {_1, _2, _3, _4, _6, _7, _8, _9};

            int on = 0;

            foreach (byte state in loop)
            {
                if (state == 35) // on
                {
                    on++;
                }
            }

            if (_5 == 35) // on
            {
                if (on == 2 || on == 3)
                {
                    arrayToWrite[row][col] = 35; // on
                }
                else
                {
                    arrayToWrite[row][col] = 46; // off
                }
            }

            if (_5 == 46) // off
            {
                if (on == 3)
                {
                    arrayToWrite[row][col] = 35;
                }
            }
        }

        private char GetValueOfCell(int row, int col, char[][] arrayToRead) => arrayToRead[row][col];

        private byte GetValueOfCell(int row, int col, byte[][] arrayToRead) => arrayToRead[row][col];
    }
}