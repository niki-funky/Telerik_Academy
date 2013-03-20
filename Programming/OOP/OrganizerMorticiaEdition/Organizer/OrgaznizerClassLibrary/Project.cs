using OrganizerClassLibrary.Enums;
using System.Text;

namespace OrganizerClassLibrary
{
    public class Project : Event
    {
        //constructors
        public Project(string name, Color color = Color.DarkYellow, Priority priority = Priority.Medium, string comment = "")
            : base(name, color, priority, comment)
        {
        }

        //overriding methods
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append("----------------Project----------------\n");
            if (!string.IsNullOrEmpty(this.Name))
                buffer.AppendFormat("Title: {0}\n", this.Name);

            if (!string.IsNullOrEmpty(this.Priority.ToString()))
                buffer.AppendFormat("Priority: {0}\n", this.Priority);

            if (!string.IsNullOrEmpty(this.Comment))
                buffer.AppendFormat("Comment: {0}\n", this.Comment);

            buffer.Append("---------------------------------------\n");

            return Utilities.TextColorChanger(buffer.ToString(), this.Color);
        }
    }
}
