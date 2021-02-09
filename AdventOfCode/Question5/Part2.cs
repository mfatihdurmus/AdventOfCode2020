using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Question5
{
    public class Part2 : IQuestion
    {
        public void Solve()
        {
            var tickets = File.ReadAllLines("./Question5/input.txt");
            int ourSeatId = 0;

            List<int> occupiedSeats = new List<int>();

            for (int i = 0; i < tickets.Length; i++)
            {
                var ticketId = FindTicketId(tickets[i]);
                occupiedSeats.Add(ticketId);
            }

            occupiedSeats.Sort();
            for (int i = 0; i < occupiedSeats.Count() - 1; i++)
            {
                if (occupiedSeats[i + 1] - occupiedSeats[i] == 2)
                {
                    ourSeatId = occupiedSeats[i] + 1;
                }
            }

            Console.WriteLine(ourSeatId);
        }
        private int FindTicketId(string ticketCode)
        {
            // sample BSP ticket code : BFFFBBFRRR
            char[] ticketChars = ticketCode.ToCharArray();

            int rowNumber = FindRow(ticketCode.Substring(0, ticketCode.Length - 3), 'B');
            int columnNumber = FindRow(ticketCode.Substring(7, 3), 'R');
            return rowNumber * 8 + columnNumber;
        }

        private int FindRow(string ticketCode, char valueChar)
        {
            //BFFFBBF
            int result = 0;
            int maxDigitValue = (int)Math.Pow(2, ticketCode.Length - 1);
            for (int i = 0; i < ticketCode.Length; i++)
            {
                if (ticketCode.ToCharArray()[i] == valueChar)
                    result += maxDigitValue;

                maxDigitValue /= 2;
            }
            return result;
        }
    }
}
