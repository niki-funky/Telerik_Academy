using System;
using System.Linq;
using MongoDB.Bson;

namespace SuperMarket.Formats
{
    public class MongoDbProductFormat
    {
        public ObjectId Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string VendorName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalIncomes { get; set; }
    }
}
