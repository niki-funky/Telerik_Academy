//-----------------------------------------------------------------------
// <copyright file="Card.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Poker
{
    using System;

    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            var face = Utilities.Faces[(int)this.Face - 2];
            var suit = Utilities.Suits[(int)this.Suit - 1];

            return face + suit;
        }
    }
}
