
namespace OrgaznizerClassLibrary.Structs
{
    public struct ObjectCounter
    {
        public int Contacts { get; private set; }
        public int Events { get; private set; }
        public int Emails { get; private set; }

        public void IncreaseContacts()
        {
            this.Contacts++;
        }

        public void IncreaseEvents()
        {
            this.Events++;
        }

        public void IncreaseEmails()
        {
            this.Emails++;
        }
    }
}
