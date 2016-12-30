namespace Exercise2
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary { get; private set; }

        public int WorkHoursPerDay { get; private set; }

        ////Methods
        public double MoneyPerHour()
        {
            return WeekSalary / (WorkHoursPerDay * 5);
        }
    }
}