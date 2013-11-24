using OrganizerClassLibrary.Enums;
using OrgaznizerClassLibrary;
using System;

namespace OrganizerClassLibrary.UserInterfaceClasses
{
    public static class UserInput
    {
        #region Public Methods

        public static void InputEmail(OrganizerCore core)
        {
            string sendTo = SentToInput();
            string subject = SubjectInput();
            string textBody = TextInput();
            string filePath = FilePathInput();

            ObjectCreator.CreateEmail(core, sendTo, subject, textBody, filePath);
        }

        public static void InputProject(OrganizerCore core)
        {
            string name = NameInput();
            byte priority = PriorityInput();
            byte color = ColorInput();
            string comment = CommentInput();
            
            ObjectCreator.CreateProject(core, name, color, comment, priority);
        }

        public static void InputTask(OrganizerCore core)
        {
            string name = NameInput();
            string category = CategoryInput();
            byte priority = PriorityInput();
            byte color = ColorInput();
            string location = LocationInput();
            string comment = CommentInput();

            ObjectCreator.CreateTask(core, name, category, color, priority, location, comment);
        }

        public static void InputTaskWithReminder(OrganizerCore core)
        {
            string name = NameInput();
            string category = CategoryInput();
            byte priority = PriorityInput();
            byte color = ColorInput();
            string location = LocationInput();
            string comment = CommentInput();
            string message = ReminderMessageInput();

            ObjectCreator.CreateTaskWithReminder(core, name, message, category, color, priority, location, comment);
        }

        public static void InputNote(OrganizerCore core)
        {
            string name = NameInput();
            string text = TextInput();
            string filePath = FilePathInput();
            byte priority = PriorityInput();
            byte color = ColorInput();
            string comment = CommentInput();

            ObjectCreator.CreateNote(core, name, text, color, priority, filePath, comment);
        }

        public static void InputCategory(OrganizerCore core)
        {
            string name = NameInput();
            string project = ProjectInput();
            byte color = ColorInput();
            byte priority = PriorityInput();
            string comment = CommentInput();

            ObjectCreator.CreateCategory(core, name, project, color, priority, comment);
        }

        public static void InputFriend(OrganizerCore core)
        {
            string name = NameInput();
            string nickname = NicknameInput();
            string middleName = MiddleNameInput();
            string lastName = LastNameInput();
            string mobileNumber = MobileNumberInput();
            string phoneNumber = PhoneNumberInput();
            string occupation = OccupationInput();
            string email = EmailInput();
            string website = WebSiteInput();
            string address = AddressInput();
            string birthdate = BirthDateInput();
            string comment = CommentInput();

            ObjectCreator.CreateFriend(core, name, mobileNumber, middleName, lastName, 
                nickname, birthdate, occupation, address, email, phoneNumber, website);
        }

        public static void InputFamilyMember(OrganizerCore core)
        {
            string name = NameInput();
            string middleName = MiddleNameInput();
            string lastName = LastNameInput();
            string mobileNumber = MobileNumberInput();
            string phoneNumber = PhoneNumberInput();
            byte familyMemberType = FamilyMemberTypeInput();
            string egn = EgnInput();
            byte bloodGroup = BloodGroupInput();
            string occupation = OccupationInput();
            string email = EmailInput();
            string website = WebSiteInput();
            string address = AddressInput();
            string birthdate = BirthDateInput();
            string comment = CommentInput();

            ObjectCreator.CreateFamilyMember(core, name, mobileNumber, familyMemberType, bloodGroup, middleName, lastName, birthdate,
                egn, occupation, address, email, phoneNumber, website);
        }

        public static void InputBusiness(OrganizerCore core)
        {
            string name = NameInput();
            string middleName = MiddleNameInput();
            string lastName = LastNameInput();
            string mobileNumber = MobileNumberInput();
            string organization = OrganizationInput();
            string occupation = OccupationInput();
            string email = EmailInput();
            string address = AddressInput();
            string birthdate = BirthDateInput();
            string comment = CommentInput();

            ObjectCreator.CreateBusiness(core, name, mobileNumber, organization, middleName, lastName, birthdate, occupation, address, email);
        }

        public static void InputCorporative(OrganizerCore core)
        {
            string name = NameInput();
            string phone = PhoneNumberInput();
            string mobileNumber = MobileNumberInput();
            string email = EmailInput();
            string website = WebSiteInput();
            string address = AddressInput();
            string attFile = FilePathInput();
            string bulstat = BulstatInput();
            string fax = FaxInput();
            string sector = SectorInput();
            string comment = CommentInput();

            ObjectCreator.CreateCorporative(core, name, sector, mobileNumber, phone, fax, bulstat, address, email, website);
        }

        public static string InputUser()
        {
            return Console.ReadLine();
        }

        #endregion

        #region Private Methods

