using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    // 02. A bank holds different types of accounts for its customers: 
    // deposit accounts, loan accounts and mortgage accounts. Customers 
    // could be individuals or companies.
    // All accounts have customer, balance and interest rate (monthly based).
    // Deposit accounts are allowed to deposit and with draw money. Loan and
    // mortgage accounts can only deposit money.
    // All accounts can calculate their interest amount for a given period
    // (in months). In the common case its is calculated as follows: 
    // number_of_months * interest_rate.

    // Loan accounts have no interest for the first 3 months if are held by
    // individuals and for the first 2 months if are held by a company.
    // Deposit accounts have no interest if their balance is positive and 
    // less than 1000.
    // Mortgage accounts have ½ interest for the first 12 months for companies
    // and no interest for the first 6 months for individuals.
    // Your task is to write a program to model the bank system by classes 
    // and interfaces. You should identify the classes, interfaces, base 
    // classes and abstract actions and implement the calculation of the 
    // interest functionality through overridden methods.

    class Program
    {
        static void Main(string[] args)
        {
            //test
            List<Account> bankAccounts = new List<Account> 
            {
                new AccountDeposit(new Individual("Pesho","BG80TEXI95451020345678"),1000,0.5),
                new AccountLoan(new Individual("Gosho","BG80BNBG96611020345678"),5000,0.3),
                new AccountMortgage(new Individual("Misho","BG80BNBG50001033506907"),500,0.1)
            };
            //print
            foreach (var item in bankAccounts)
            {
                Console.WriteLine(item.Customer.Name
                                + " : "
                                + item.Customer.IBAN
                                + " : "
                                + item.Balance
                                + " : "
                                + item.CalculateInterest(10));
            }
            //withdraw some money and print again
            (bankAccounts[0] as AccountDeposit).WithdrawMoney(333);
            Console.WriteLine("\n"
                            + bankAccounts[0].Customer.Name
                            + " : "
                            + bankAccounts[0].Customer.IBAN
                            + " : "
                            + bankAccounts[0].Balance
                            + " : "
                            + bankAccounts[0].CalculateInterest(10));
        }
    }
}
