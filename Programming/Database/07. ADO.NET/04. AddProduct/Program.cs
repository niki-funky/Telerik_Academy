using System;
using System.Data.SqlClient;
using _04.AddProduct.Properties;

class AddProduct
{
    //04. Write a method that adds a new product in the products table in 
    // the Northwind database. Use a parameterized SQL command.

    private SqlConnection dbCon;

    private void ConnectToDB()
    {
        dbCon = new SqlConnection(Settings.Default.DBConnectionString);
        dbCon.Open();
    }

    private void DisconnectFromDB()
    {
        if (dbCon != null)
        {
            dbCon.Close();
        }
    }

    private int InsertProject(string productName, int supplierID,
        int categoryID, string quantityPerUnit, decimal unitPrice, 
        short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
    {
        SqlCommand cmdInsertProduct = new SqlCommand(
            "INSERT INTO Products(ProductName, SupplierID, " +
            "CategoryID, QuantityPerUnit, UnitPrice," +
            "UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
            "VALUES (@productName, @supplierID, " +
            "@categoryID, @quantityPerUnit, @unitPrice," +
            "@unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbCon);
        cmdInsertProduct.Parameters.AddWithValue("@productName", productName);
        cmdInsertProduct.Parameters.AddWithValue("@supplierID", supplierID);
        cmdInsertProduct.Parameters.AddWithValue("@categoryID", categoryID);
        cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
        cmdInsertProduct.Parameters.AddWithValue("@unitPrice", unitPrice);
        cmdInsertProduct.Parameters.AddWithValue("@unitsInStock", unitsInStock);
        cmdInsertProduct.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
        cmdInsertProduct.Parameters.AddWithValue("@reorderLevel", reorderLevel);
        cmdInsertProduct.Parameters.AddWithValue("@discontinued", discontinued);

        cmdInsertProduct.ExecuteNonQuery();

        SqlCommand cmdSelectIdentity =
            new SqlCommand("SELECT @@Identity", dbCon);
        int insertedRecordId =
            (int)(decimal)cmdSelectIdentity.ExecuteScalar();
        return insertedRecordId;
    }

    static void Main()
    {
        AddProduct example = new AddProduct();
        try
        {
            example.ConnectToDB();

            // Insert new project in the "Projects" table
            int newProjectId = example.InsertProject("Yabulki",
                1, 1, "njqkolko", 12.10m, 10, 1, 10, false);
            Console.WriteLine("Inserted new project. " +
                "ProjectID = {0}", newProjectId);
        }
        finally
        {
            example.DisconnectFromDB();
        }
    }
}
