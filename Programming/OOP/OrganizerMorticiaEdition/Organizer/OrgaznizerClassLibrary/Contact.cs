using OrganizerClassLibrary.Interfaces;

namespace OrganizerClassLibrary
{
    public abstract class Contact : OrganizerObject, IFileAttach
    {
        // Properties
        protected string Address { get; private set; }
        protected string Email { get; private set; }
        protected string MobileNumber { get; private set; }
        protected string PhoneNumber { get; private set; }
        protected string Website { get; private set; }
        public string AttachedFilePath { get; set; }

        // Constructors
        protected Contact(string name, string address = "", string email = "",
            string mobileNumber = "", string phoneNumber = "", string website = "", string attachedFilePath = "")
            : base(name)
        {
            this.Address = address;
            this.Email = email;
            this.MobileNumber = mobileNumber;
            this.PhoneNumber = phoneNumber;
            this.Website = website;
            this.AttachedFilePath = attachedFilePath;
        }

        // Methods
        public virtual void EditName(string newName)
        {
            this.ChangeName(newName);
        }

        public virtual void EditAddress(string newAddress)
        {
            this.Address = newAddress;
        }

        public virtual void EditEmail(string newEmail)
        {
            this.Email = newEmail;
        }

        public virtual void EditMobileNumber(string newNumber)
        {
            this.MobileNumber = newNumber;
        }

        public virtual void EditPhoneNumber(string newNumber)
        {
            this.PhoneNumber = newNumber;
        }

        public virtual void EditWebsite(string newWebsite)
        {
            this.Website = newWebsite;
        }
    }
}
