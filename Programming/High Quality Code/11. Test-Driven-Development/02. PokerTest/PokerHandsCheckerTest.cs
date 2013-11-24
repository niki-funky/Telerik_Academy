//-----------------------------------------------------------------------
// <copyright file="PokerHandsCheckerTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace PokerTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void TestIsValid1()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsValidHand(hand), "Hand validation was not successful.");
        }

        [TestMethod]
        public void TestIsValid2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            bool validHand = checker.IsValidHand(null);

            Assert.AreEqual(false, validHand, "Hand validation was not successful.");
        }

        [TestMethod]
        public void TestIsValid3()
        {
            ICard[] cards = new ICard[3]
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();
            bool validHand = checker.IsValidHand(hand);

            Assert.AreEqual(false, validHand, "Hand validation was not successful.");
        }

        [TestMethod]
        public void TestIsValid4()
        {
            IHand hand = new Hand("A♦ 10♦ Q♦ J♦ 10♦");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand), "Hand validation was not successful.");
        }

        [TestMethod]
        public void TestHighCard1()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsHighCard(hand), "High card is not identified correctly.");
        }

        [TestMethod]
        public void TestHighCard2()
        {
            IHand hand = new Hand("K♥ J♥ 9♦ 3♦ 4♠");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsHighCard(hand), "High card is not identified correctly.");
        }

        [TestMethod]
        public void TestOnePair1()
        {
            IHand hand = new Hand("K♥ K♦ 9♦ 3♦ 2♠");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand), "One pair is not identified correctly.");
        }

        [TestMethod]
        public void TestOnePair2()
        {
            IHand hand = new Hand("K♥ 9♥ 10♦ 2♦ 2♠");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand), "One pair is not identified correctly.");
        }

        [TestMethod]
        public void TestTwoPair1()
        {
            IHand hand = new Hand("10♥ 10♦ 9♦ 2♦ 2♠");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsTwoPair(hand), "Two pair is not identified correctly.");
        }

        [TestMethod]
        public void TestTwoPair2()
        {
            IHand hand = new Hand("K♥ K♦ 9♦ 3♦ 3♠");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsTwoPair(hand), "Two pair is not identified correctly.");
        }

        [TestMethod]
        public void TestThreeOfAKind1()
        {
            IHand hand = new Hand("3♦ 3♠ 3♣ 10♠ 6♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand), "Three of a kind is not identified correctly.");
        }

        [TestMethod]
        public void TestThreeOfAKind2()
        {
            IHand hand = new Hand("2♦ 4♠ 5♣ 5♠ 5♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand), "Three of a kind is not identified correctly.");
        }

        [TestMethod]
        public void TestThreeOfAKind3()
        {
            IHand hand = new Hand("A♦ A♠ A♣ K♠ Q♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand), "Three of a kind is not identified correctly.");
        }

        [TestMethod]
        public void TestStraight1()
        {
            IHand hand = new Hand("9♦ 10♠ J♣ K♠ Q♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand), "Straight is not identified correctly.");
        }

        [TestMethod]
        public void TestStraight2()
        {
            IHand hand = new Hand("9♦ 10♠ 8♣ 7♠ 6♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand), "Straight is not identified correctly.");
        }

        [TestMethod]
        public void TestStraight3()
        {
            IHand hand = new Hand("6♦ 5♥ 3♥ 4♥ 2♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand), "Straight is not identified correctly.");
        }

        [TestMethod]
        public void TestStraight4()
        {
            IHand hand = new Hand("6♦ 5♥ 3♥ 4♥ A♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraight(hand), "Straight is not identified correctly.");
        }

        [TestMethod]
        public void TestFlush1()
        {
            IHand hand = new Hand("6♥ 5♥ 3♥ 4♥ J♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand), "Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestFlush2()
        {
            IHand hand = new Hand("2♣ 5♣ A♣ 4♣ J♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand), "Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestFlush3()
        {
            IHand hand = new Hand("2♦ Q♦ A♦ 10♦ J♦");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand), "Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestFlush4()
        {
            IHand hand = new Hand("2♦ Q♦ A♦ 10♦ J♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand), "Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestFullHouse1()
        {
            IHand hand = new Hand("10♠ Q♦ Q♠ 10♦ 10♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFullHouse(hand), "FullHouse is not identified correctly.");
        }

        [TestMethod]
        public void TestFullHouse2()
        {
            IHand hand = new Hand("5♠ 2♦ 2♠ 5♦ 2♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFullHouse(hand), "FullHouse is not identified correctly.");
        }

        [TestMethod]
        public void TestFullHouse3()
        {
            IHand hand = new Hand("10♠ A♥ A♠ 10♦ A♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFullHouse(hand), "FullHouse is not identified correctly.");
        }

        [TestMethod]
        public void TestFourOfAKind1()
        {
            IHand hand = new Hand("2♠ 2♣ A♠ 2♦ 2♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand), "Four of a kind is not identified correctly.");
        }

        [TestMethod]
        public void TestFourOfAKind2()
        {
            IHand hand = new Hand("K♠ K♣ 2♠ K♦ K♥");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand), "Four of a kind is not identified correctly.");
        }

        [TestMethod]
        public void TestFourOfAKind3()
        {
            IHand hand = new Hand("10♠ A♥ A♠ A♦ A♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand), "FullHouse is not identified correctly.");
        }

        [TestMethod]
        public void TestStraightFlush1()
        {
            IHand hand = new Hand("10♣ 9♣ 8♣ 7♣ 6♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraightFlush(hand), "Straight Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestStraightFlush2()
        {
            IHand hand = new Hand("10♣ Q♣ J♣ K♣ 9♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraightFlush(hand), "Straight Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestStraightFlush3()
        {
            IHand hand = new Hand("9♣ 8♣ 7♣ 6♣ 5♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraightFlush(hand), "Straight Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestStraightFlush4()
        {
            IHand hand = new Hand("9♣ 8♣ 7♣ 6♣ 4♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraightFlush(hand), "Straight Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestRoyalFlush1()
        {
            IHand hand = new Hand("A♣ 10♣ K♣ Q♣ J♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsRoyalFlush(hand), "Royal Flush is not identified correctly.");
        }
        
        [TestMethod]
        public void TestRoyalFlush2()
        {
            IHand hand = new Hand("A♣ 10♣ K♣ Q♣ 2♣");

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsRoyalFlush(hand), "Royal Flush is not identified correctly.");
        }
    }
}
