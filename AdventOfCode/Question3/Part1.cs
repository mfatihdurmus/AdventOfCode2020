using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Question3
{
    class Part1 : IQuestion
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

            int x = 0;
            int y = 0;
            int hitCount = 0;
            while (y < yLength)
            {
                if (map[y, x] == '#')
                    hitCount++;

                x = (x + 3) % xLength;
                y = y + 1;
            }

            Console.WriteLine(hitCount);
        }
    }
}
