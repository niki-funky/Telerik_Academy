using System;
using System.Linq;

namespace Bank
{
    class AccountMortgage : Account
    {
        //constructor
        public AccountMortgage(Customer customer, decimal balance, double interest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interest;
        }

        //method
        public override decimal CalculateInterest(int numMonths)
        {
            if ((this.Customer is Individual) && numMonths <= 6)
            {
                return 0;
            }
            else if ((this.Customer is Company) && numMonths <= 12)
            {
                return (decimal)((numMonths) * this.InterestRate) / 2;
            }
            else
            {
                return (decimal)((numMonths) * this.InterestRate);
            }
        }
    }
}
