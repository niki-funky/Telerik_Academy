using System;
using System.Linq;
using EntityFramework.Model;

namespace EntityFramework.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // UnComment the needed task lines!!

            // 01. Using Entity Framework write a SQL query to select all 
            // employees from the Telerik Academy database and later print 
            //     their name, department and town. Try the both variants: 
            // with and without .Include(…). Compare the number of executed 
            // SQL statements and the performance.

            TelerikAcademyEntities db = new TelerikAcademyEntities();
            //var employees = db.Employees;

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("Employee: {0} {1} | {2} | {3}",
            //        employee.FirstName, 
            //        employee.LastName, 
            //        employee.Department.Name,
            //        employee.Address.Town.Name);
            //}

            // N+1 Query Problem solved
            foreach (var employee in db.Employees.Include("Department").
                Include("Address").Include("Address.Town"))
            {
                Console.WriteLine("Employee: {0} {1} | {2} | {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Department.Name,
                    employee.Address.Town.Name);
            }

            // 02. Using Entity Framework write a query that selects all 
            // employees from the Telerik Academy database, then invokes ToList(),
            // then selects their addresses, then invokes ToList(), then selects 
            // their towns, then invokes ToList() and finally checks whether the 
            // town is "Sofia". Rewrite the same in more optimized way and 
            // compare the performance.

            TelerikAcademyEntities db2 = new TelerikAcademyEntities();
            //var employees = db2.Employees.ToList().Select(x => x.Address).ToList().
            //    Select(e=>e.Town).ToList().Where(e=>e.Name == "Sofia");            

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} ",
            //        employee.Name);
            //}

            // Incorrect Use of ToList() solved
            //var employees = db2.Employees.Select(x => x.Address).
            //   Select(e => e.Town).Where(e => e.Name == "Sofia");

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} ",
            //        employee.Name);
            //}
        }


    }
}
