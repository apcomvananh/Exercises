using System;

namespace Exercise5
{
    public class DepositeAccount : Account, IWithDrawable
    {
        ////Contructor
        public DepositeAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        ////Override CalculateInterestAmount method
        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (Balance >= 0 && Balance <= 1000)
            {
                return 0;
            }

            return base.CalculateInterestAmount(numberOfMonths);
        }

        public void WithDraw(decimal money)
        {
            if (money <= 0)
            {
                throw new Exception("money must be greater than 0");
            }
            else if (Balance <= money)
            {
                throw new Exception("With draw money can't greater than balance.");
            }
            else
            {
                Balance -= money;
            }
        }
    }
}