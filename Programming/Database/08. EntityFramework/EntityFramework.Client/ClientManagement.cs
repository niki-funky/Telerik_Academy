using System;
using System.Linq;
using EntityFramework.Model;

namespace EntityFramework.Client
{
    class ClientManagement
    {
        public static void Insert(string id, string name)
        {
            Customer newCustomer = new Customer()
            {
                CompanyName = name,
                CustomerID = id
            };

            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                bool isInDB = IsInDataBase(db, id);

                if (!isInDB)
                {
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    Console.WriteLine("Added Successful.");
                }
                else
                {
                    throw new ArgumentException("Such customer already exists");
                }
            }
        }

        public static void Modify(string id, string newContactName)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                customer.ContactName = newContactName;
                db.SaveChanges();
            }
        }

        public static void Delete(string id)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        private static bool IsInDataBase(NORTHWNDEntities db, string id)
        {
            bool alreadyInDB = db.Customers.Where(a => a.CustomerID == id).Any();
            return alreadyInDB;
        }
    }
}
