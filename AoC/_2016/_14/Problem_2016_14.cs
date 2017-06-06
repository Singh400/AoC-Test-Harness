using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Security;

namespace AoC._2016._14
{
    /// <summary>
    /// TODO: Make faster
    /// Part 1 - 75 ms
    /// Part 2 - 11 seconds - most of time is in pre-generating the hashes and caching them.
    /// </summary>
    public class Problem_2016_14 : ISolveProblem
    {
        private const string inputString = "qzyelonm";
        private readonly byte[] InputBytes = Encoding.ASCII.GetBytes(inputString);
        private const string _algorithm = "MD5";
        private const int maxSize = 22000;
        private const char CHAR_EMPTY = '\0';

        public void Solve()
        {
            Console.WriteLine($"Part One: {Part()}");
            Console.WriteLine($"Part Two: {Part(true)}");
        }

        public int Part(bool stretch = false)
        {
            int counter = 0;
            int lastIndex = 0;

            char[][] cache = new char[maxSize][];

            Parallel.For(0, maxSize, index =>
            {
                char[] hash = SpecialHash(Helper.IntToBytes(index));
                char[] hashToCache = stretch ? StretchKey(hash) : hash;
                cache[index] = hashToCache;
            });

            for (int index = 0; index < int.MaxValue; index++)
            {
                if (counter == 64)
                {
                    break;
                }

                char character = HasTriple(cache[index]);

                if (character == CHAR_EMPTY)
                {
                    continue;
                }

                int next1000Index = Next1000HasQuintuple(character, index, cache);

                if (next1000Index == -1)
                {
                    continue;
                }

                counter++;
                lastIndex = index;
            }

            return lastIndex;
        }

        private static char[] StretchKey(char[] array)
        {
            for (int x = 0; x < 2016; x++)
            {
                array = SpecialHash(array);
            }

            return array;
        }

        private static int Next1000HasQuintuple(char character, int i, char[][] cache)
        {
            int max = i + 1000;
            int min = i + 1;

            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Parallel.For(min, max, index =>
            {
                if (HasQuintuple(cache[index], character))
                {
                    bag.Add(index);
                }
            });

            int returnValue = -1;

            if (bag.Count == 0)
            {
                return returnValue;
            }

            if (bag.Count == 1)
            {
                bag.TryTake(out returnValue);
                return returnValue;
            }

            int first = int.MaxValue;

            foreach (var item in bag)
            {
                if (item < first)
                {
                    first = item;
                }
            }

            return first;
        }

        private static bool HasQuintuple(char[] input, char character)
        {
            for (int index = 0; index < input.Length - 4; index++)
            {
                char first = input[index];
                char second = input[index + 1];
                char third = input[index + 2];
                char fourth = input[index + 3];
                char fifth = input[index + 4];

                if (first == character && second == character && third == character && fourth == character &&
                    fifth == character)
                {
                    return true;
                }
            }

            return false;
        }

        private static char HasTriple(char[] input)
        {
            for (int index = 0; index < input.Length - 2; index++)
            {
                char first = input[index];
                char second = input[index + 1];
                char third = input[index + 2];

                if (first == second && first == third)
                {
                    return first;
                }
            }

            return CHAR_EMPTY;
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
            return Helper.ByteArrayToCharArray(bytes);
        }

        private static char[] SpecialHash(char[] charArray)
        {
            byte[] bytesToHash = Encoding.ASCII.GetBytes(charArray);
            byte[] bytes = DigestUtilities.CalculateDigest(_algorithm, bytesToHash);
            return Helper.ByteArrayToCharArray(bytes);
        }
    }
}