using System;
using System.Linq;

namespace Bank
{
    class Individual : Customer
    {
        //constructor
        public Individual(string name, string iban)
        {
            this.Name = name;
            if (iban.Length == 22)
            {
                this.IBAN = iban;
            }
            else
            {
                throw new ArgumentException("IBAN is not valid!");
            }
        }
    }
}
