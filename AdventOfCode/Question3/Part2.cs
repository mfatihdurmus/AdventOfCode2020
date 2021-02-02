using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Question3
{
    class Part2 : IQuestion
    {
        public void Solve()
        {
            var input = File.ReadAllLines("./Question3/input.txt");

            int yLength = input.Length;
            int xLength = input[0].Length;

            char[,] map = new char[yLength, xLength];

            for (int i = 0; i < yLength; i++)
            {
                var row = input[i].ToCharArray();
                for (int j = 0; j < xLength; j++)
                {
                    map[i, j] = row[j];
                }
            }

            List<Slope> slopes = new List<Slope>();
            slopes.Add(new Slope(1, 1));
            slopes.Add(new Slope(3, 1));
            slopes.Add(new Slope(5, 1));
            slopes.Add(new Slope(7, 1));
            slopes.Add(new Slope(1, 2));

            long product = 1;
            foreach (var slope in slopes)
            {
                int x = 0;
                int y = 0;
                int hitCount = 0;
                while (y < yLength)
                {
                    if (map[y, x] == '#')
                        hitCount++;

                    x = (x + slope.X) % xLength;
                    y = y + slope.Y;
                }
                product *= hitCount;
            }

            Console.WriteLine(product);
        }

        struct Slope
        {
            public Slope(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
