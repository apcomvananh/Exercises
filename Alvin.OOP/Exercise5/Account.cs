using System;

namespace Exercise5
{
    public abstract class Account : IDepositable
    {
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            Customer = customer;
            Balance = balance;
            InterestRate = interestRate;
        }

        public Customer Customer { get; private set; }

        public decimal Balance { get; protected set; }

        public decimal InterestRate { get; private set; }

        public virtual decimal CalculateInterestAmount(int numberOfMonths)
        {
            return numberOfMonths * InterestRate;
        }

        public void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new Exception("money must be greater than 0");
            }

            Balance += money;
        }
    }
}