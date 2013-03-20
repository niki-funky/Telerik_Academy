
namespace OrganizerClassLibrary
{
    public abstract class Person : Contact
    {
        // Properties
        protected string MiddleName { get; private set; }
        protected string LastName { get; private set; }
        protected string BirthDate { get; private set; }
        protected string Occupation { get; private set; }

        // Constructors
        protected Person(string name, string mobileNumber, string middleName="", string lastName="", string birthDate="", string occupation="", 
            string address="", string email="", string phoneNumber="", string website="")
            : base(name, address, email, mobileNumber, phoneNumber, website)
        {
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Occupation = occupation;
        }

        // Methods
        public virtual void EditMiddleName(string newName)
        {
            this.MiddleName = newName;
        }

        public virtual void EditLastName(string newName)
        {
            this.LastName = newName;
        }

        public virtual void EditBirthDate(string newDate)
        {
            this.BirthDate = newDate;
        }

        public virtual void EditOccupation(string newOccupation)
        {
            this.Occupation = newOccupation;
        }
    }
}
