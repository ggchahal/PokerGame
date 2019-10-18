using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PokerGame
{
    public class PokerGameProgram
    {
        public static void Main(string[] args)
        {
            DetermineWinnerHand();
        }

        public static void DetermineWinnerHand()
        {
            Console.WriteLine("Welcome to Poker Game");
            Console.WriteLine("Given two five - card poker hands dealt from a modified 52 card deck, classify each hand and determine which hand is the winner.\n");
            Console.WriteLine("************************************************INPUT***************************************************************");
            Console.WriteLine("Enter the number of pairs of poker hands to evaluate between 1 and 10 ");
            string noOfPairs = Console.ReadLine();

            while (!Game.IsValid(noOfPairs))
            {
                Console.WriteLine("Invalid Input, Please enter the value between 1 and 10");
                string input = Console.ReadLine();
                noOfPairs = input;
            }

            Console.WriteLine("\nPlease enter the two five-card poker hands in this format ***** ***** e.g. 324AK 3KJ89 from 52 card deck for {0} pairs", noOfPairs);
            Console.WriteLine("Allow to enter the values - A,K,Q,J,T,9,8,7,6,5,4,3,2. Each Letter/Number could appear maximun 4 times in each sentence line.");
            Console.WriteLine();

            List<string> pokerHands = new List<string>();
            Game.VerifyInputHands(noOfPairs, pokerHands);

            Console.WriteLine("\n***********************************************OUTPUT*************************************************************");
            Console.WriteLine();

            Game game = new Game();
            game.Judge(pokerHands);

            Console.ReadKey();
        }
    }
}