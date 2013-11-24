//-----------------------------------------------------------------------
// <copyright file="Figure.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Abstraction
{
    using System;

    /// <summary>
    /// Represents a geometric figure.
    /// </summary>
    public abstract class Figure
    {
        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
