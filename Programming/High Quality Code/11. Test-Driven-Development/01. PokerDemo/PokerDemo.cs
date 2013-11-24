//-----------------------------------------------------------------------
// <copyright file="PokerDemo.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace PokerDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker;

    /// <summary>
    /// Demo for the game.
    /// </summary>
    internal class PokerDemo
    {
        private static void Main()
        {
            try
            {
                IHand hand = new Hand(new List<ICard>() 
                { 
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                });
                Console.WriteLine(hand);
                IPokerHandsChecker checker = new PokerHandsChecker();

                Console.WriteLine(checker.IsValidHand(hand) ? "Hand is valid." : "Hand is not valid!");
                Console.WriteLine(checker.IsRoyalFlush(hand) ? "Royal flush." : "Hand is not Royal flush!");
                Console.WriteLine(checker.IsStraightFlush(hand) ? "Straight flush." : "Hand is not Straight flush!");
                Console.WriteLine(checker.IsFlush(hand) ? "Flush." : "Hand is not Flush!");
                Console.WriteLine(checker.IsStraight(hand) ? "Straight." : "Hand is not Straight!");
                Console.WriteLine(checker.IsFullHouse(hand) ? "Full house." : "Hand is not Full house!");
                Console.WriteLine(checker.IsFourOfAKind(hand) ? "Four of a kind." : "Hand is not Four of a kind!");
                Console.WriteLine(checker.IsThreeOfAKind(hand) ? "Three of a kind." : "Hand is not Three of a kind!");

                IHand hand1 = new Hand("K♥ J♥ 8♣ 7♦ 4♠");
                Console.WriteLine(hand1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
