
namespace PokerGame
{
    public class HandRankingCategory
    {
        public enum HandCategory
        {
            HIGHCARD = 0,
            PAIR = 1,
            TWOPAIR = 2,
            THREEOFAKIND = 3,
            STRAIGHT = 4,
            FULLHOUSE = 5,
            FOUROFAKIND = 6,
            FIVEOFAKIND = 7
        }

        public class Player
        {
           public const string PlayerA = "a";
           public const string PlayerB = "b";
           public const string BothPlayer = "ab";
        }
    }
}
