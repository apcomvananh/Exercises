namespace Exercise5
{
    public class LoanAccount : Account, IDepositable
    {
        ////Contructor
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        ////Override CalculateInterestAmount method
        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (Customer.CustomerType == CustomerType.Individuals)
            {
                if (numberOfMonths <= 3)
                {
                    return 0;
                }
                else if (numberOfMonths > 3)
                {
                    return base.CalculateInterestAmount(numberOfMonths - 3);
                }
            }

            if (Customer.CustomerType == CustomerType.Companies)
            {
                if (numberOfMonths <= 2)
                {
                    return 0;
                }
                else if (numberOfMonths > 2)
                {
                    return base.CalculateInterestAmount(numberOfMonths - 2);
                }
            }

            return base.CalculateInterestAmount(numberOfMonths);
        }
    }
}