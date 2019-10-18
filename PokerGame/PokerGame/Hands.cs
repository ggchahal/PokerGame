
using System;
using static PokerGame.HandRankingCategory;

namespace PokerGame
{
    public class Hands
    {
        #region Public methods
        public bool ReadHands(string pokerHand, Card[] hand1, Card[] hand2)
        {
            string[] linePieces;

            if (string.IsNullOrEmpty(pokerHand)) return false;

            linePieces = pokerHand.Split();

            char[] hand1LinePieces = linePieces[0].ToCharArray();
            char[] hand2LinePieces = linePieces[1].ToCharArray();

            for (int i = 0; i < 5; i++)
            {
                hand1[i] = new Card
                {
                    Value = Card.GetCardValue(hand1LinePieces[i].ToString())
                };
            }

            for (int i = 0; i < 5; i++)
            {
                hand2[i] = new Card
                {
                    Value = Card.GetCardValue(hand2LinePieces[i].ToString())
                };
            }

            return true;
        }

        public bool EvaluateWinningHand(Card[] hand1, Card[] hand2, out string firstHand, out string secondHand, out string winner)
        {
            bool isFirstHand = false;
            bool isSecondHand = false;
            int a = -1;
            int b = -1;
            int firstHandCategory = -1;
            int secondHandCategory = -1;
            firstHand = string.Empty;
            secondHand = string.Empty;
            winner = string.Empty;

            if (HandsRanking.IsFiveOfAKind(hand1) != HandsRanking.IsFiveOfAKind(hand2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsFiveOfAKind(hand1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.FIVEOFAKIND);
                        firstHandCategory = (int) HandCategory.FIVEOFAKIND;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsFiveOfAKind(hand2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.FIVEOFAKIND);
                        secondHandCategory = (int)HandCategory.FIVEOFAKIND;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsFourOfAKind(hand1) != HandsRanking.IsFourOfAKind(hand2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsFourOfAKind(hand1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.FOUROFAKIND);
                        firstHandCategory = (int)HandCategory.FOUROFAKIND;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsFourOfAKind(hand2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.FOUROFAKIND);
                        secondHandCategory = (int)HandCategory.FOUROFAKIND;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsFullHouse(hand1, 1) != HandsRanking.IsFullHouse(hand2, 1))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsFullHouse(hand1, 1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.FULLHOUSE);
                        firstHandCategory = (int)HandCategory.FULLHOUSE;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsFullHouse(hand2, 1);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.FULLHOUSE);
                        secondHandCategory = (int)HandCategory.FULLHOUSE;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsFullHouse(hand1, 2) != HandsRanking.IsFullHouse(hand2, 2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsFullHouse(hand1, 2);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.FULLHOUSE);
                        firstHandCategory = (int)HandCategory.FULLHOUSE;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsFullHouse(hand2, 2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.FULLHOUSE);
                        secondHandCategory = (int)HandCategory.FULLHOUSE;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }
            else
            {
                if (HandsRanking.IsFullHouse(hand1, 2) != -1 && HandsRanking.IsFullHouse(hand2, 2) != -1 && HandsRanking.IsFullHouse(hand1, 2) == HandsRanking.IsFullHouse(hand2, 2))
                {
                    SetHandCategoryForPlayers(out firstHand, out secondHand, Convert.ToString(HandCategory.FULLHOUSE));
                    winner = Player.BothPlayer;
                    return true;
                }
            }

            if (HandsRanking.IsStraight(hand1) != HandsRanking.IsStraight(hand2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsStraight(hand1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.STRAIGHT);
                        firstHandCategory = (int)HandCategory.STRAIGHT;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsStraight(hand2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.STRAIGHT);
                        secondHandCategory = (int)HandCategory.STRAIGHT;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }
            else
            {
                if (HandsRanking.IsStraight(hand1) != -1 && HandsRanking.IsStraight(hand2) != -1 && HandsRanking.IsStraight(hand1) == HandsRanking.IsStraight(hand2))
                {
                    SetHandCategoryForPlayers(out firstHand, out secondHand, Convert.ToString(HandCategory.STRAIGHT));
                    winner = Player.BothPlayer;
                    return true;
                }
            }

            if (HandsRanking.IsThreeOfAKind(hand1) != HandsRanking.IsThreeOfAKind(hand2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsThreeOfAKind(hand1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.THREEOFAKIND);
                        firstHandCategory = (int)HandCategory.THREEOFAKIND;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsThreeOfAKind(hand2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.THREEOFAKIND);
                        secondHandCategory = (int)HandCategory.THREEOFAKIND;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }
            else
            {
                if (HandsRanking.IsThreeOfAKind(hand1) != -1 && HandsRanking.IsThreeOfAKind(hand2) != -1 && HandsRanking.IsThreeOfAKind(hand1) == HandsRanking.IsThreeOfAKind(hand2))
                {
                    SetHandCategoryForPlayers(out firstHand, out secondHand, Convert.ToString(HandCategory.THREEOFAKIND));
                    winner = DecideWinnerIfTie(hand1, hand2);
                    return true;
                }
            }

            if (HandsRanking.IsTwoPairs(hand1, 1) != HandsRanking.IsTwoPairs(hand2, 1))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsTwoPairs(hand1, 1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.TWOPAIR);
                        firstHandCategory = (int)HandCategory.TWOPAIR;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsTwoPairs(hand2, 1);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.TWOPAIR);
                        secondHandCategory = (int)HandCategory.TWOPAIR;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsTwoPairs(hand1, 2) != HandsRanking.IsTwoPairs(hand2, 2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsTwoPairs(hand1, 2);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.TWOPAIR);
                        firstHandCategory = (int)HandCategory.TWOPAIR;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsTwoPairs(hand2, 2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.TWOPAIR);
                        secondHandCategory = (int)HandCategory.TWOPAIR;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }
            else
            {
                if (HandsRanking.IsTwoPairs(hand1, 2) != -1 && HandsRanking.IsTwoPairs(hand2, 2) != -1 && HandsRanking.IsTwoPairs(hand1, 2) == HandsRanking.IsTwoPairs(hand2, 2))
                {
                    SetHandCategoryForPlayers(out firstHand, out secondHand, Convert.ToString(HandCategory.TWOPAIR));
                    winner = DecideWinnerIfTie(hand1, hand2);
                    return true;
                }
            }

            if (HandsRanking.IsOnePair(hand1) != HandsRanking.IsOnePair(hand2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsOnePair(hand1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.PAIR);
                        firstHandCategory = (int)HandCategory.PAIR;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsOnePair(hand2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.PAIR);
                        secondHandCategory = (int)HandCategory.PAIR;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }
            else
            {
                if (HandsRanking.IsOnePair(hand1) != -1 && HandsRanking.IsOnePair(hand2) != -1 && HandsRanking.IsOnePair(hand1) == HandsRanking.IsOnePair(hand2))
                {
                    SetHandCategoryForPlayers(out firstHand, out secondHand, Convert.ToString(HandCategory.PAIR));
                    winner = DecideWinnerIfTie(hand1, hand2);
                    return true;
                }
            }

            if (HandsRanking.IsHighCard(hand1, 0) != HandsRanking.IsHighCard(hand2, 0))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsHighCard(hand1, 0);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.HIGHCARD);
                        firstHandCategory = (int)HandCategory.HIGHCARD;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsHighCard(hand2, 0);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.HIGHCARD);
                        secondHandCategory = (int)HandCategory.HIGHCARD;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsHighCard(hand1, 1) != HandsRanking.IsHighCard(hand2, 1))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsHighCard(hand1, 1);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.HIGHCARD);
                        firstHandCategory = (int)HandCategory.HIGHCARD;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsHighCard(hand2, 1);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.HIGHCARD);
                        secondHandCategory = (int)HandCategory.HIGHCARD;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsHighCard(hand1, 2) != HandsRanking.IsHighCard(hand2, 2))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsHighCard(hand1, 2);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.HIGHCARD);
                        firstHandCategory = (int)HandCategory.HIGHCARD;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsHighCard(hand2, 2);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.HIGHCARD);
                        secondHandCategory = (int)HandCategory.HIGHCARD;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsHighCard(hand1, 3) != HandsRanking.IsHighCard(hand2, 3))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsHighCard(hand1, 3);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.HIGHCARD);
                        firstHandCategory = (int)HandCategory.HIGHCARD;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsHighCard(hand2, 3);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.HIGHCARD);
                        secondHandCategory = (int)HandCategory.HIGHCARD;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }

            if (HandsRanking.IsHighCard(hand1, 4) != HandsRanking.IsHighCard(hand2, 4))
            {
                if (!isFirstHand)
                {
                    a = HandsRanking.IsHighCard(hand1, 4);
                    if (a != -1)
                    {
                        firstHand = Convert.ToString(HandCategory.HIGHCARD);
                        firstHandCategory = (int)HandCategory.HIGHCARD;
                        isFirstHand = true;
                    }
                }

                if (!isSecondHand)
                {
                    b = HandsRanking.IsHighCard(hand2, 4);
                    if (b != -1)
                    {
                        secondHand = Convert.ToString(HandCategory.HIGHCARD);
                        secondHandCategory = (int)HandCategory.HIGHCARD;
                        isSecondHand = true;
                    }
                }

                if (isFirstHand && isSecondHand)
                {
                    return WinnerName(out winner, a, b, firstHandCategory, secondHandCategory);
                }
            }
            else
            {
                if (HandsRanking.IsHighCard(hand1, 4) != -1 && HandsRanking.IsHighCard(hand2, 4) != -1 && HandsRanking.IsHighCard(hand1, 4) == HandsRanking.IsHighCard(hand2, 4))
                {
                    SetHandCategoryForPlayers(out firstHand, out secondHand, Convert.ToString(HandCategory.HIGHCARD));
                    winner = Player.BothPlayer;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Private methods
        public static bool IsValid(string input, int min = 1, int max = 10)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var i = 0;

            if (int.TryParse(input, out i))
            {
                return IsInRange(i, min, max);
            }

            return false;
        }

        private static bool IsInRange(int i, int min, int max)
        {
            return ((i >= min) && (i <= max));
        }

        private static string DecideWinnerIfTie(Card[] hand1, Card[] hand2)
        {
            string winner;
            if (HandsRanking.IsHighCard(hand1, 0) == HandsRanking.IsHighCard(hand2, 0))
            {
                if (HandsRanking.IsHighCard(hand1, 1) == HandsRanking.IsHighCard(hand2, 1))
                {
                    if (HandsRanking.IsHighCard(hand1, 2) == HandsRanking.IsHighCard(hand2, 2))
                    {
                        if (HandsRanking.IsHighCard(hand1, 3) == HandsRanking.IsHighCard(hand2, 3))
                        {
                            if (HandsRanking.IsHighCard(hand1, 4) == HandsRanking.IsHighCard(hand2, 4))
                            {
                                winner = Player.BothPlayer;
                            }
                            else
                            {
                                winner = HandsRanking.IsHighCard(hand1, 4) > HandsRanking.IsHighCard(hand2, 4) ? Player.PlayerA : Player.PlayerB;
                            }
                        }
                        else
                        {
                            winner = HandsRanking.IsHighCard(hand1, 3) > HandsRanking.IsHighCard(hand2, 3) ? Player.PlayerA : Player.PlayerB;
                        }
                    }
                    else
                    {
                        winner = HandsRanking.IsHighCard(hand1, 2) > HandsRanking.IsHighCard(hand2, 2) ? Player.PlayerA : Player.PlayerB;
                    }
                }
                else
                {
                    winner = HandsRanking.IsHighCard(hand1, 1) > HandsRanking.IsHighCard(hand2, 1) ? Player.PlayerA : Player.PlayerB;
                }
            }
            else
            {
                winner = HandsRanking.IsHighCard(hand1, 0) > HandsRanking.IsHighCard(hand2, 0) ? Player.PlayerA : Player.PlayerB;
            }

            return winner;
        }

        private static void SetHandCategoryForPlayers(out string firstHand, out string secondHand, string handCategory)
        {
            firstHand = handCategory;
            secondHand = handCategory;
        }

        private static bool WinnerName(out string winner, int a, int b, int firstHandCategory, int secondHandCategory)
        {
            winner = firstHandCategory == secondHandCategory ? a > b ? Player.PlayerA : Player.PlayerB : firstHandCategory > secondHandCategory ? Player.PlayerA : Player.PlayerB;
            return true;
        }
        #endregion
    }
}
