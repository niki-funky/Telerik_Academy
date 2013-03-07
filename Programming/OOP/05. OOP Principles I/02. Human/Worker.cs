using System;
using System.Linq;

namespace Human
{
    class Worker : Human
    {
        public double WeekSalary { get; set; }
        public double WorkHoursPerDay { get; set; }

        //constructors
        public Worker(string firstName, string lastName, double salary, double workHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHours;
        }

        //methods
        public double MoneyPerHour()
        {
            return Math.Round( this.WeekSalary / (5 * WorkHoursPerDay),2);
        }
    }
}
