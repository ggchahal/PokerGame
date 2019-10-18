using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerGame;
using System;
using System.Collections.Generic;
using System.IO;

namespace PokerGameTests
{
    [TestClass]
    public class PokerHandUnitTest
    {
        [TestMethod]
        public void ForSingleStringInput_PokerHand()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("AA225 44465");

                //Expected Value
                string expected =
                   string.Format("TWOPAIR THREEOFAKIND b{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void MoreThanOneStringInput_PokerHand()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("AAKKK 23456");
                pokerhands.Add("KA225 33A47");
                
                //Expected Value
                string expected =
                   string.Format("FULLHOUSE STRAIGHT a{0}PAIR PAIR b{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void HighCard()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("8TK94 7253A");

                //Expected Value
                string expected =
                   string.Format("HIGHCARD HIGHCARD b{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void OnePair_vs_HighCard()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("58622 AKQT9");

                //Expected Value
                string expected =
                   string.Format("PAIR HIGHCARD a{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TwoPair_vs_OnePair()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("AAKQJ 22334");

                //Expected Value
                string expected =
                   string.Format("PAIR TWOPAIR b{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void ThreeOfKind_vs_TwoPair()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("22234 AAKKQ");

                //Expected Value
                string expected =
                   string.Format("THREEOFAKIND TWOPAIR a{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void Straight_vs_ThreeOfKind()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("23456 AAAKQ");

                //Expected Value
                string expected =
                   string.Format("STRAIGHT THREEOFAKIND a{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void FullHouse_vs_Straight()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("23456 AAAKK");

                //Expected Value
                string expected =
                   string.Format("STRAIGHT FULLHOUSE b{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void FourOfKind_vs_FullHouse()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("46444 AAAKK");

                //Expected Value
                string expected =
                   string.Format("FOUROFAKIND FULLHOUSE a{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        //FiveOfKind : It is possible if Joker exists
        [TestMethod]
        public void FiveOfKind_vs_FourOfKind()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("55555 64666");

                //Expected Value
                string expected =
                   string.Format("FIVEOFAKIND FOUROFAKIND a{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void SameHandCategory_OnePair_vs_OnePair()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("QQ2AT QQT2J");

                //Expected Value
                string expected =
                   string.Format("PAIR PAIR a{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void SameHandCategory_HighCard_vs_HighCard()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("25678 35678");

                //Expected Value
                string expected =
                   string.Format("HIGHCARD HIGHCARD b{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void Tie_OnePair_vs_OnePair()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("TT8A9 TTA89");

                //Expected Value
                string expected =
                   string.Format("PAIR PAIR ab{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        //It is possible if Joker exists
        [TestMethod]
        public void Tie_FullHouse_vs_ThreeOfKind()
        {
            //Second Hand has Joker
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Arrange
                Game game = new Game();
                List<string> pokerhands = new List<string>();
                pokerhands.Add("AAAJJ AAAJJ");

                //Expected Value
                string expected =
                   string.Format("FULLHOUSE FULLHOUSE ab{0}", Environment.NewLine);

                //Act
                game.Judge(pokerhands);

                //Assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
