using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PokerGame
{
    public class Game
    {
        readonly Card[] hand1 = null;
        readonly Card[] hand2 = null;

        public Game()
        {
            hand1 = new Card[5];
            hand2 = new Card[5];
        }

        #region Public methods
        public static bool IsValid(string input)
        {
            int min = 1;
            int max = 10;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            int i = 0;

            if (int.TryParse(input, out i))
            {
                return IsInRange(i, min, max);
            }

            return false;
        }

        public static void VerifyInputHands(string noOfPairs, List<string> pokerHands)
        {
            //string pattern = "/^(?=(?:[^1]*1){0,4}[^1]*$)(?=(?:[^2]*2){0,4}[^2]*$)(?=(?:[^3]*3){0,4}[^3]*$)(?=(?:[^4]*4){0,4}[^4]*$)(?=(?:[^5]*5){0,4}[^5]*$)(?=(?:[^6]*6){0,4}[^6]*$)(?=(?:[^7]*7){0,4}[^7]*$)(?=(?:[^8]*8){0,4}[^8]*$)(?=(?:[^9]*9){0,4}[^9]*$)(?=(?:[^T]* T){0,4}[^T]*$)(?=(?:[^J]* J){0,4}[^J]*$)(?=(?:[^Q]* Q){0,4}[^Q]*$)(?=(?:[^K]* K){0,4}[^K]*$)(?=(?:[^A]* A){0,4}[^A]*$)(?:[2-9TJQKA]{5} [2-9TJQKA]{5})$/";
            string pattern = "^(?:[2-9TJQKA]{5} [2-9TJQKA]{5})$";

            for (int i = 0; i < Convert.ToInt32(noOfPairs); i++)
            {
                var inputValue = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputValue))
                {
                    if (!Regex.IsMatch(inputValue, pattern))
                    {
                        Console.WriteLine("Invalid value format. Please enter the value again");
                        i--;
                    }
                    else
                    {
                        pokerHands.Add(inputValue);
                    }
                }
            }
        }

        public void Judge(List<string> pokerHands)
        {
            foreach (string pokerHand in pokerHands)
            {
                if (Hands.ReadHands(pokerHand, hand1, hand2))
                {
                    Array.Sort(hand1);
                    Array.Sort(hand2);

                    if (Hands.EvaluateWinningHand(hand1, hand2, out string firstHand, out string secondHand, out string winner))
                    {
                        Console.WriteLine(firstHand + " " + secondHand + " " + winner);
                    }
                }
            }
        }
        #endregion

        #region Private method

        private static bool IsInRange(int i, int min, int max)
        {
            return ((i >= min) && (i <= max));
        }

        #endregion
    }
}
