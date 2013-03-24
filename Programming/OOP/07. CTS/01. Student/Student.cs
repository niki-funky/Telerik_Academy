using System;
using System.Linq;
using System.Text;

namespace Student
{
    class Student : ICloneable, IComparable<Student>
    {
        //field
        readonly ValidSsn vs = new ValidSsn();
        readonly ValidEmail ve = new ValidEmail();
        private string ssn;
        private string email;

        //properties
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public string Ssn
        {
            get
            {
                if (vs.IsValidSsn(this.ssn))
                {
                    return this.ssn;
                }
                else
                {
                    return "SSN is not valid!";
                }
            }
            set
            {
                if (vs.IsValidSsn(value))
                {
                    this.ssn = value;
                }
                //else
                //{
                //    Console.WriteLine("SSN is not valid!");
                //}
            }
        }
        public string PermanentAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Email
        {
            get
            {
                if (ve.IsValidEmail(this.email) || this.email == null)
                {
                    return this.email;
                }
                else
                {
                    return "Email is not valid!";
                }
            }
            set
            {
                if (ve.IsValidEmail(value) || value == null)
                {
                    this.email = value;
                }
                //else
                //{
                //    Console.WriteLine("Email is not valid!");
                //}
            }
        }
        public byte Course { get; set; }
        public Enums.Specialty Specialty { get; set; }
        public Enums.Univercity Univercity { get; set; }
        public Enums.Faculty Faculty { get; set; }

        //constructors
        public Student(string first, string middle, string last,
                        string ssn, string address, string phone, string email,
                        byte course, Enums.Univercity univercity,
                        Enums.Specialty specialty, Enums.Faculty faculty)
        {
            this.First = first;
            this.Middle = middle;
            this.Last = last;
            this.Ssn = ssn;
            this.PermanentAddress = address;
            this.MobilePhone = phone;
            this.Email = email;
            this.Course = course;
            this.Univercity = univercity;
            this.Specialty = specialty;
            this.Faculty = faculty;
        }

        public Student(string first, string middle, string last, string ssn,
                        byte course, Enums.Univercity univercity,
                        Enums.Specialty specialty, Enums.Faculty faculty)
            : this(first, middle, last, ssn, null, null, null, course, univercity, specialty, faculty)
        {
        }

        //overriding methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
                return false;

            //ref type fields
            if (!Object.Equals(this.First, student.First)
                || !Object.Equals(this.Middle, student.Middle)
                || !Object.Equals(this.Last, student.Last)
                || !Object.Equals(this.Ssn, student.Ssn))
                return false;

            //value type field
            //if (!this.Ssn.Equals(obj))
            //    return false;
            return true;
        }

        public override int GetHashCode()
        {
            return Last.GetHashCode() ^ Ssn.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(First + " ");
            sb.Append(Middle + " ");
            sb.AppendLine(Last);
            sb.AppendLine("---------------");
            sb.AppendLine(Ssn);
            sb.AppendLine(Univercity.ToString());
            sb.AppendLine(Specialty.ToString());
            sb.AppendLine(Faculty.ToString());
            return sb.ToString();
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !(Student.Equals(first, second));
        }

        //implementing ICloneable interface
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student cloning = new Student(
                this.First,
                this.Middle,
                this.Last,
                this.Ssn,
                this.Course,
                this.Univercity,
                this.Specialty,
                this.Faculty);

            return cloning;
        }

        //implementing IComparable<Student> interface
        public int CompareTo(Student student)
        {
            if (this.First != student.First)
            {
                return (String.Compare(this.First, student.First)); //string static method compare
            }
            if (this.Middle != student.Middle)
            {
                return (String.Compare(this.Middle, student.Middle)); //string static method compare
            }
            if (this.Last != student.Last)
            {
                return (String.Compare(this.Last, student.Last)); //string static method compare
            }
            if (this.Ssn != student.Ssn)
            {
                return (String.Compare(this.Ssn, student.Ssn)); //string static method compare
            }
            //if (this.Ssn != student.Ssn)
            //{
            //    return (this.Ssn - student.Ssn);
            //}
            return 0;
        }
    }
}
