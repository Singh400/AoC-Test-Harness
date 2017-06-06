using System;
using System.Text;
using Org.BouncyCastle.Security;

namespace AoC._2015._04
{
    /// <summary>
    /// TODO: Make faster
    /// Part 1 - 104 ms
    /// Part 2 - 3 seconds
    /// </summary>
    public sealed class Problem_2015_04 : ISolveProblem
    {
        private const string Input = "ckczppom";
        private const string _algorithm = "MD5";
        private const int f_size = 3;
        private readonly byte[] InputBytes = Encoding.ASCII.GetBytes(Input);

        public void Solve()
        {
            Console.WriteLine($"Part One: {DoPart(5)}");
            Console.WriteLine($"Part Two: {DoPart(6)}");
        }

        private int DoPart(int size)
        {
            for (int index = 0; index < int.MaxValue; index++)
            {
                char[] hash = SpecialHash(Helper.IntToBytes(index));

                int counter = 0;

                for (int x = 0; x < size; x++)
                {
                    if (hash[x] == '0')
                    {
                        counter++;
                    }
                }

                if (counter == size)
                {
                    return index;
                }
            }

            return 0;
        }

        private char[] SpecialHash(byte[] intInBytes)
        {
            int totalLength = InputBytes.Length + intInBytes.Length;
            byte[] bytesToHash = new byte[totalLength];
            int pos = 0;

            foreach (byte b in InputBytes)
            {
                bytesToHash[pos++] = b;
            }

            foreach (byte b in intInBytes)
            {
                bytesToHash[pos++] = b;
            }

            byte[] bytes = DigestUtilities.CalculateDigest(_algorithm, bytesToHash);
            char[] result = new char[f_size*2];

            if (bytes[0] != 0 || bytes[1] != 0)
                return result;

            return Helper.ByteArrayToCharArray(bytes);
        }
    }
}