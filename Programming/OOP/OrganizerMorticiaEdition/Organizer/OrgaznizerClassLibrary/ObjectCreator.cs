using OrganizerClassLibrary;
using OrganizerClassLibrary.Enums;
using System;

namespace OrgaznizerClassLibrary
{
    public static class ObjectCreator
    {
        public static void CreateEmail(OrganizerCore core, string sendTo, string subject, string body, string filePath, string comment="")
        {
            Email email = new Email(sendTo, subject, body, filePath, comment);
            core.AddObject(email);
            email.SendEmail();
            Utilities.PrintColorMessage(String.Format("The Email was created and sent."), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateFriend(OrganizerCore core, string name, string mobileNumber, string middleName, string lastName,
            string nickname, string birthDate, string occupation, string address, string email, string phoneNumber, string website)
        {
            Friend friend = new Friend(name, mobileNumber, middleName, lastName, nickname, birthDate, occupation, address, email,
                phoneNumber, website);
            core.AddObject(friend);
            Utilities.PrintColorMessage(String.Format("The Friend contact \"{0}\" is created", friend.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateFamilyMember(OrganizerCore core, string name, string mobileNumber, byte familyMemberType, byte bloodGroup,
            string middleName, string lastName, string birthDate, string egn, string occupation, string address, string email,
            string phoneNumber, string website)
        {
            FamilyMember familyMember = new FamilyMember(name, mobileNumber, (FamilyTreeMember)familyMemberType,
                (BloodGroupType)bloodGroup, middleName, lastName, birthDate,
                egn, occupation, address, email, phoneNumber, website);
            core.AddObject(familyMember);
            Utilities.PrintColorMessage(String.Format("The Family member contact \"{0}\" is created", familyMember.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateBusiness(OrganizerCore core, string name, string mobileNumber, string organization, string middleName,
            string lastName, string birthDate, string occupation, string address, string email)
        {
            Business business = new Business(name, mobileNumber, organization, middleName, lastName, birthDate, occupation, address, email);
            core.AddObject(business);
            Utilities.PrintColorMessage(String.Format("The Business contact \"{0}\" is created", business.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateCorporative(OrganizerCore core, string name, string sector, string mobileNumber, string phoneNumber,
            string fax, string bulstat, string address, string email, string website)
        {
            Corporative corporation = new Corporative(name, sector, mobileNumber, phoneNumber, fax, bulstat, address, email, website);
            core.AddObject(corporation);
            Utilities.PrintColorMessage(String.Format("The Corporative contact \"{0}\" is created", corporation.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateProject(OrganizerCore core, string name, byte colorChoice, string comment, byte priority)
        {
            Project project = new Project(name, (Color)colorChoice, (Priority)priority, comment);
            core.AddObject(project);
            Utilities.PrintColorMessage(String.Format("The Project \"{0}\" is created", project.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateCategory(OrganizerCore core, string name, string project, byte color, byte priority, string comment)
        {
            Category category = new Category(name, project, (Color)color, (Priority)priority, comment);
            core.AddObject(category);
            Utilities.PrintColorMessage(String.Format("The Category \"{0}\" is created", category.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateTask(OrganizerCore core, string name, string category, byte color, byte priority, string location, string comment)
        {
            OrganizerClassLibrary.Task task = new OrganizerClassLibrary.Task(name, category, (Color)color, (Priority)priority, location, comment);
            core.AddObject(task);
            Utilities.PrintColorMessage(String.Format("The Task: \"{0}\" is created" + "\n", task.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateTaskWithReminder(OrganizerCore core, string name, string message, string category, byte color, byte priority, string location, string comment)
        {
            OrganizerClassLibrary.Task task = new OrganizerClassLibrary.Task(name, message, category, (Color)color, (Priority)priority, location, comment);
            core.AddObject(task);
            Utilities.PrintColorMessage(String.Format("The Task: \"{0}\" is created", task.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }

        public static void CreateNote(OrganizerCore core, string name, string text, byte color, byte priority, string filePath, string comment)
        {
            Note note = new Note(name, text, (Color)color, (Priority)priority, filePath, comment);
            core.AddObject(note);
            Utilities.PrintColorMessage(String.Format("The Note \"{0}\" is created", note.Name), Color.Blue);
            Utilities.GoToMainMenu(core);
        }
    }
}
