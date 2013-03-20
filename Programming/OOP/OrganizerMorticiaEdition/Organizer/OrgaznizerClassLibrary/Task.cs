using OrganizerClassLibrary.Enums;
using System;
using System.Text;
using System.Windows.Forms;

namespace OrganizerClassLibrary
{
    public class Task : Event
    {
        //properties
        public string Location { get; private set; }
        public string CategoryType { get; private set; }
        public Reminder Reminder { get; set; }

        //constructors
        public Task(string name, string category = "to-do", Color color = Color.Magenta,
            Priority priority = Priority.Medium, string location = "", string comment = "")
            : base(name, color, priority, comment)
        {
            this.Location = location;
            this.CategoryType = category;
        }

        public Task(string name, string message, string category = "to-do", Color color = Color.Magenta,
            Priority priority = Priority.Medium, string location = "", string comment = "")
            : this(name, category, color, priority, location, comment)
        {
            Console.Write("Enter DueDate[20.03.2013 16:45]: ");
            this.Reminder = new Reminder(DateTime.Parse(Console.ReadLine()), message);
            Reminder.Alarm += (sender, e) => MessageBox.Show(Reminder.Message);
            Reminder.Alarm += (sender, e) => Beep();
        }

        //methods
        public void ChangeLocation(string location)
        {
            this.Location = location;
        }

        public void ChangeCategoryType(string category)
        {
            this.CategoryType = category;
        }

        //melody
        private void Beep()
        {
            for (int i = 37; i <= 32767; i += 200)
            {
                Console.Beep(i, 100);
            }
        }

        //overriding methods
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine("------------------Task-----------------");

            if (!string.IsNullOrEmpty(this.Name))
            {
                buffer.AppendLine("Name: " + this.Name);
            }

            if (!string.IsNullOrEmpty(this.CategoryType))
            {
                buffer.AppendLine("Category: " + this.CategoryType);
            }

            buffer.AppendLine("Priority: " + this.Priority);

            if (!string.IsNullOrEmpty(this.Location))
            {
                buffer.AppendLine("Location: " + this.Location);
            }

            if (!string.IsNullOrEmpty(this.Comment))
            {
                buffer.AppendLine("Comment: " + this.Comment);
            }

            buffer.AppendLine("---------------------------------------");

            return Utilities.TextColorChanger(buffer.ToString(), this.Color);
        }
    }
}
