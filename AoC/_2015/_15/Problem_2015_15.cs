using System;

namespace AoC._2015._15
{
    public sealed class Problem_2015_15 : ISolveProblem
    {
        public void Solve()
        {
            var partOne = DoPart(false);
            Console.WriteLine($"Part One: {partOne}");
            var partTwo = DoPart(true);
            Console.WriteLine($"Part Two: {partTwo}");
        }

        /// <summary>
        /// Solution improved from: https://www.reddit.com/r/adventofcode/comments/3wwj84/day_15_solutions/cxzhn3c
        /// </summary>
        public static int DoPart(bool limitCalories)
        {
            var max = int.MinValue;

            for (var frosting = 0; frosting <= 100; frosting++)
            {
                for (var candy = 0; candy <= 100; candy++)
                {
                    if (frosting + candy > 100) continue;

                    for (var butterscotch = 0; butterscotch <= 100; butterscotch++)
                    {
                        if (frosting + candy + butterscotch > 100) continue;

                        for (var sugar = 0; sugar <= 100; sugar++)
                        {
                            if (frosting + candy + butterscotch + sugar != 100) continue;

                            int result = Calculation(frosting, candy, butterscotch, sugar, limitCalories);

                            if (result > max)
                            {
                                max = result;
                            }
                        }
                    }
                }
            }

            return max;
        }

        public static int Calculation(int frosting, int candy, int butterscotch, int sugar, bool limitCalories)
        {
            if (limitCalories)
            {
                var calories = (frosting*5) + (candy*8) + (butterscotch*6) + (sugar*1);
                if (calories != 500) return -1;
            }

            var capacity = (frosting*4) + (candy*0) + (butterscotch*-1) + (sugar*0);
            var durability = (frosting*-2) + (candy*5) + (butterscotch*0) + (sugar*0);
            var flavour = (frosting*0) + (candy*-1) + (butterscotch*5) + (sugar*-2);
            var texture = (frosting*0) + (candy*0) + (butterscotch*0) + (sugar*2);

            return Math.Max(capacity, 0)*Math.Max(durability, 0)*Math.Max(flavour, 0)*Math.Max(texture, 0);
        }
    }
}