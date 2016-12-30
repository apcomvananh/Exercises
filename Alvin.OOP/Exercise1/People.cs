namespace Exercise1
{
    public abstract class People
    {
        ////Fields
        private string _name;

        ////Contructor
        protected People(string name)
        {
            _name = name;
        }

        ////Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}