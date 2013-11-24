using System;
using System.Data.SqlClient;

class RetrieveNamesOfCategories
{
    //02. Write a program that retrieves the name and description of all 
    // categories in the Northwind DB.

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection("Server=localhost; " +
            "Database=NORTHWND; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmdCount = new SqlCommand(
                "SELECT CategoryName, Description FROM Categories", dbCon);
            SqlDataReader reader = cmdCount.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", categoryName, description);
                }
            }
        }
    }
}
