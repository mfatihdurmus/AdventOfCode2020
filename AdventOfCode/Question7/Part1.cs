using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Question7
{
    public class Part1 : IQuestion
    {
        private class Bag
        {
            public string BagName { get; set; }
            public List<string> IncludedBags { get; set; }

            public Bag()
            {
                IncludedBags = new List<string>();
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
                        bag.IncludedBags.Add(nameOfIncludedBag);
                }

                bags.Add(bag);
            }

            List<string> containerBags = new List<string>();
            containerBags.Add("shiny gold");
            int current = 0;

            while (current < containerBags.Count)
            {
                string name = containerBags[current];
                foreach (var bag in bags)
                {
                    if (bag.IncludedBags.Contains(name))
                    {
                        if (!containerBags.Contains(bag.BagName))
                            containerBags.Add(bag.BagName);
                    }
                }

                current++;
            }

            Console.WriteLine(containerBags.Count - 1);
        }
    }
}
