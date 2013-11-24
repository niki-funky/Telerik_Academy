using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using EntityFramework.Model;
using EntityFramework.Model2;

namespace EntityFramework.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment necessary lines for each task!!!

            // Task.01 -> See generated .edmx file at: "EF.Client/Northwind.edmx"
            // Using the Visual Studio Entity Framework designer create a DbContext
            // for the Northwind database


            // 02. Create a DAO class with static methods which 
            // provide functionality for inserting, modifying and 
            // deleting customers. Write a testing class.

            //ClientManagement.Modify("ANTON", "Pesho");
            //ClientManagement.Insert("PESHO", "Gosho");
            //ClientManagement.Insert("SASHO", "Gosho2");
            //ClientManagement.Delete("PESHO");

            // 03. Write a method that finds all customers who
            // have orders made in 1997 and shipped to Canada.

            //FindAllCustomers(1997, "Canada");

            // 04. Implement previous by using native SQL query
            // and executing it through the DbContext.

            //var customers = FindAllCustomersSQLquery(1997, "Canada");
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine("Customer : {0}", customer);
            //}

            // 05. Write a method that finds all the sales by specified
            // region and period (start / end dates).

            //FindAllSales("SP", new DateTime(1997, 07, 30), new DateTime(1997, 11, 20));

            // 06. Create a database called NorthwindTwin with 
            // the same structure as Northwind using the features from DbContext.
            // Find for the API for schema generation in MSDN or in Google.

            //CreateDB();
            //GetSchema();

            //07. Try to open two different data contexts and perform concurrent
            //changes on the same records. What will happen at SaveChanges()? 
            //    How to deal with it?

            //ConcurrentChages();

            // 08. By inheriting the Employee entity class create a class which
            // allows employees to access their corresponding territories as property
            // of type EntitySet<T>.

            InheritClass();

            // 09. Create a method that places a new order in the Northwind database.
            // The order should contain several order items. Use transaction to ensure 
            // the data consistency.

            //Order order = new Order();
            //order.CustomerID = "ALFKI";
            //order.EmployeeID = 5;
            //order.ShipVia = 3;
            //order.ShipName = "gosho";

            //CreateNewOrder(order);

            // 10. Create a stored procedures in the Northwind database for finding
            // the total incomes for given supplier name and period (start date, end date).
            // Implement a C# method that calls the stored procedure and returns the retuned 
            // record set.

            //FindTotalIncome("Tokyo Traders", new DateTime(1994, 1, 1), new DateTime(2000, 12, 31));

            // Task.11
            // Create a database holding users and groups. Create a transactional EF based 
            // method that creates an user and puts it in a group "Admins". In case the group 
            // "Admins" do not exist, create the group in the same transaction. If some of the 
            // operations fail (e.g. the username already exist), cancel the entire transaction.

            //CreateUser("User 2", 1);
            //CreateUser("User 3", 1);
        }

        // Task 3
        private static void FindAllCustomers
            (int year, string country)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            var orders = db.Orders.Where(o => o.OrderDate.Value.Year == year &&
                o.ShipCountry == country);

            foreach (var order in orders)
            {
                Console.WriteLine("Customer : {0}", order.Customer.ContactName);
            }
        }

        // Task 4
        private static IEnumerable<string> FindAllCustomersSQLquery
            (int year, string country)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            string nativeSqlQuery =
                "SELECT c.ContactName as Customer " +
                "FROM dbo.Orders o, Customers c " +
                "WHERE YEAR(o.OrderDate) = '" + year + "'" +
                "AND o.ShipCountry = '" + country + "'" +
                "Group By c.ContactName";

            var customers =
                db.Database.SqlQuery<string>(nativeSqlQuery);
            return customers;
        }

        // Task 5
        private static void FindAllSales
            (string region, DateTime start, DateTime end)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            var orders = db.Orders.Where(o =>
                 o.ShippedDate.Value >= start &&
                 o.ShippedDate.Value <= end &&
                 o.ShipRegion == region);

            foreach (var order in orders)
            {
                Console.WriteLine("OrderID : {0}", order.OrderID);
            }
        }

        // Task 6
        private static void CreateDB()
        {
            using (var db = new NorthwindTwin())
            {
                //db.Database.Delete();
                db.Database.CreateIfNotExists();
            }
        }

        private static void GetSchema()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            ObjectContext objectContext = ((IObjectContextAdapter)db).ObjectContext;
            var dbSchema = objectContext.CreateDatabaseScript();

            NorthwindTwin dbTwin = new NorthwindTwin();
            ObjectContext objectContext2 = ((IObjectContextAdapter)dbTwin).ObjectContext;
            objectContext2.ExecuteStoreCommand(dbSchema);
        }

        // Task 7
        private static void ConcurrentChages()
        {
            using (TransactionScope scope = new TransactionScope())
            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new 
            //    TransactionOptions { IsolationLevel= IsolationLevel.Snapshot }))
            {
                NORTHWNDEntities db = new NORTHWNDEntities();

                Product product = db.Products.First(p => p.ProductID == 1);
                product.ProductName = "Test 001";
                db.SaveChanges();

                NORTHWNDEntities db2 = new NORTHWNDEntities();
                Product product2 = db2.Products.First(p => p.ProductID == 1);
                product2.ProductName = "Test 002";
                try
                {
                    int result = db2.SaveChanges();

                    Console.WriteLine(result.ToString() +
                        " products changed");

                }
                catch (OptimisticConcurrencyException)
                {
                    db2.Entry(product2).Reload();
                    //db2.Refresh(RefreshMode.ClientWins, db2.Products);
                    db2.SaveChanges();
                }

                scope.Complete();
            }
        }

        // Task 8
        // EmployeeEx.cs class is created in EntityFramework.Model project
        private static void InheritClass()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            Employee temp = db.Employees.First(e => e.EmployeeID == 1);
            var territoriesList = temp.TerritoriesSet;
            foreach (var territory in territoriesList)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }
        }

        // Task 9
        private static void CreateNewOrder(Order order)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                NORTHWNDEntities db = new NORTHWNDEntities();

                var customer = db.Customers.First(c => c.CustomerID == order.CustomerID);
                if (customer != null)
                {
                    order.ShipAddress = customer.Address;
                    order.ShipCity = customer.City;
                    order.ShipPostalCode = customer.PostalCode;
                    order.ShipCountry = customer.Country;
                }

                db.Orders.Add(order);
                db.SaveChanges();

                scope.Complete();
            }
        }

        // Task.10
        private static void FindTotalIncome(string name, DateTime start, DateTime end)
        {
            // Added in Northwind DB
            /*
                USE NORTHWND
                GO

                CREATE PROC usp_FindTotalIncome (@supplierName nvarchar(50), @startDate datetime,  @endDate DateTime)
                AS

                SELECT SUM(od.Quantity*od.UnitPrice) AS TotalIncome
                FROM Suppliers s, Products p, [ORDER Details] od, Orders o
                WHERE s.SupplierID = p.SupplierID
                AND od.ProductID = p.ProductID
                AND od.OrderID = o.OrderID
                AND s.CompanyName = @supplierName 
                AND (o.OrderDate >= @startDate AND o.OrderDate <= @endDate)
                GO 
                EXEC usp_FindTotalIncome  'Tokyo Traders', '1994-01-01', '2000-12-31'
             */
            NORTHWNDEntities db = new NORTHWNDEntities();

            SqlParameter param1 = new SqlParameter("@companyName", name);
            SqlParameter param2 = new SqlParameter("@start", start);
            SqlParameter param3 = new SqlParameter("@end", end);
            var result = db.Database.ExecuteSqlCommand(
                "usp_FindTotalIncome @companyName, @start, @end", param1, param2, param3);

            Console.WriteLine("Total Incomes from '" + name + "' are: {0}", result);
        }

        // Task.11
        private static void CreateUser(string userName, int groupId)
        {
            UserAccountsEntities db = new UserAccountsEntities();
            using (TransactionScope scope = new TransactionScope())
            {
                User newUser = new User();
                newUser.UserName = userName;
                newUser.GroupID = groupId;

                db.Users.Add(newUser);
                try
                {
                    db.SaveChanges();
                    Console.WriteLine("User '" + userName + "' added");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("User '" + userName + "' duplicate!");
                    Console.WriteLine(ex.Message);
                }
                scope.Complete();
            }
        }
    }

    public class NorthwindTwin : DbContext
    {
    }

}

//namespace EntityFramework.Model
//{
//        // task 8
//    public partial class Employee
//    {
//        //public T TerritorySet { get; set; }
//        public EntitySet<Territory> TerritoriesSet 
//        {
//            get
//            {
//                var territoriesSet = new EntitySet<Territory>();
//                territoriesSet.AddRange(this.Territories);
//                return territoriesSet;
//            }
//        }
//    }
//}
