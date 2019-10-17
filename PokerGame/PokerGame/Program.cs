using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PokerGame
{
    class Program
    {
        readonly Card[] hand1 = new Card[5];
        readonly Card[] hand2 = new Card[5];

        static void Main(string[] args)
        {
            Program program = new Program();
            program.DetermineWinnerHand();
        }

        public void DetermineWinnerHand()
        {
            //Hands objHand = new Hands();
            Game game = new Game();
            //Stopwatch clock = Stopwatch.StartNew();

            Console.WriteLine("Welcome to Poker Game");
            Console.WriteLine("Given two five - card poker hands dealt from a modified 52 card deck, classify each hand and determine which hand is the winner.\n");
            Console.WriteLine("************************************************INPUT***************************************************************");
            Console.WriteLine("Enter the number of pairs of poker hands to evaluate between 1 and 10 ");
            string noOfPairs = Console.ReadLine();

            while (!Hands.IsValid(noOfPairs))
            {
                Console.WriteLine("Invalid Input, Please enter the value between 1 and 10");
                string input = Console.ReadLine();
                noOfPairs = input;
            }

            Console.WriteLine("\nPlease enter the two five-card poker hands in this format ***** ***** e.g. 324AK 3KJ89 from 52 card deck for {0} pairs", noOfPairs);
            Console.WriteLine("Allow to enter the values - A,K,Q,J,T,9,8,7,6,5,4,3,2. Each Letter/Number could appear maximun 4 times in each sentence line.");
            Console.WriteLine();

            string pattern = "^(?:[2-9TJQKA]{5} [2-9TJQKA]{5})$";
            //string pattern = "/^(?=(?:[^1]*1){0,4}[^1]*$)(?=(?:[^2]*2){0,4}[^2]*$)(?=(?:[^3]*3){0,4}[^3]*$)(?=(?:[^4]*4){0,4}[^4]*$)(?=(?:[^5]*5){0,4}[^5]*$)(?=(?:[^6]*6){0,4}[^6]*$)(?=(?:[^7]*7){0,4}[^7]*$)(?=(?:[^8]*8){0,4}[^8]*$)(?=(?:[^9]*9){0,4}[^9]*$)(?=(?:[^T]* T){0,4}[^T]*$)(?=(?:[^J]* J){0,4}[^J]*$)(?=(?:[^Q]* Q){0,4}[^Q]*$)(?=(?:[^K]* K){0,4}[^K]*$)(?=(?:[^A]* A){0,4}[^A]*$)(?:[2-9TJQKA]{5} [2-9TJQKA]{5})$/";

            List<string> pokerHands = new List<string>();
            string InvalidValueFormat = string.Empty;

            for (int i = 0; i < Convert.ToInt32(noOfPairs); i++)
            {
                var inputValue = Console.ReadLine();

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

            Console.WriteLine("\n***********************************************OUTPUT*************************************************************");
            Console.WriteLine();
          
            game.Judge(pokerHands, hand1, hand2);

            //foreach (string pokerHand in pokerHands)
            //{
            //    if (objHand.ReadHands(pokerHand, hand1, hand2))
            //    {
            //        Array.Sort(hand1);
            //        Array.Sort(hand2);

            //        if (objHand.EvaluateWinningHand(hand1, hand2, out string firstHand, out string secondHand, out string winner))
            //        {
            //            Console.WriteLine(firstHand + "  " + secondHand + "  " + winner);
            //        }
            //    }
            //}

            //clock.Stop();

            //Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}