using System;

namespace Exercise5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var accounts = GetAccounts();
            ////Print accounts
            PrintAccounts(accounts);

            ////Deposite and with draw
            Console.WriteLine("-----Deposite Account-----");
            var depositeAccount = new DepositeAccount(new Customer("Deposite", CustomerType.Individuals), 1000M, 8M);
            depositeAccount.Deposit(200M);
            depositeAccount.WithDraw(100M);
            Console.WriteLine("Deposite balance: " + depositeAccount.Balance);

            Console.WriteLine("-----Loan Account-----");
            var loanAccount = new LoanAccount(new Customer("Loan", CustomerType.Companies), 1800M, 5M);
            loanAccount.Deposit(200M);
            Console.WriteLine("Loan balance: " + loanAccount.Balance);

            Console.WriteLine("-----Mortgage Account-----");
            var mortgateAccount = new MortgateAccount(new Customer("Mortgate", CustomerType.Companies), 2800M, 80M);
            mortgateAccount.Deposit(300M);
            Console.WriteLine("Mortgage balance: " + mortgateAccount.Balance);
            Console.ReadLine();
        }

        private static Account[] GetAccounts()
        {
            var accounts = new Account[]
            {
                new DepositeAccount(new Customer("Phuong", CustomerType.Individuals), 1200M, 2M),
                new LoanAccount(new Customer("Alvin", CustomerType.Companies), 120M, 3M),
                new MortgateAccount(new Customer("Jonny", CustomerType.Individuals), 300M, 3M),
            };
            return accounts;
        }

        private static void PrintAccounts(Account[] accounts)
        {
            Console.WriteLine("Name \t Type \t \t Balance \t Interest rate \t Interest amount");
            foreach (var account in accounts)
            {
                Console.WriteLine(
                    "{0} \t {1} \t {2} \t \t {3} \t \t {4}",
                    account.Customer.Name,
                    account.Customer.CustomerType.ToString(),
                    account.Balance,
                    account.InterestRate,
                    account.CalculateInterestAmount(8));
            }
        }
    }
}