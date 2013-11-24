//-----------------------------------------------------------------------
// <copyright file="CardTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace PokerTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestCardToString1()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            Assert.AreEqual("2♣", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestCardToString2()
        {
            Card card = new Card(CardFace.King, CardSuit.Diamonds);
            Assert.AreEqual("K♦", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestCardToString3()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.AreEqual("A♥", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestCardToString4()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Spades);
            Assert.AreEqual("10♠", card.ToString(), "Card conversion to string is incorrect.");
        }
    }
}
