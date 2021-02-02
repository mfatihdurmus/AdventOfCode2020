using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Question1.Part1 q1part1 = new Question1.Part1();
            q1part1.Solve();

            Question1.Part2 q1part2 = new Question1.Part2();
            q1part2.Solve();

            Question2.Part1 q2part1 = new Question2.Part1();
            q2part1.Solve();

            Question2.Part2 q2part2 = new Question2.Part2();
            q2part2.Solve();

            Question3.Part1 q3part1 = new Question3.Part1();
            q3part1.Solve();

            Question3.Part2 q3part2 = new Question3.Part2();
            q3part2.Solve();
        }
    }
}
