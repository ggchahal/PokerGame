using System;
using System.Collections.Generic;

namespace PokerGame
{
    public class Game
    {
        Hands objHand = null;

        public Game()
        {
            objHand = new Hands();
        }
        
        public void Judge(List<string> pokerHands, Card[] hand1, Card[] hand2)
        {
            foreach (string pokerHand in pokerHands)
            {
                if (objHand.ReadHands(pokerHand, hand1, hand2))
                {
                    Array.Sort(hand1);
                    Array.Sort(hand2);

                    if (objHand.EvaluateWinningHand(hand1, hand2, out string firstHand, out string secondHand, out string winner))
                    {
                        Console.WriteLine(firstHand + "  " + secondHand + "  " + winner);
                    }
                }
            }
        }


        // return 1 if player wins, otherwise return 0;
        //public static int Judge(string hands)
        //{
        //    var cards = hands.Split(' ');
        //    var _player1 = new Hand(cards.Take(5));
        //    var _player2 = new Hand(cards.Skip(5).Take(5));

        //    if (_player1.Weight.Item1 == _player2.Weight.Item1)
        //    {
        //        return _player1.Weight.Item2 > _player2.Weight.Item2 ? 1 : 0;
        //    }

        //    return _player1.Weight.Item1 > _player2.Weight.Item1 ? 1 : 0;
        //}
    }
}
