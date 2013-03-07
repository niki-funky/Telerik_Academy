using System;
using System.Linq;

namespace Bank
{
    class AccountDeposit : Account, IWithdraw
    {
        //constructor
        public AccountDeposit(Customer customer, decimal balance, double interest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interest;
        }

        //methods
        public decimal WithdrawMoney(decimal amount)
        {
            return this.Balance = this.Balance - amount;
        }

        public override decimal CalculateInterest(int numMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return (decimal)(numMonths * this.InterestRate);
        }
    }
}
