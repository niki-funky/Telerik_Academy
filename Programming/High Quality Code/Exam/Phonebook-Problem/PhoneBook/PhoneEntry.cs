namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        private string name;
        private string nameLowerCase;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.nameLowerCase = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> ListOfNumbers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            sb.Append(this.Name);
            bool isEmpty = true;
            foreach (var phone in this.ListOfNumbers)
            {
                if (isEmpty)
                {
                    sb.Append(": ");
                    isEmpty = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');

            return sb.ToString();
        }

        public int CompareTo(PhoneEntry other)
        {
            return this.nameLowerCase.CompareTo(other.nameLowerCase);
        }
    }
}
