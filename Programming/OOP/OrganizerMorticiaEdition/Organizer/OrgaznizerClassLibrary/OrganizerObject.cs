
namespace OrganizerClassLibrary
{
    public abstract class OrganizerObject
    {
        public string Name { get; protected set; }
        public string Comment { get; protected set; }

        protected OrganizerObject(string name, string comment = "")
        {
            this.Name = name;
            this.Comment = comment;
        }

        public virtual void ChangeName(string name)
        {
            this.Name = name;
        }

        public virtual void SetComment(string comment)
        {
            this.Comment = comment;
        }

        public virtual void ClearComment()
        {
            this.Comment = string.Empty;
        }
    }
}
