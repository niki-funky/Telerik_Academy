using System;
using System.Linq;

namespace Bank
{
    public abstract class Account
    {
        //properties
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public double InterestRate { get; set; }

        //methods
        public virtual decimal CalculateInterest(int numMonths)
        {
            return (decimal)(numMonths * this.InterestRate);
        }

        public decimal DepositMoney(decimal amount)
        {
            return this.Balance = this.Balance + amount;
        }      
    }
}
