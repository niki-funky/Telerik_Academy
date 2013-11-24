using System;
using System.Linq;

namespace SuperMarket.Formats
{
    public class SqlXmlFormat
    {
        public string VendorName { get; set; }
        public DateTime SoldDate { get; set; }
        public decimal Sum { get; set; }
    }
}
