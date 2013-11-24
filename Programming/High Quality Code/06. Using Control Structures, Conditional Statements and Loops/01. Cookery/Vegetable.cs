//-----------------------------------------------------------------------
// <copyright file="Vegetable.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Cookery
{
    using System;

    public abstract class Vegetable
    {
        public bool IsFresh { get; set; }

        public bool IsWashed { get; set; }

        public bool IsPeeled { get; set; }

        public bool IsRotten { get; set; }
    }
}
