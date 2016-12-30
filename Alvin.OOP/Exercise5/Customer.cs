namespace Exercise5
{
    public enum CustomerType
    {
        Individuals,
        Companies
    }

    public class Customer
    {
        public Customer(string name, CustomerType customerType)
        {
            Name = name;
            CustomerType = customerType;
        }

        public string Name { get; private set; }

        public CustomerType CustomerType { get; private set; }
    }
}