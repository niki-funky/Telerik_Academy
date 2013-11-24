//-----------------------------------------------------------------------
// <copyright file="IHand.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Collections.Generic;

    public interface IHand
    {
        IList<ICard> Cards { get; }

        string ToString();
    }
}
