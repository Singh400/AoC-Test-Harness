using System;
using System.Text;
using Org.BouncyCastle.Security;

namespace AoC._2016._05
{
    /// <summary>
    /// TODO: Make faster
    /// Part 1 - 7 seconds
    /// Part 2 - 21 seconds
    /// </summary>
    public class Problem_2016_05 : ISolveProblem
    {
        private const string _algorithm = "MD5";
        private const char CHAR_ZERO = '0';
        private const int zeroesRequired = 5;
        private const string inputString = "wtnhxymk";
        private readonly byte[] InputBytes = Encoding.ASCII.GetBytes(inputString);

        public void Solve()
        {
            Console.WriteLine($"Part One: {PartOne()}");
            Console.WriteLine($"Part Two: {PartTwo()}");
        }

        private string PartOne()
        {
            char[] password = new char[8];
            int found = 0;

            for (int index = 0; index < int.MaxValue; index++)
            {
                if (found >= 8)
                {
                    break;
                }

                char[] result = SpecialHash(Helper.IntToBytes(index));

                if (result.Length == 0)
                {
                    continue;
                }

                int numberOfZeroes = 0;

                for (int i = 0; i < zeroesRequired; i++)
                {
                    if (result[i] == CHAR_ZERO)
                    {
                        numberOfZeroes++;
                    }
                }

                if (numberOfZeroes == zeroesRequired)
                {
                    password[found++] = result[5];
                }
            }

            return new string(password);
        }

        private string PartTwo()
        {
            char[] password = new char[8];
            int found = 0;

            for (int index = 0; index < int.MaxValue; index++)
            {
                if (found >= 8)
                {
                    break;
                }

                char[] result = SpecialHash(Helper.IntToBytes(index));

                if (result.Length == 0)
                {
                    continue;
                }

                int numberOfZeroes = 0;

                for (int i = 0; i < zeroesRequired; i++)
                {
                    if (result[i] == CHAR_ZERO)
                    {
                        numberOfZeroes++;
                    }
                }

                if (numberOfZeroes == zeroesRequired)
                { 
                    int local;

                    if (int.TryParse(result[5].ToString(), out local))
                    {
                        if (local < 8 && password[local] == '\0')
                        {
                            password[local] = result[6];
                            found++;
                        }
                    }
                }
            }

            return new string(password);
        }

        private char[] SpecialHash(byte[] intInBytes)
        { 
            int totalLength = InputBytes.Length + intInBytes.Length;
            byte[] bytesToHash = new byte[totalLength];
            int pos = 0;

            foreach (var b in InputBytes)
            {
                bytesToHash[pos++] = b;
            }

            foreach (var b in intInBytes)
            {
                bytesToHash[pos++] = b;
            }

            byte[] bytes = DigestUtilities.CalculateDigest(_algorithm, bytesToHash);

            if (bytes[0] != 0 || bytes[1] != 0)
                return new char[0];

            return Helper.ByteArrayToCharArray(bytes);
        }
    }
}