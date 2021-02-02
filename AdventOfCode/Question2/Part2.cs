using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Question2
{
    class Part2 : IQuestion
    {
        public void Solve()
        {
            // passwords: 13-16 k: kkkkkgmkbvkkrskhd
            // token1   : 13-16 k
            // token2   :  kkkkkgmkbvkkrskhd
            var passwords = File.ReadAllLines("./Question2/input.txt");
            int result = 0;

            for (int i = 0; i < passwords.Length; i++)
            {
                var tokens = passwords[i].Split(':');

                var range = tokens[0].Split(' ');

                var limits = range[0].Split('-');
                int lowerLimit = int.Parse(limits[0]);
                int upperLimit = int.Parse(limits[1]);

                char wildCard = range[1].ToCharArray()[0];

                var passPhrase = tokens[1].Trim();

                bool isValid = isPasswordValid(passPhrase, lowerLimit, upperLimit, wildCard);
                if (isValid)
                    result++;
            }

            Console.WriteLine(result);
        }

        private bool isPasswordValid(string passPhrase, int lowerLimit, int upperLimit, char wildCard)
        {
            char[] characters = passPhrase.ToCharArray();
            if (lowerLimit - 1 >= characters.Length)
                return false;

            if (upperLimit - 1 >= characters.Length)
                return false;

            if (characters[lowerLimit - 1] == wildCard && characters[upperLimit - 1] != wildCard)
                return true;
            else if (characters[lowerLimit - 1] != wildCard && characters[upperLimit - 1] == wildCard)
                return true;
            else
                return false;
        }
    }
}
