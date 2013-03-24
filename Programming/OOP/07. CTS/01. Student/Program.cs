using System;
using System.Linq;

namespace Student
{
    // 01. Define a class Student, which contains data about a student – first, middle and last name, SSN,
    // permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for
    // the specialties, universities and faculties. Override the standard methods, inherited by  
    // System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

    // 02. Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's
    // fields into a new object of type Student.

    //03. Implement the  IComparable<Student> interface to compare students by names (as first criteria, 
    // in lexicographic order) and by social security number (as second criteria, in increasing order).

    class Program
    {
        static void Main(string[] args)
        {
            //test
            Student student1 = new Student(
                "Pesho", "Ivanov", "Peshev", "A11-11-1111", 1, Enums.Univercity.Cambridge,
                Enums.Specialty.Humanities, Enums.Faculty.History);
            Student student2 = new Student(
                "Gosho", "Ivanov", "Goshev", "111-22-1111", 1, Enums.Univercity.Oxford,
                Enums.Specialty.Social, Enums.Faculty.Law);

            //print students
            Console.WriteLine(student1.ToString());
            Console.WriteLine(student2.ToString());

            //compare students
            if (student1.CompareTo(student2)<0)
            {
                Console.WriteLine("student1 is before student2!" + "\n");
            }
            if (student1.CompareTo(student2) > 0)
            {
                Console.WriteLine("student1 is after student2!" + "\n");
            }
            if (student1.CompareTo(student2) == 0)
            {
                Console.WriteLine("student1 is after student2!" + "\n");
            }

            //clone Student1 and print it
            Student student3 = student1.Clone();
            Console.WriteLine(student3);

            //check if students are equal
            if (student1 == student2)
            {
                Console.WriteLine("student1 is equal to student2!");
            }
            else if (student1 != student2)
            {
                Console.WriteLine("student1 is NOT equal to student2!");
            }
        }
    }
}
