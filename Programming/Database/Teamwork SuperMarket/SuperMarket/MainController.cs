namespace SuperMarket
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using SuperMarket.MySQL.Data;
    using SuperMarket.SQLServer.Data;
    using System.Data.OleDb;
    using System.Collections.Generic;
    using SuperMarket.PDF.Client;
    using SuperMarket.Formats;
    using SuperMarket.SQLite.DataProvider;

    public class MainController
    {
        private static MainController instance;
        
        private SupermarketContext sQLServerContext;
        private SuperMarketEntitiesModel mySqlContext;
        private OleDbConnection excelConnection;
        private SuperMarketEntities sqliteContext;


        private MainController()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SupermarketContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());
            this.sQLServerContext = new SupermarketContext();
            this.mySqlContext = new SuperMarketEntitiesModel();
            this.excelConnection = new OleDbConnection();
            this.sqliteContext = new SuperMarketEntities();
        }

        public static MainController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainController();
                }
                return instance;
            }            
        }

        public void ExportFromMySqlToSqlServer()
        {
            FromMySQLToSQLServer mySqlToSqlServer = 
                new FromMySQLToSQLServer(sQLServerContext, mySqlContext);
            mySqlToSqlServer.Export();
        }

        public void ExportFromExcelToSqlServer(string zipFileName, 
            string extractionFolder)
        {
            ExcelToSqlServerExporter exporter = 
                new ExcelToSqlServerExporter();
            exporter.Export(zipFileName, extractionFolder, excelConnection, sQLServerContext);
        }

        public void FreeResourses()
        {
        }

        public void CreatePdfReport(DateTime startDate, DateTime endDate, 
            string pdfFullFileName, string cssFullFileName)
        {
            IList<SqlPdfFormat> data = 
                SqlServerToPdf.GenerateSalesReport(sQLServerContext, startDate, endDate);
            PdfGenerator.GeneratePdf(data, pdfFullFileName, cssFullFileName);
        }

        public void GenerateSqlToXmlVendorsReport(DateTime startDate, 
            DateTime endDate, string fileName)
        {
           var data= SqlServerToXml.GenerateXmlSalesReport(sQLServerContext, startDate, endDate);
           SqlServerToXml.WriteXmlSalesReport(data, fileName);
        }

        public void ExportFromMongoDBToSQLite()
        {
            MongoDbToSqliteExporter exporter = new MongoDbToSqliteExporter();
            exporter.Export(this.sqliteContext);
        }

        public void ExportDataToMongoDb(string location)
        {
            SqlServerDataToMongoDbExporter exporter = new SqlServerDataToMongoDbExporter();
            exporter.Export(this.sQLServerContext, location);
        }

        public void ExportDataFromXmlToDatabase(string xmlFullFileName)
        {
            XmlToDatabasesExporter exporter = new XmlToDatabasesExporter();
            exporter.Export(xmlFullFileName, this.sQLServerContext);
        }

        public void ExportDataToExcelFile(string fileName)
        {
            SqliteDataToExcelFileExporter exporter = new SqliteDataToExcelFileExporter();
            exporter.Export(this.sqliteContext, this.sQLServerContext, fileName);
        }
    }
}
