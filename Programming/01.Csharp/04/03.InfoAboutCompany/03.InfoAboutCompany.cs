using System;

namespace ConsoleInputOutput
{
    class InfoAboutCompany
    {
        //A company has name, address, phone number, fax number, web site and manager. 
        //The manager has first name, last name, age and a phone number. 
        //Write a program that reads the information about a company and 
        //its manager and prints them on the console.

        static void Main()
        {
            //variables
            Console.Write("Enter company Name : ");
            string companyName = Console.ReadLine();
            Console.Write("Enter company Address : ");
            string companyAddress = Console.ReadLine();
            Console.Write("Enter company Phone number : ");
            string companyPhoneNumber = Console.ReadLine();
            Console.Write("Enter company fax number : ");
            string companyFaxNumber = Console.ReadLine();
            Console.Write("Enter company Web site : ");
            string companyWebSite = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter manager First name : ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Enter manager Last name : ");
            string managerLastName = Console.ReadLine();
            Console.Write("Enter manager Age : ");
            string managerAge = Console.ReadLine();
            Console.Write("Enter manager Phone number : ");
            string managerPhoneNumber = Console.ReadLine();
            Console.WriteLine();

            //write company info
            Console.WriteLine("Company Information : \n name : {0}\n address : {1}\n phone : {2}\n fax : {3}\n web site : {4}\n",
                companyName, companyAddress, companyPhoneNumber, companyFaxNumber, companyWebSite);
            //write manager info
            Console.WriteLine("Manager Information : \n fisrt name : {0}\n last name : {1}\n age : {2}\n phone : {3}",
                managerFirstName, managerLastName, managerAge, managerPhoneNumber);
        }
    }
}
