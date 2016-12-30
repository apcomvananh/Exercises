namespace Exercise5
{
    public enum CustomerType
    {
        Individuals,
        Companies
    }

    public class Customer
    {
        ////Fields
        private string _name;

        private CustomerType _customerType;

        ////Contructor
        public Customer(string name, CustomerType customerType)
        {
            _name = name;
            _customerType = customerType;
        }

        ////Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public CustomerType CustomerType
        {
            get { return _customerType; }
            set { _customerType = value; }
        }
    }
}