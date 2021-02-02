using AdventOfCode;
using System;
using System.IO;
using System.Linq;

namespace Question1
{
    public class Part1 : IQuestion
    {
        public void Solve()
        {
            var stringArr = File.ReadAllLines("./Question1/input.txt");
            int[] numbers = stringArr.Select(x => int.Parse(x)).ToArray();

            long result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i != j && numbers[i] + numbers[j] == 2020)
                    {
                        result = numbers[i] * numbers[j];
                        break;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }

}