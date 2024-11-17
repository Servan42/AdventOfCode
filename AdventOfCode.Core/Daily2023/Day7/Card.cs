using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day7
{
    public class Card
    {
        public static Card Parse(char character, bool handleJokers = false)
        {
            var card = new Card(character);
            card.ResolveValue(handleJokers);
            return card;
        }

        private void ResolveValue(bool handleJokers)
        {
            if (Character >= '2' && Character <= '9')
            {
                Value = int.Parse(Character.ToString());
            }
            else
            {
                switch (Character)
                {
                    case 'T':
                        Value = 10;
                        break;
                    case 'J':
                        Value = handleJokers ? 1 : 11;
                        break;
                    case 'Q':
                        Value = 12;
                        break;
                    case 'K':
                        Value = 13;
                        break;
                    case 'A':
                        Value = 14;
                        break;
                    default:
                        throw new ArgumentException(nameof(Character));
                }
            }
        }

        public Card(char character)
        {
            Character = character;
        }

        public int Value { get; set; }
        public char Character { get; set; }
    }
}
