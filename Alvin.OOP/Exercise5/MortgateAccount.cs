namespace Exercise5
{
    public class MortgateAccount : Account
    {
        public MortgateAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (Customer.CustomerType == CustomerType.Companies)
            {
                if (numberOfMonths >= 0 && numberOfMonths <= 12)
                {
                    return InterestRate / 2 * numberOfMonths;
                }
            }

            if (Customer.CustomerType == CustomerType.Individuals && numberOfMonths <= 0)
            {
                return 0;
            }

            return base.CalculateInterestAmount(numberOfMonths);
        }
    }
}