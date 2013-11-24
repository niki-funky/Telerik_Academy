using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace _06.CreateExcelFile
{
    class Program
    {
        private const string SOURCE_FILE_NAME =
            @"..\..\contacts.xlsx";

        private static void ReadData(OleDbConnection connection,
            OleDbCommand selectCommand, OleDbDataAdapter adapter)
        {
            DataTable tableInfo = connection.GetSchema("Tables");
            List<string> sheetsName = new List<string>();
            foreach (DataRow row in tableInfo.Rows)
            {
                sheetsName.Add(row["TABLE_NAME"].ToString());
            }

            for (int t = 0; t < sheetsName.Count; t++)
            {
                selectCommand.CommandText = "SELECT * FROM [" + sheetsName[t] + "]";
                selectCommand.Connection = connection;
                adapter.SelectCommand = selectCommand;
                DataTable Sheet = new DataTable();
                Sheet.TableName = sheetsName[t].Replace("$", "").Replace("'", "");
                adapter.Fill(Sheet);

                Console.WriteLine("NAME -> SCORE");
                Console.WriteLine("--------------------------");

                for (int i = 0; i < Sheet.Rows.Count; i++)
                {
                    for (int j = 0; j < Sheet.Columns.Count; j++)
                    {
                        Console.Write(Sheet.Rows[i][j]);
                        if (j < Sheet.Columns.Count - 1)
                        {
                            Console.Write(" -> ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void InsertDataInExcelTable(string tabName, 
            OleDbConnection conn)
        {
            AppenLine(tabName, "Ivan Ivanov", 100, conn);
            AppenLine(tabName, "Petar Petrov", 200, conn);
            AppenLine(tabName, "Georgi Georgiev", 300, conn);
            AppenLine(tabName, "Mitko Mitev", 400, conn);
        }

        private static void AppenLine(string tabName, string val1, int val2, 
            OleDbConnection conn)
        {
            var cmd = new OleDbCommand("INSERT INTO [" + tabName + "$] (name, score) " +
                                        "values('" + val1 + "', " + val2 + ")", conn);
            cmd.ExecuteNonQuery();
        }

        static void Main(string[] args)
        {
            try
            {
                string connectionString = string.Empty;

                if (Path.GetExtension(SOURCE_FILE_NAME) == ".xlsx")
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        SOURCE_FILE_NAME + ";Extended Properties=Excel 12.0;";
                }
                else
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        SOURCE_FILE_NAME + ";Extended Properties='Excel 8.0;HDR=YES'";
                }

                OleDbCommand selectCommand = new OleDbCommand();
                OleDbConnection connection = new OleDbConnection();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                connection.ConnectionString = connectionString;

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // insert new rows
                InsertDataInExcelTable("Sheet1", connection);
                // read all rows
                ReadData(connection, selectCommand, adapter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}



//using System;
//using System.Data.OleDb;

//public class CreateExcelWorksheet
//{
//    static void Main()
//    {
//        string TempFileLocation = @"..\..\";
//        string tempfilename = @"TEST_FILE2";
//        string TabName = "TabName";
//        string xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" +
//            TempFileLocation + tempfilename + ".xls;Extended Properties='Excel 8.0;HDR=YES'";
//        var conn = new OleDbConnection(xConnStr);
//        string ColumnName = "[columename] varchar(64)";
//        conn.Open();
////        var cmd = new OleDbCommand("CREATE TABLE [" + TabName + "] (" + ColumnName + ")", conn);
//        cmd.ExecuteNonQuery();
//        conn.Close();
//    }
//}
