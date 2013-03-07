using System;
using System.Linq;

namespace Bank
{
    public abstract class Customer
    {
        public string Name { get; set; }
        public string IBAN { get; set; }
    }
}
