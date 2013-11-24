//-----------------------------------------------------------------------
// <copyright file="ICard.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Poker
{
    using System;

    public interface ICard
    {
        CardFace Face { get; }

        CardSuit Suit { get; }

        string ToString();
    }
}