        private static string SentToInput()
        {
            UIMessages.PrintSendToMessage();
            string sendTo = InputUser();

            return sendTo;
        }

        private static string SubjectInput()
        {
            UIMessages.PrintSubjectMessage();
            string subject = InputUser();

            return subject;
        }

        private static string WebSiteInput()
        {
            UIMessages.PrintWebSiteMessage();
            string website = InputUser();

            return website;
        }

        private static string PhoneNumberInput()
        {
            UIMessages.PrintPhoneNumberMessage();
            string phoneNumber = InputUser();

            return phoneNumber;
        }

        private static string MobileNumberInput()
        {
            UIMessages.PrintMobileNumberMessage();
            string mobile = InputUser();

            return mobile;
        }

        private static string EmailInput()
        {
            UIMessages.PrintEmailMessage();
            string email = InputUser();

            return email;
        }

        private static string AddressInput()
        {
            UIMessages.PrintAddressMessage();
            string address = InputUser();

            return address;
        }

        private static string NicknameInput()
        {
            UIMessages.PrintNicknameMessage();
            string nickname = InputUser();

            return nickname;
        }

        private static byte FamilyMemberTypeInput()
        {
            UIMessages.PrintSelectFromMessage();
            UIMessages.PrintEnumElements<FamilyTreeMember>(Utilities.EnumToList<FamilyTreeMember>());
            UIMessages.PrintFamilyTreeMemberMessage();
            byte familyTreeMember = byte.Parse(InputUser());
            Console.WriteLine();

            return familyTreeMember;
        }

        private static string EgnInput()
        {
            UIMessages.PrintEgnMessage();
            string egn = InputUser();

            return egn;
        }

        private static byte BloodGroupInput()
        {
            UIMessages.PrintSelectFromMessage();
            UIMessages.PrintEnumElements<BloodGroupType>(Utilities.EnumToList<BloodGroupType>());
            UIMessages.PrintBloodGroupMessage();
            byte bloodGroup = byte.Parse(InputUser());
            Console.WriteLine();

            return bloodGroup;
        }

        private static string OrganizationInput()
        {
            UIMessages.PrintOrganizationMessage();
            string organization = InputUser();

            return organization;
        }

        private static string SectorInput()
        {
            UIMessages.PrintSectorMessage();
            string sector = InputUser();

            return sector;
        }

        private static string FaxInput()
        {
            UIMessages.PrintFaxMessage();
            string fax = InputUser();

            return fax;
        }

        private static string BulstatInput()
        {
            UIMessages.PrintBulstatMessage();
            string bulstat = InputUser();

            return bulstat;
        }

        private static string BirthDateInput()
        {
            UIMessages.PrintBirthDateMessage();
            string birthdate = InputUser();

            return birthdate;
        }

        private static string OccupationInput()
        {
            UIMessages.PrintOccupationMessage();
            string occupation = InputUser();

            return occupation;
        }

        private static string LastNameInput()
        {
            UIMessages.PrintLastNameMessage();
            string lastName = InputUser();

            return lastName;
        }

        private static string MiddleNameInput()
        {
            UIMessages.PrintMiddleNameMessage();
            string middleName = InputUser();

            return middleName;
        }

        private static string CommentInput()
        {
            UIMessages.PrintCommentMessage();
            string comment = InputUser();

            return comment;
        }

        private static string ReminderMessageInput()
        {
            UIMessages.PrintReminderMessage();
            string message = InputUser();

            return message;
        }

        private static byte ColorInput()
        {
            UIMessages.PrintSelectFromMessage();
            UIMessages.PrintEnumElements(Utilities.EnumToList<Color>());
            UIMessages.PrintSelectMessage();
            byte colorChoice = byte.Parse(InputUser());
            Console.WriteLine();

            return colorChoice;
        }

        private static byte PriorityInput()
        {
            UIMessages.PrintSelectFromMessage();
            UIMessages.PrintEnumElements(Utilities.EnumToList<Priority>());
            UIMessages.PrintSelectMessage();
            byte priorityChoice = byte.Parse(InputUser());
            Console.WriteLine();

            return priorityChoice;
        }

        private static string NameInput()
        {
            UIMessages.PrintNameMessage();
            string name = InputUser();

            return name;
        }

        private static string LocationInput()
        {
            UIMessages.PrintLocationMessage();
            string location = InputUser();

            return location;
        }

        private static string CategoryInput()
        {
            UIMessages.PrintCategoryMessage();
            string category = InputUser();

            return category;
        }

        private static string ProjectInput()
        {
            UIMessages.PrintProjectMessage();
            string project = InputUser();

            return project;
        }

        private static string FilePathInput()
        {
            UIMessages.PrintAttFilePathMessage();
            string filePath = InputUser();

            return filePath;
        }

        private static string TextInput()
        {
            UIMessages.PrintTextMessage();
            string text = InputUser();

            return text;
        }

        #endregion
    }
}
