using System.Text;

namespace OrganizerClassLibrary
{
    public class Friend : Person
    {
        // Properties
        public string Nickname { get; private set; }

        // Constructors
        public Friend(string name, string mobileNumber, string middleName = "", string lastName = "",
                      string nickname = "", string birthDate = "", string occupation = "",
                      string address = "", string email = "", string phoneNumber = "", string website = "")
            : base(name, middleName, lastName, birthDate, occupation, address, email, mobileNumber, phoneNumber, website)
        {
            this.Nickname = nickname;
        }

        // Methods
        public void EditNickname(string newNickname)
        {
            this.Nickname = newNickname;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("----------------Friend-----------------" + "\n");

            if (!string.IsNullOrEmpty(this.Name))
            {
                builder.Append("First Name: " + this.Name + "\n");
            }

            if (!string.IsNullOrEmpty(this.MiddleName))
            {
                builder.Append("Middle Name: " + this.MiddleName + "\n");
            }

            if (!string.IsNullOrEmpty(this.LastName))
            {
                builder.Append("Last Name: " + this.LastName + "\n");
            }

            if (!string.IsNullOrEmpty(this.BirthDate))
            {
                builder.Append("Birth Date: " + this.BirthDate + "\n");
            }

            if (!string.IsNullOrEmpty(this.Occupation))
            {
                builder.Append("Occupation: " + this.Occupation + "\n");
            }

            if (!string.IsNullOrEmpty(this.Address))
            {
                builder.Append("Address: " + this.Address + "\n");
            }

            if (!string.IsNullOrEmpty(this.Email))
            {
                builder.Append("Email: " + this.Email + "\n");
            }

            if (!string.IsNullOrEmpty(this.MobileNumber))
            {
                builder.Append("Mobile Number: " + this.MobileNumber + "\n");
            }

            if (!string.IsNullOrEmpty(this.PhoneNumber))
            {
                builder.Append("Phone Number: " + this.PhoneNumber + "\n");
            }

            if (!string.IsNullOrEmpty(this.Website))
            {
                builder.Append("Website: " + this.Website + "\n");
            }

            if (!string.IsNullOrEmpty(this.Nickname))
            {
                builder.Append("Nickname: " + this.Nickname + "\n");
            }

            builder.Append("---------------------------------------" + "\n");

            return builder.ToString();
        }
    }
}
