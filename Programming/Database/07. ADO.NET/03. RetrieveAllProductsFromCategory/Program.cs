using System;
using System.Data.SqlClient;

class RetrieveAllProductsFromCategory
{
    //03. Write a program that retrieves from the Northwind database 
    // all product categories and the names of the products in each category. 
    // Can you do this with a single SQL query (with table join)?

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection("Server=localhost; " +
            "Database=NORTHWND; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmdCount = new SqlCommand(
                "SELECT CategoryName, ProductName FROM Categories c, Products p " +
                "WHERE p.CategoryID = c.CategoryID", dbCon);
            SqlDataReader reader = cmdCount.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} - {1}", categoryName, productName);
                }
            }
        }
    }
}
