using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IQuestion> questions = new List<IQuestion>();
            /*
            questions.Add(new Question1.Part1());
            questions.Add(new Question1.Part2());
            questions.Add(new Question2.Part1());
            questions.Add(new Question2.Part2());
            questions.Add(new Question3.Part1());
            questions.Add(new Question3.Part2());
            questions.Add(new Question4.Part1());
            questions.Add(new Question4.Part2());
            questions.Add(new Question5.Part1());
            questions.Add(new Question5.Part2());
            questions.Add(new Question6.Part1());
            questions.Add(new Question6.Part2());
            questions.Add(new Question7.Part1());
            questions.Add(new Question7.Part2());
            questions.Add(new Question8.Part1());*/
            questions.Add(new Question8.Part2());


            foreach (var item in questions)
            {
                item.Solve();
            }
        }
    }
}
