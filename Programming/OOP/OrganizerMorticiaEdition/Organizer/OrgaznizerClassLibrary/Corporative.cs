using System.Text;

namespace OrganizerClassLibrary
{
    public class Corporative : Contact
    {
        public string Fax { get; private set; }
        public string Bulstat { get; private set; }
        public string Sector { get; private set; }

        public Corporative(string name, string sector, string mobileNumber, string phoneNumber = "", string fax = "",
                           string bulstat = "", string address = "", string email = "", string website = "")
            : base(name, address, email, mobileNumber, phoneNumber, website)
        {
            this.Sector = sector;
            this.Bulstat = bulstat;
            this.Fax = fax;
        }

        //overriding methods
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("-----------Business Contact------------" + "\n");

            if (!string.IsNullOrEmpty(this.Name))
            {
                builder.Append("First Name: " + this.Name + "\n");
            }

            if (!string.IsNullOrEmpty(this.Sector))
            {
                builder.Append("Sector: " + this.Sector + "\n");
            }

            if (!string.IsNullOrEmpty(this.MobileNumber))
            {
                builder.Append("Mobile Number: " + this.MobileNumber + "\n");
            }

            if (!string.IsNullOrEmpty(this.PhoneNumber))
            {
                builder.Append("Phone Number: " + this.PhoneNumber + "\n");
            }

            if (!string.IsNullOrEmpty(this.Fax))
            {
                builder.Append("Fax Number: " + this.Fax + "\n");
            }

            if (!string.IsNullOrEmpty(this.Bulstat))
            {
                builder.Append("Bulstat: " + this.Bulstat + "\n");
            }

            if (!string.IsNullOrEmpty(this.Address))
            {
                builder.Append("Address: " + this.Address + "\n");
            }

            if (!string.IsNullOrEmpty(this.Email))
            {
                builder.Append("Email: " + this.Email + "\n");
            }

            if (!string.IsNullOrEmpty(this.Website))
            {
                builder.Append("Website: " + this.Website + "\n");
            }

            builder.Append("---------------------------------------" + "\n");

            return builder.ToString();
        }
    }
}
