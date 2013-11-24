namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds phone entry to the phone book.
        /// </summary>
        /// <param name="name">Name of the entry.</param>
        /// <param name="phoneNumbers">Numbers of the entry.</param>
        /// <returns>Returns true if successful, otherwise false.</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes all phone numbers matching given number,
        /// with another phone number.
        /// </summary>
        /// <param name="oldPhoneNumber">Number to match.</param>
        /// <param name="newPhoneNumber">Number to place.</param>
        /// <returns>Return the count of the changed numbers.</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Lists a given number of phone entries starting from given index.
        /// </summary>
        /// <param name="startIndex">Index of start.</param>
        /// <param name="count">Count of phone entries.</param>
        /// <returns>Returns list with the founded phone entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <p><paramref name="startIndex"/> startIndex < 0  </p>
        ///     <p><paramref name="count"/> count bigger than number of all entries </p>
        /// </exception>
        PhoneEntry[] ListPhoneEntries(int startIndex, int count);
    }
}
