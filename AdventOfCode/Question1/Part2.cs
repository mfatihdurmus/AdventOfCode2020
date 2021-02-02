using AdventOfCode;
using System;
using System.IO;
using System.Linq;

namespace Question1
{
    public class Part2 : IQuestion
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
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (i != j && j != k && i != k
                            && numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            result = numbers[i] * numbers[j] * numbers[k];
                            break;
                        }

                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}