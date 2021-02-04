using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode.Question7
{
    public class Part2 : IQuestion
    {
        private class Bag
        {
            public string BagName { get; set; }

            public int BagCount { get; set; }

            public List<Bag> IncludedBags { get; set; }

            public Bag()
            {
                IncludedBags = new List<Bag>();
            }
        }

        public void Solve()
        {
            var inputs = File.ReadAllLines("./Question7/input.txt");
            List<Bag> bags = new List<Bag>();

            foreach (var line in inputs)
            {
                var tokens = line.Split(" bags contain ");
                Bag bag = new Bag();
                bag.BagName = tokens[0];

                //"2 clear lavender bags" 
                //"3 clear teal bags"
                //"4 vibrant gold bags."
                var includedBags = tokens[1].Split(", ");

                foreach (var item in includedBags)
                {
                    int startIndex = 0;
                    int endIndex = 0;
                    var charArr = item.ToCharArray();
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (char.IsLetter(item[i]))
                        {
                            startIndex = i;
                            break;
                        }
                    }

                    endIndex = item.IndexOf(" bag");

                    var nameOfIncludedBag = item.Substring(startIndex, endIndex - startIndex);

                    if (nameOfIncludedBag != "no other")
                    {
                        var bagCount = Int32.Parse(item.Split(' ').First());
                        Bag innerBag = new Bag();
                        innerBag.BagName = nameOfIncludedBag;
                        innerBag.BagCount = bagCount;

                        bag.IncludedBags.Add(innerBag);
                    }
                }

                bags.Add(bag);
            }

            int solution = FindInnerBagCount("shiny gold", bags);
            
            Console.WriteLine(solution);
        }

        private int FindInnerBagCount(string bagName, List<Bag> bags)
        {
            var startingBag = bags.First(b => b.BagName == bagName);

            if (startingBag.IncludedBags.Count == 0)
                return 0;
                        
            int bagCount = 0;
            foreach (var bag in startingBag.IncludedBags)
            {
                bagCount += bag.BagCount;
                bagCount += bag.BagCount * FindInnerBagCount(bag.BagName, bags); 
            }

            return bagCount;
        }
    }
}
