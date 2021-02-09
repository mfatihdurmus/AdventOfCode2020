using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Question5
{
    public class Part1 : IQuestion
    {
        public void Solve()
        {
            var tickets = File.ReadAllLines("./Question5/input.txt");
            int highestTicketId = 0;
            
            List<int> occupiedSeats = new List<int>();

            for (int i = 0; i < tickets.Length; i++)
            {
                var ticketId = FindTicketId(tickets[i]);
                if (ticketId > highestTicketId)
                    highestTicketId = ticketId;
            }

            Console.WriteLine(highestTicketId);
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
