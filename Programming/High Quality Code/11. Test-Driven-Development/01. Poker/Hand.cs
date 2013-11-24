//-----------------------------------------------------------------------
// <copyright file="Hand.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("Cards cannot be null!");
            }

            this.Cards = cards;

            this.SortHand();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand" /> class.
        /// </summary>
        /// <param name="cards">String with cards.</param>
        public Hand(string cards)
        {
            if (string.IsNullOrWhiteSpace(cards))
            {
                throw new ArgumentException("Cards cannot be null or empty!");
            }

            string[] names = cards.Trim().Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            this.Cards = new ICard[names.Length];

            for (int i = 0; i < this.Cards.Count; i++)
            {
                int nameLength = names[i].Length;
                int faceNumber = Array.IndexOf(Utilities.Faces, names[i].Substring(0, nameLength - 1));
                int suitnumber = Array.IndexOf(Utilities.Suits, names[i][nameLength - 1]);

                CardFace face = (CardFace)faceNumber + 2;
                CardSuit suit = (CardSuit)suitnumber + 1;

                this.Cards[i] = new Card(face, suit);
            }

            this.SortHand();
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            return string.Join<ICard>(" ", this.Cards);
        }

        private void SortHand()
        {
            this.Cards = this.Cards.OrderBy(card => card.Face).ToList();
        }
    }
}
