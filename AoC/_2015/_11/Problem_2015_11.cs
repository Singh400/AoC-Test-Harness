using System;
using System.Collections.Generic;

namespace AoC._2015._11
{
    public sealed class Problem_2015_11 : ISolveProblem
    {
        private readonly HashSet<string> _threeLettersInARow = new HashSet<string>();
        private readonly HashSet<string> _pairs = new HashSet<string>();
        private readonly string[] _illegal = {"i", "o", "l"};

        public Problem_2015_11()
        {
            FillList();
        }

        public void Solve()
        {
            Console.WriteLine("Part One: {0}", GetNextPassword("cqjxjnds"));
            Console.WriteLine("Part Two: {0}", GetNextPassword("cqjxxyzz"));
        }

        private void FillList()
        {
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                if (letter > 'x')
                {
                    break;
                }

                _threeLettersInARow.Add(char.ConvertFromUtf32(letter) + char.ConvertFromUtf32(letter + 1) + char.ConvertFromUtf32(letter + 2));
            }

            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                _pairs.Add(char.ConvertFromUtf32(letter) + char.ConvertFromUtf32(letter));
            }
        }

        public bool HasThreeLetterInARow(string value)
        {
            foreach (var threeLettersInArow in _threeLettersInARow)
            {
                if (value.Contains(threeLettersInArow))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasIllegalLetters(string value)
        {
            foreach (var illegal in _illegal)
            {
                if (value.Contains(illegal))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasPairs(string value)
        {
            int counter = 0;

            foreach (var pair in _pairs)
            {
                if (value.Contains(pair))
                {
                    counter++;
                }
            }

            return counter >= 2;
        }

        public string GetNextPassword(string oldPassword)
        {
            string properPassword;

            while (true)
            {
                var newpassword = Increment(oldPassword);

                if (HasThreeLetterInARow(newpassword) == false)
                {
                    oldPassword = newpassword;
                    continue;
                }

                if (HasIllegalLetters(newpassword) == true)
                {
                    oldPassword = newpassword;
                    continue;
                }

                if (HasPairs(newpassword) == false)
                {
                    oldPassword = newpassword;
                    continue;
                }

                properPassword = newpassword;
                break;
            }

            return properPassword;
        }

        public string Increment(string value)
        {
            char[] chars = value.ToCharArray();
            int lastPos = chars.Length - 1;

            while (true)
            {
                var input = chars[lastPos];

                chars[lastPos] = IncrementLetter(input);

                if (IncrementLetter(input) == 'a')
                {
                    lastPos--;
                }
                else
                {
                    break;
                }
            }

            return new string(chars);
        }

        private static char IncrementLetter(char input)
        {
            if (input == 'z')
            {
                return 'a';
            }

            return (char) (input + 1);
        }
    }
}