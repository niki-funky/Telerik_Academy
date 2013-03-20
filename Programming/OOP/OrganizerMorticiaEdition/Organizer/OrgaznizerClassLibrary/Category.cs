using OrganizerClassLibrary.Enums;
using System.Text;

namespace OrganizerClassLibrary
{
    public class Category : Event
    {
        //properties
        public string Project { get; private set; }

        //constructor
        public Category(string name, string project = "", Color color = Color.Blue, Priority priority = Priority.Medium, string comment = "")
            : base(name, color, priority, comment)
        {
            this.Project = project;
        }

        //overriding methods
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append("----------------Category---------------\n");

            if (!string.IsNullOrEmpty(this.Name))
                buffer.AppendFormat("Title: {0}\n", this.Name);

            if (!string.IsNullOrEmpty(this.Project.ToString()))
                buffer.AppendFormat("In project: {0}\n", this.Project);

            if (!string.IsNullOrEmpty(this.Priority.ToString()))
                buffer.AppendFormat("Priority: {0}\n", this.Priority);

            if (!string.IsNullOrEmpty(this.Comment))
                buffer.AppendFormat("Comment: {0}\n", this.Comment);

            buffer.Append("---------------------------------------\n");

            return Utilities.TextColorChanger(buffer.ToString(), this.Color);
        }
    }
}
