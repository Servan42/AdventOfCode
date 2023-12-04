using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day4
{
    public class Card
    {
        public static Card Parse(string inputLine)
        {
            var card = new Card();
            
            var cardNumbers = card.GetCardNumbers(inputLine);
            var myNumbers = card.GetMyNumbers(inputLine);
            card.NbOfWinningNumbers = myNumbers.Count(n => cardNumbers.Contains(n));
            card.Amount = 1;
            
            return card;
        }

        public int NbOfWinningNumbers { get; set; }
        public int Amount { get; set; }

        public int CalculatePoints()
        {
            return (int) Math.Pow(2, NbOfWinningNumbers - 1);
        }

        private List<int> GetMyNumbers(string line)
        {
            return ReturnUsefulNumbers(line, 1);
        }

        private List<int> GetCardNumbers(string line)
        {
            return ReturnUsefulNumbers(line, 0);
        }

        private List<int> ReturnUsefulNumbers(string line, int positionToPipe)
        {
            return line
                .Split(':')[1]
                .Split('|')[positionToPipe]
                .Split(' ')
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => int.Parse(n))
                .ToList();
        }
    }
}
