using System;

namespace Exercise5
{
    public abstract class Account : IDepositable
    {
        ////Fields
        private Customer _customer;

        private decimal _balance;
        private decimal _interestRate;

        ////Contructor
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            _customer = customer;
            _balance = balance;
            _interestRate = interestRate;
        }

        ////Properties
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public decimal InterestRate
        {
            get { return _interestRate; }
            set { _interestRate = value; }
        }

        ////Methods
        public virtual decimal CalculateInterestAmount(int numberOfMonths)
        {
            return numberOfMonths * _interestRate;
        }

        public void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new Exception("money must be greater than 0");
            }
            else
            {
                Balance += money;
            }
        }
    }
}