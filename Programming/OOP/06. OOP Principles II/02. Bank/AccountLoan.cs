using System;
using System.Linq;

namespace Bank
{
    class AccountLoan : Account
    {
        //constructor
        public AccountLoan(Customer customer, decimal balance, double interest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interest;
        }

        //method
        public override decimal CalculateInterest(int numMonths)
        {
            if ((this.Customer is Individual) && numMonths > 3)
            {
                return (decimal)((numMonths - 3) * this.InterestRate);
            }
            else if ((this.Customer is Company) && (numMonths > 2))
            {
                return (decimal)((numMonths - 2) * this.InterestRate);
            }
            else
            {
                return 0;
            }
        }
    }
}
