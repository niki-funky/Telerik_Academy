using OrganizerClassLibrary.Enums;

namespace OrganizerClassLibrary
{
    public abstract class Event : OrganizerObject
    {
        //fields
        public Color Color { get; protected set; }
        public Priority Priority { get; protected set; }

        //constructors
        protected Event(string name, Color color = Color.Black, Priority priority = Priority.Medium, string comment = "")
            : base(name, comment)
        {
            this.Color = color;
            this.Priority = priority;
        }

        //methods
        public virtual void ChangeColor(Color color)
        {
            this.Color = color;
        }

        public virtual void ChangePriority(Priority priority)
        {
            this.Priority = priority;
        }
    }
}
