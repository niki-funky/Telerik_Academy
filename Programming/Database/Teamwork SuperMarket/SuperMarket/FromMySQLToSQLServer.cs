using System;
using System.Linq;
using SuperMarket.MySQL.Data;
using SuperMarket.SQLServer.Data;

namespace SuperMarket
{
    public class FromMySQLToSQLServer
    {
        private SupermarketContext sqlServerContext;
        private SuperMarketEntitiesModel mySqlContext;

        public FromMySQLToSQLServer(SupermarketContext sqlServerContext,
                                    SuperMarketEntitiesModel mySqlContext)
        {
            this.sqlServerContext = sqlServerContext;
            this.mySqlContext = mySqlContext;
        }

        public void ExportMeasures()
        {
            var query = this.mySqlContext.Measures;
            foreach (var measure in query)
            {
                SQLServer.Models.Measure newMeasure = new SQLServer.Models.Measure()
                {
                    MeasureName = measure.MeasureName,
                    Id = measure.Id
                };
                this.sqlServerContext.Measures.Add(newMeasure);
            }
            this.sqlServerContext.SaveChanges();
        }

        public void ExportVendors()
        {
            var query = this.mySqlContext.Vendors;
            foreach (var vendor in query)
            {
                SQLServer.Models.Vendor newVendor = new SQLServer.Models.Vendor()
                {
                    VendorName = vendor.VendorName,
                    Id = vendor.Id
                };
                this.sqlServerContext.Vendors.Add(newVendor);
            }
            this.sqlServerContext.SaveChanges();
        }

        public void ExportProducts()
        {
            var query = this.mySqlContext.Products;
            foreach (var product in query)
            {
                SQLServer.Models.Product newProduct = new SQLServer.Models.Product()
                {
                     BasePrice = product.BasePrice,
                     MeasureId = product.MeasureId,
                     VendorId = product.VendorId,
                     ProductName = product.ProductName
                };
                this.sqlServerContext.Products.Add(newProduct);
            }
            this.sqlServerContext.SaveChanges();
        }

        public void Export()
        {
            ExportMeasures();
            ExportVendors();
            ExportProducts();
        }
    }
}
