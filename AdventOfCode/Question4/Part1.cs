using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode.Question4
{
    public class Part1 : IQuestion
    {
        public void Solve()
        {
            var input = File.ReadAllText("./Question4/input.txt");
            var passports = input.Split("\r\n\r\n");

            var validPassportCount = passports.Count(x => PassportIsValid(x));

            Console.WriteLine(validPassportCount);
        }

        private bool PassportIsValid(string passport)
        {
            var passportSegments = passport.Split(new Char[] { ' ', '\n', '\r' });

            Dictionary<string, bool> results = new Dictionary<string, bool>();

            foreach (var passportSegment in passportSegments)
            {
                if (string.IsNullOrWhiteSpace(passportSegment))
                    continue;

                var segmentName = passportSegment.Split(':')[0];
                results[segmentName] = true;
            }

            var mandatoryFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            if (mandatoryFields.All(field => results.Keys.Contains(field)) && results.Values.All(x => x == true))
                return true;

            return false;
        }
    }
}
