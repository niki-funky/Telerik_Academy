using System;

namespace OrganizerClassLibrary.UserInterfaceClasses
{
    public static class UserInterface
    {
        public static void MainMenu(OrganizerCore core)
        {
            try
            {
                UIMessages.WelcomeMessage();
                UIMessages.MainMenuMessage();
                UIMessages.PrintSelectMessage();
                byte userChoice = byte.Parse(UserInput.InputUser());

                switch (userChoice)
                {
                    case 1: EventMenu(core); break;
                    case 2: ContactMenu(core); break;
                    case 3: UserInput.InputEmail(core); break;
                    case 10: break;
                    default: throw new OrganizerException("Invalid Choice!");
                }
            }
            catch (Exception oex)
            {
                Console.WriteLine(oex.Message);
                MainMenu(core);
            }
        }

        public static void ContactMenu(OrganizerCore core)
        {
            try
            {
                UIMessages.ContactMenuMessage();
                UIMessages.PrintSelectMessage();
                byte userChoice = byte.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 0: MainMenu(core); break;
                    case 1: UserInput.InputCorporative(core); break;
                    case 2: PersonMenu(core); break;
                    case 10: break;
                    default: throw new OrganizerException("Invalid Choice!");
                }
            }
            catch (OrganizerException oex)
            {
                Console.WriteLine(oex.Message);
                ContactMenu(core);
            }
        }

        public static void PersonMenu(OrganizerCore core)
        {
            try
            {
                UIMessages.PersonMenuMessage();
                UIMessages.PrintSelectMessage();
                byte userChoice = byte.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 0: ContactMenu(core); break;
                    case 1: UserInput.InputBusiness(core); break;
                    case 2: UserInput.InputFamilyMember(core); break;
                    case 3: UserInput.InputFriend(core); break;
                    case 10: break;
                    default: throw new OrganizerException("Invalid Choice!");
                }
            }
            catch (OrganizerException oex)
            {
                Console.WriteLine(oex.Message);
                PersonMenu(core);
            }
        }

        public static void EventMenu(OrganizerCore core)
        {
            try
            {
                UIMessages.EventMenuMessage();
                UIMessages.PrintSelectMessage();
                byte userChoice = byte.Parse(UserInput.InputUser());

                switch (userChoice)
                {
                    case 0: MainMenu(core); break;
                    case 1: UserInput.InputCategory(core); break;
                    case 2: UserInput.InputNote(core); break;
                    case 3: UserInput.InputProject(core); break;
                    case 4: UserInput.InputTask(core); break;
                    case 5: UserInput.InputTaskWithReminder(core); break;
                    case 10: break;
                    default: throw new OrganizerException("Invalid Choice!");
                }
            }
            catch (OrganizerException oex)
            {
                Console.WriteLine(oex.Message);
                EventMenu(core);
            }
        }
    }
}
