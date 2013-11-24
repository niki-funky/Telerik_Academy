using System;
using System.Linq;
using System.Data.SqlClient;

namespace _08.FindAllProductsByGivenString
{
    // 08. Write a program that reads a string from the console 
    // and finds all products that contain this string. Ensure you 
    // handle correctly characters like ', %, ", \ and _.

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some text to search for it in the Products: ");
            var searchedProduct = Console.ReadLine();

            SqlConnection dbCon = new SqlConnection("Server=localhost; " +
                "Database=NORTHWND; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT ProductName FROM Products " +
                    "WHERE CHARINDEX (@searchedProduct, ProductName)>0", dbCon);

                cmd.Parameters.AddWithValue("@searchedProduct", searchedProduct);

                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine(productName);
                    }
                }
            }
        }
    }
}
