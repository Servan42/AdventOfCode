using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day7
{
    public class CardHandComparer : IComparer<CardHand>
    {
        private const int X_IS_SMALLER = -1;
        private const int Y_IS_SMALLER = 1;
        private const int BOTH_ARE_EQUAL = 0;

        public int Compare(CardHand? x, CardHand? y)
        {
            if (x == null || string.IsNullOrEmpty(x.Hand)) throw new ArgumentOutOfRangeException(nameof(x));
            if (y == null || string.IsNullOrEmpty(y.Hand)) throw new ArgumentOutOfRangeException(nameof(y));
            if (x.Hand == y.Hand) return BOTH_ARE_EQUAL;
            if (x.TypeValue > y.TypeValue) return Y_IS_SMALLER;
            if (x.TypeValue < y.TypeValue) return X_IS_SMALLER;

            for (int i = 0; i < x.Cards.Count; i++)
            {
                if (x.Cards[i].Value > y.Cards[i].Value) return Y_IS_SMALLER;
                if (x.Cards[i].Value < y.Cards[i].Value) return X_IS_SMALLER;
            }

            return BOTH_ARE_EQUAL;
        }
    }
}
