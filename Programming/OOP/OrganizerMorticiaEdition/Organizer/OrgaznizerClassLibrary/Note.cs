using OrganizerClassLibrary.Enums;
using OrganizerClassLibrary.Interfaces;
using System.Text;

namespace OrganizerClassLibrary
{
    public class Note : Event, IFileAttach
    {
        //properties
        public string NoteContent { get; private set; }
        public string AttachedFilePath { get; set; }

        //constructors
        public Note(string name, string noteContent = "", Color color = Color.Yellow, Priority priority = Priority.
                    Medium, string attachedFilePath = "", string comment = "")
            : base(name, color, priority, comment)
        {
            this.NoteContent = noteContent;
            this.AttachedFilePath = attachedFilePath;
        }

        //methods
        public void EditNote(string noteContent)
        {
            this.NoteContent = noteContent;
        }

        public void ClearNote()
        {
            this.NoteContent = string.Empty;
        }

        //overriding methods
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendFormat("-----------------Note------------------\n");
            if (!string.IsNullOrEmpty(this.Name))
                buffer.AppendFormat("Title: {0}\n", this.Name);

            if (!string.IsNullOrEmpty(this.NoteContent))
                buffer.AppendFormat("Content: {0}\n", this.NoteContent);

            if (!string.IsNullOrEmpty(this.Priority.ToString()))
                buffer.AppendFormat("Priority: {0}\n", this.Priority);

            if (!string.IsNullOrEmpty(this.Comment))
                buffer.AppendFormat("Comment: {0}\n", this.Comment);

            buffer.AppendFormat("---------------------------------------\n");

            return Utilities.TextColorChanger(buffer.ToString(), this.Color);
        }
    }
}
