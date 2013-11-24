using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using _05.RetrieveAllImages.Properties;

class AddProduct
{
    //05. Write a program that retrieves the images for all categories 
    // in the Northwind database and stores them as JPG files in the file system.

    //private SqlConnection dbCon;
    private const string SOURCE_IMAGE_FILE_NAME =
    @"..\..\ninja.jpg";
    private const string DEST_IMAGE_FILE_NAME =
        @"..\..\ninja_exported.jpg";

    private static byte[] ReadBinaryFile(string fileName)
    {
        FileStream stream = File.OpenRead(fileName);
        using (stream)
        {
            int pos = 0;
            int length = (int)stream.Length;
            byte[] buf = new byte[length];
            while (true)
            {
                int bytesRead = stream.Read(buf, pos, length - pos);
                if (bytesRead == 0)
                {
                    break;
                }
                pos += bytesRead;
            }
            return buf;
        }
    }

    private static void WriteBinaryFile(string fileName,
        byte[] fileContents)
    {
        FileStream stream = File.OpenWrite(fileName);
        using (stream)
        {
            stream.Write(fileContents, 0, fileContents.Length);
        }
    }

    private static void InsertImageToDB(byte[] image)
    {
        SqlConnection dbConn = new SqlConnection(
            Settings.Default.DBConnectionString);
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE Categories SET Picture = @image WHERE CategoryID > 0", dbConn);

            SqlParameter paramImage =
                new SqlParameter("@image", SqlDbType.Image);
            paramImage.Value = image;
            cmd.Parameters.Add(paramImage);

            cmd.ExecuteNonQuery();
        }
    }

    static void Main()
    {
        InsertImageToDB(ReadBinaryFile(SOURCE_IMAGE_FILE_NAME));

        SqlConnection dbConn = new SqlConnection(
            Settings.Default.DBConnectionString);
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT Picture FROM Categories ", dbConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int counter = 0;
            while (reader.Read())
            {
                counter++;
                byte[] imageFromDB = (byte[])reader["Picture"];

                Console.WriteLine("Extracted first image from the DB.");

                WriteBinaryFile(@"..\..\ninja_exported" + counter + ".jpg", imageFromDB);
                Console.WriteLine("Image saved to file {0}.",
                    DEST_IMAGE_FILE_NAME);
            }
        }
    }
}
