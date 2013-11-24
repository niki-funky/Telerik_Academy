//-----------------------------------------------------------------------
// <copyright file="PokerHandsChecker.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }

            if (5 > hand.Cards.Count || hand.Cards.Count > 5)
            {
                return false;
            }

            // Finds duplicate cards in the hand
            var duplicates = hand.Cards.GroupBy(
                c => new { Face = c.Face, Suit = c.Suit },
                c => c).Where(g => g.Count() > 1).ToList();

            if (duplicates.Count > 0)
            {
                return false;
            }

            return true;
        }

        public bool IsRoyalFlush(IHand hand)
        {
            if (this.CheckSuits(hand).Count == 1)
            {
                // check if first card in the hand is Ten(10)
                // and if all cards in the hand are consecutive
                if ((int)hand.Cards[0].Face == 10 && this.AreAllConsecutive(hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (this.CheckSuits(hand).Count == 1)
            {
                // check if first card in the hand is not Ten(10)
                // and if all cards in the hand are consecutive
                if ((int)hand.Cards[0].Face != 10 && this.AreAllConsecutive(hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var numberOfFaces = this.CheckFaces(hand);
            if (numberOfFaces.Count == 2)
            {
                if (numberOfFaces[0].Count() == 1 || numberOfFaces[0].Count() == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            var numberOfFaces = this.CheckFaces(hand);
            if (numberOfFaces.Count == 2)
            {
                if (numberOfFaces[0].Count() == 2 || numberOfFaces[0].Count() == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (this.CheckSuits(hand).Count == 1)
            {
                if (!this.AreAllConsecutive(hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            if (this.CheckSuits(hand).Count >= 2)
            {
                if (this.AreAllConsecutive(hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            var numberOfFaces = this.CheckFaces(hand);
            if (numberOfFaces.Count == 3)
            {
                if (numberOfFaces.Any(g => g.Count() == 3))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            var numberOfFaces = this.CheckFaces(hand);
            if (numberOfFaces.Count == 3)
            {
                if (numberOfFaces.Any(g => g.Count() == 2))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            var numberOfFaces = this.CheckFaces(hand);
            if (numberOfFaces.Count == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (this.CheckSuits(hand).Count >= 2 && !this.AreAllConsecutive(hand) && this.CheckFaces(hand).Count == 5)
            {
                return true;
            }

            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool AreAllConsecutive(IHand hand)
        {
            var areAllConsecutive = hand.Cards.Select((i, j) => (int)i.Face - j).Distinct().Skip(1).Any();

            return !areAllConsecutive;
        }

        private List<IGrouping<Poker.CardSuit, ICard>> CheckSuits(IHand hand)
        {
            var differentSuits = hand.Cards.GroupBy(c => c.Suit).ToList();

            return differentSuits;
        }

        private List<IGrouping<Poker.CardFace, ICard>> CheckFaces(IHand hand)
        {
            var faceGroups = hand.Cards.GroupBy(c => c.Face).ToList();

            return faceGroups;
        }
    }
}
