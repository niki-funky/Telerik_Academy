using OrganizerClassLibrary.Enums;
using System.Text;

namespace OrganizerClassLibrary
{
    public class FamilyMember : Person
    {
        // Properties
        public FamilyTreeMember FamilyMemberType { get; private set; }
        public BloodGroupType BloodGroup { get; private set; }
        public string Egn { get; private set; }

        // Constructors
        public FamilyMember(string name, string mobileNumber, FamilyTreeMember familyMemberType,
            BloodGroupType bloodGroup = BloodGroupType.NotSpecified, string middleName = "", string lastName = "",
            string birthDate = "", string egn = "", string occupation = "", string address = "", string email = "",
            string phoneNumber = "", string website = "")
            : base(name, mobileNumber, middleName, lastName, birthDate, occupation, address, email, phoneNumber, website)
        {
            this.FamilyMemberType = familyMemberType;
            this.BloodGroup = bloodGroup;
            this.Egn = egn;
        }

        // Methods
        public void EditFamilyMemberType(FamilyTreeMember newFamilyMemberType)
        {
            this.FamilyMemberType = newFamilyMemberType;
        }

        public void EditBloodGroupType(BloodGroupType newBloodGroupType)
        {
            this.BloodGroup = newBloodGroupType;
        }

        public void EditEgn(string newEgn)
        {
            this.Egn = newEgn;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("-------------Family Member-------------" + "\n");

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

            builder.Append("Family Member Type: " + this.FamilyMemberType + "\n");

            if (this.BloodGroup != BloodGroupType.NotSpecified)
            {
                builder.Append("Blood Group: " + this.BloodGroup + "\n");
            }

            if (!string.IsNullOrEmpty(this.Egn))
            {
                builder.Append("EGN: " + this.Egn + "\n");
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

            builder.Append("---------------------------------------" + "\n");

            return builder.ToString();
        }
    }
}
