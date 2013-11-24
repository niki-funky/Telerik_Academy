using OrganizerClassLibrary;
using OrganizerClassLibrary.Enums;
using OrganizerClassLibrary.UserInterfaceClasses;
using System;
using System.Globalization;

namespace Demo
{
    class Demo
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            OrganizerCore core = OrganizerCore.GetOrganizerCoreInstance();
            OrganizerCore.Initialize(core);
            UserInterface.MainMenu(core);
            core.PrintTotalObjectsCreated();


            Friend tzanko = new Friend("Tzanko", "tzanko@gmail.com", nickname: "Jujo");
            Console.WriteLine(tzanko);

            FamilyMember mother = new FamilyMember("Tzvetanka", "0888123123", FamilyTreeMember.Mother);
            Console.WriteLine(mother);

            Business theBoss = new Business("Nikolay", "0888456456", "Telerik LTD");
            Console.WriteLine(theBoss);

            Note note = new Note("Important Note", "Hello World!!! How's going ?", Color.Red, Priority.High, "Not so important");
            Console.WriteLine(note);

            Project project = new Project("The Green Project", Color.Green, Priority.Low, "Best project ever");
            Console.WriteLine(project);

            Category category = new Category("Tourism", "The Green Project", color: Color.Yellow, comment: "Summer vacation");
            Console.WriteLine(category);

            OrganizerClassLibrary.Task idea = new Task("Idea for project", color: Color.Cyan);
            Console.WriteLine(idea);

            Utilities.ResetConsoleColor();
        }
    }
}
