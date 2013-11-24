//-----------------------------------------------------------------------
// <copyright file="FileUtilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Performs operations on filenames.
    /// </summary>
    public class FileUtilities
    {
        public static string GetFileExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("FileName is null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "File has no extension.";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("FileName is null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
