using System;
using System.Linq;
using MySql.Data.MySqlClient;

namespace _09.ListAllBooks
{
    //09. Download and install MySQL database, MySQL Connector/Net 
    // (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool .
    // Create a MySQL database to store Books (title, author, publish date and ISBN).
    // Write methods for listing all books, finding a book by name and adding a book.

    class Program
    {
        static void Main(string[] args)
        {
            string myConnectionString = "SERVER=localhost;" +
                                        "DATABASE=Books;" +
                                        "UID=root;";

            MySqlConnection connection = new MySqlConnection(myConnectionString);

            // read data from column
            ReadDataFromColumn(connection);

            Console.WriteLine("--------------");

            // find by name
            FindByName("Book3", connection);
            // add new row
            InsertDataInExcelTable(connection);

        }

        private static void ReadDataFromColumn(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Title FROM Books";
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string row = "";
                for (int i = 0; i < reader.FieldCount; i++)
                    row += reader.GetValue(i).ToString();
                Console.WriteLine(row);
            }

            connection.Close();
        }

        private static void FindByName(string bookName, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Title FROM Books " +
                "WHERE LOCATE (@searchedBook, Title)";

            command.Parameters.AddWithValue("@searchedBook", bookName);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            if (!reader.HasRows) return;
            while (reader.Read())
            {
                string row = "";
                for (int i = 0; i < reader.FieldCount; i++)
                    row += reader.GetValue(i).ToString();
                Console.WriteLine(row);
            }

            connection.Close();
        }

        private static void InsertDataInExcelTable(MySqlConnection conn)
        {
            AppenLine("Book10", "Traicho1", "10.10.2012", "973-954-2961-61-1", conn);
        }

        private static void AppenLine(string title, string author,
            string publishDate, string isbn, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Books (Title, Author, PublishDate, ISBN) " +
                     "values(@title, @author, @publishDate, @isbn);";
            command.Parameters.Add("@title", title);
            command.Parameters.Add("@author", author);
            command.Parameters.Add("@publishDate", publishDate);
            command.Parameters.Add("@isbn", isbn);

            connection.Open();
            command.ExecuteNonQuery();

            Console.WriteLine("--------------");
            Console.WriteLine("New row added!");
            connection.Close();
        }
    }
}
