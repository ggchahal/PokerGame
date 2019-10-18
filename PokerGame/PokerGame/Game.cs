using System;
using System.Collections.Generic;

namespace PokerGame
{
    public class Game
    {
        Hands objHand = null;
        readonly Card[] hand1 = null;
        readonly Card[] hand2 = null;

        public Game()
        {
            objHand = new Hands();
            hand1 = new Card[5];
            hand2 = new Card[5];
        }
        
        public void Judge(List<string> pokerHands)
        {
            foreach (string pokerHand in pokerHands)
            {
                if (objHand.ReadHands(pokerHand, hand1, hand2))
                {
                    Array.Sort(hand1);
                    Array.Sort(hand2);

                    if (objHand.EvaluateWinningHand(hand1, hand2, out string firstHand, out string secondHand, out string winner))
                    {
                        Console.WriteLine(firstHand + " " + secondHand + " " + winner);
                    }
                }
            }
        }
    }
}
