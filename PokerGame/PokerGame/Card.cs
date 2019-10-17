using System;

namespace PokerGame
{
    public class Card : IComparable
    {
        public int Value { get; set; }

        #region IComparable Members
        public int CompareTo(object o)
        {
            if (o is Card c)
            {
                if (Value < c.Value)
                {
                    return -1;
                }
                else if (Value > c.Value)
                {
                    return 1;
                }

                return 0;
            }
            throw new ArgumentException("Object is not a Card");
        }
        #endregion

        public static int GetCardValue(string value)
        {
            int intvalue;
            if (int.TryParse(value, out intvalue))
            {
                return intvalue;
            }

            if (value == "T") return 10;
            if (value == "J") return 11;
            if (value == "Q") return 12;
            if (value == "K") return 13;
            if (value == "A") return 14;

            return 0;
        }
    }
}
