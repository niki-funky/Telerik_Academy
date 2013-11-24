using System;
using System.Linq;
using System.Data.SQLite;

namespace _10.SQLite
{
    //10. Re-implement the previous task with SQLite embedded DB

    class Program
    {
        static void Main(string[] args)
        {
            //SQLiteConnection.CreateFile("../../Books.db");

            string myConnectionString = "Data Source=../../Books.db";


            SQLiteConnection connection = new SQLiteConnection(myConnectionString);

            // read data from column
            ReadDataFromColumn(connection);

            Console.WriteLine("--------------");

            // find by name
            FindByName("Book3", connection);
            // add new row
            InsertDataInExcelTable(connection);
        }


        private static void ReadDataFromColumn(SQLiteConnection connection)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Title FROM Books";
            SQLiteDataReader reader;
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

        private static void FindByName(string bookName, SQLiteConnection connection)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Title FROM Books " +
                "WHERE CHARINDEX (@searchedBook, Title)";

            command.Parameters.AddWithValue("@searchedBook", bookName);
            SQLiteDataReader reader;
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

        private static void InsertDataInExcelTable(SQLiteConnection conn)
        {
            AppenLine("Book10", "Traicho1", "10.10.2012", "973-954-2961-61-1", conn);
        }

        private static void AppenLine(string title, string author,
            string publishDate, string isbn, SQLiteConnection connection)
        {            
            var query = "INSERT INTO Books (Title, Author, PublishDate, ISBN) " +
                     "values(@title, @author, @publishDate, @isbn);";

            SQLiteCommand command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@title", title));
            command.Parameters.Add(new SQLiteParameter("@author", author));
            command.Parameters.Add(new SQLiteParameter("@publishDate", publishDate));
            command.Parameters.Add(new SQLiteParameter("@isbn", isbn));

            connection.Open();
            command.ExecuteNonQuery();

            Console.WriteLine("--------------");
            Console.WriteLine("New row added!");
            connection.Close();
        }
    }
}
