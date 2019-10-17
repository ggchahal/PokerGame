
namespace PokerGame
{
    public class HandsRanking
    {
        public static int IsFiveOfAKind(Card[] h)
        {
            if (h[0].Value == h[1].Value &&
                h[1].Value == h[2].Value &&
                h[2].Value == h[3].Value &&
                h[3].Value == h[4].Value)
            {
                return h[0].Value;
            }

            return -1;
        }

        public static int IsFourOfAKind(Card[] h)
        {
            if (h[0].Value == h[1].Value &&
                h[1].Value == h[2].Value &&
                h[2].Value == h[3].Value)
            {
                return h[0].Value;
            }

            if (h[1].Value == h[2].Value &&
                h[2].Value == h[3].Value &&
                h[3].Value == h[4].Value)
            {
                return h[1].Value;
            }

            return -1;
        }

        public static int IsFullHouse(Card[] h, int set)
        {
            if (set == 1 &&
              h[0].Value == h[1].Value &&
              h[1].Value == h[2].Value &&
              h[3].Value == h[4].Value)
            {
                return h[0].Value;
            }

            if (set == 2 &&
                h[0].Value == h[1].Value &&
               h[1].Value == h[2].Value &&
               h[3].Value == h[4].Value)
            {
                return h[4].Value;
            }

            if (set == 1 &&
               h[0].Value == h[1].Value &&
               h[2].Value == h[3].Value &&
               h[3].Value == h[4].Value)
            {
                return h[4].Value;
            }

            if (set == 2 &&
                h[0].Value == h[1].Value &&
               h[2].Value == h[3].Value &&
               h[3].Value == h[4].Value)
            {
                return h[0].Value;
            }

            return -1;
        }

        public static int IsStraight(Card[] h)
        {
            for (int i = 0; i < 4; i++)
            {
                if (h[i].Value != h[i + 1].Value - 1)
                {
                    if (i == 3)
                    {
                        if (h[i + 1].Value == 14)
                        {
                            return h[3].Value;
                        }
                    }

                    return -1;
                }
            }
            return h[4].Value;
        }

        public static int IsThreeOfAKind(Card[] h)
        {
            if (h[0].Value == h[1].Value &&
               h[1].Value == h[2].Value)
            {
                return h[0].Value;
            }

            if (h[1].Value == h[2].Value &&
               h[2].Value == h[3].Value)
            {
                return h[1].Value;
            }

            if (h[2].Value == h[3].Value &&
               h[3].Value == h[4].Value)
            {
                return h[2].Value;
            }

            return -1;
        }

        public static int IsTwoPairs(Card[] h, int set)
        {
            if (set == 1 &&
                h[0].Value == h[1].Value &&
                h[2].Value == h[3].Value)
            {
                return h[0].Value;
            }

            if (set == 2 &&
                h[0].Value == h[1].Value &&
                h[2].Value == h[3].Value)
            {
                return h[2].Value;
            }

            if (set == 1 &&
                h[0].Value == h[1].Value &&
                h[3].Value == h[4].Value)
            {
                return h[0].Value;
            }

            if (set == 2 &&
                h[0].Value == h[1].Value &&
                h[3].Value == h[4].Value)
            {
                return h[3].Value;
            }

            if (set == 1 &&
                h[1].Value == h[2].Value &&
                h[3].Value == h[4].Value)
            {
                return h[1].Value;
            }

            if (set == 2 &&
                h[1].Value == h[2].Value &&
                h[3].Value == h[4].Value)
            {
                return h[3].Value;
            }

            return -1;
        }

        public static int IsOnePair(Card[] h)
        {
            if (h[0].Value == h[1].Value)
            {
                return h[0].Value;
            }

            if (h[1].Value == h[2].Value)
            {
                return h[1].Value;
            }

            if (h[2].Value == h[3].Value)
            {
                return h[2].Value;
            }

            if (h[3].Value == h[4].Value)
            {
                return h[3].Value;
            }

            return -1;
        }

        public static int IsHighCard(Card[] h, int card)
        {
            return h[4 - card].Value;
        }
    }
}
