namespace Exercise2
{
    public class Worker : Human
    {
        ////Fields
        private double _weekSalary;

        private int _workHoursPerDay;

        ////Contructor
        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            _weekSalary = weekSalary;
            _workHoursPerDay = workHoursPerDay;
        }

        ////Properties
        public double WeekSalary
        {
            get { return _weekSalary; }
            set { _weekSalary = value; }
        }

        public int WorkHoursPerDay
        {
            get { return _workHoursPerDay; }
            set { _workHoursPerDay = value; }
        }

        ////Methods
        public double MoneyPerHour()
        {
            return _weekSalary / (_workHoursPerDay * 5);
        }
    }
}