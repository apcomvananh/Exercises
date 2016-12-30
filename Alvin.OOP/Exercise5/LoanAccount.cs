namespace Exercise5
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (Customer.CustomerType == CustomerType.Individuals)
            {
                if (numberOfMonths <= 3)
                {
                    return 0;
                }
                return base.CalculateInterestAmount(numberOfMonths - 3);
            }

            if (Customer.CustomerType == CustomerType.Companies)
            {
                if (numberOfMonths <= 2)
                {
                    return 0;
                }
                return base.CalculateInterestAmount(numberOfMonths - 2);
            }

            return base.CalculateInterestAmount(numberOfMonths);
        }
    }
}