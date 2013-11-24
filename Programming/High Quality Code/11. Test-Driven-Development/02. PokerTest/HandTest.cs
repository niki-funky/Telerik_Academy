//-----------------------------------------------------------------------
// <copyright file="HandTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHand2()
        {
            IHand hand = new Hand(string.Empty);
        }

        [TestMethod]
        public void TestHandToString1()
        {
            ICard[] cards = new ICard[0];
            IHand hand = new Hand(cards);

            Assert.AreEqual(string.Empty, hand.ToString(), "Hand constructor does not work correctly.");
        }

        [TestMethod]
        public void TestHandToString2()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            Assert.AreEqual("3♥ 5♦ 10♠ Q♣ A♦", hand.ToString(), "Hand conversion to string was not successful.");
        }

        [TestMethod]
        public void TestHandToString3()
        {
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            });
            string expected = "A♥ A♥ A♥ A♥ A♥";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual, "Hand conversion to string was not successful.");
        }
    }
}
