using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Question4
{
    public class Part2 : IQuestion
    {
        public void Solve()
        {
            var input = File.ReadAllText("./Question4/input.txt");
            var passports = input.Split("\r\n\r\n");

            var validPassportCount = passports.Count(x => PassportIsValid(x));

            Console.WriteLine(validPassportCount);
        }


        /*
         * Validate passport with this rules
         * 
            byr (Birth Year) - four digits; at least 1920 and at most 2002.
            iyr (Issue Year) - four digits; at least 2010 and at most 2020.
            eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
            hgt (Height) - a number followed by either cm or in:
                If cm, the number must be at least 150 and at most 193.
                If in, the number must be at least 59 and at most 76.
            hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            pid (Passport ID) - a nine-digit number, including leading zeroes.
            cid (Country ID) - ignored, missing or not.

            sample passport input = hcl:dab227 iyr:2012 ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277
         */
        private bool PassportIsValid(string passport)
        {
            var passportSegments = passport.Split(new Char[] { ' ', '\n', '\r' });

            Dictionary<string, bool> results = new Dictionary<string, bool>();

            foreach (var passportSegment in passportSegments)
            {
                if (string.IsNullOrWhiteSpace(passportSegment))
                    continue;

                var segmentName = passportSegment.Split(':')[0];
                var segmentValue = passportSegment.Split(':')[1];

                if (segmentName == "ecl")
                {
                    results["ecl"] = ValidateEyeColor(segmentValue);
                }

                if (segmentName == "hcl")
                {
                    results["hcl"] = ValidateHairColor(segmentValue);
                }

                if (segmentName == "byr")
                {
                    results["byr"] = ValidateBirthYear(segmentValue);
                }

                if (segmentName == "iyr")
                {
                    results["iyr"] = ValidateIssueYear(segmentValue);
                }

                if (segmentName == "eyr")
                {
                    results["eyr"] = ValidateExpirationYear(segmentValue);
                }

                if (segmentName == "hgt")
                {
                    results["hgt"] = ValidateHeight(segmentValue);
                }

                if (segmentName == "pid")
                {
                    results["pid"] = ValidatePassportID(segmentValue);
                }
            }

            var mandatoryFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            if (mandatoryFields.All(field => results.Keys.Contains(field)) && results.Values.All(x => x == true))
                return true;

            return false;
        }

        private static bool ValidatePassportID(string segmentValue)
        {
            if (segmentValue.Length == 9 && segmentValue.All(x => char.IsDigit(x)))
                return true;
            else
                return false;
        }

        private bool ValidateHeight(string segmentValue)
        {
            string numberPart = new string(segmentValue.Where(x => char.IsDigit(x)).ToArray());

            int inches = 0;
            if (segmentValue.Contains("in") && int.TryParse(numberPart, out inches))
            {
                if (inches >= 59 && inches <= 76)
                    return true;
                else
                    return false;
            }


            int centimeters = 0;
            if (segmentValue.Contains("cm") && int.TryParse(numberPart, out centimeters))
            {
                if (centimeters >= 150 && centimeters <= 193)
                    return true;
                else
                    return false;
            }

            return false;
        }

        private bool ValidateExpirationYear(string segmentValue)
        {
            int year = 0;
            if (int.TryParse(segmentValue, out year))
            {
                if (year >= 2020 && year <= 2030)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool ValidateIssueYear(string segmentValue)
        {
            int year = 0;
            if (int.TryParse(segmentValue, out year))
            {
                if (year >= 2010 && year <= 2020)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool ValidateBirthYear(string segmentValue)
        {
            int year = 0;
            if (int.TryParse(segmentValue, out year))
            {
                if (year >= 1920 && year <= 2002)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool ValidateHairColor(string segmentValue)
        {
            if (segmentValue.StartsWith('#') && segmentValue.Length == 7)
            {
                char[] validCharacters = "#0123456789ABCDEFabcdef".ToCharArray();

                return segmentValue.All(x => validCharacters.Contains(x));
            }
            return false;
        }

        private bool ValidateEyeColor(string segmentValue)
        {
            var validHairColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (validHairColors.Contains(segmentValue))
            {
                return true;
            }
            return false;
        }
    }
}
