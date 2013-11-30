
namespace PhoneBook
{

    using System;
    using System.Linq;
    using System.Text;

    class PhoneBookEntry
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneBookEntry(
            string fName, string mName,
            string lName, string town,
            string phoneNumber, string nickname = null)
        {
            this.FirstName = fName;
            this.MiddleName = mName;
            this.LastName = lName;
            this.NickName = nickname;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public PhoneBookEntry(
            string town, string phoneNumber, string nickname)
            : this(null, null, null, town, phoneNumber, nickname)
        {
        }

        public override string ToString()
        {
            string result;
            if (FirstName == null)
            {
                result = string.Format("{0} | {1} | {2}",
                    this.NickName, this.Town, this.PhoneNumber);
            }
            else
            {
                result = string.Format("{0} {1} {2} | {3} | {4}",
                    this.FirstName, this.MiddleName,
                    this.LastName, this.Town, this.PhoneNumber);
            }

            return result;
        }
    }
}
