using System;
using System.Linq;

namespace SuperMarket.Formats
{
    public class SqliteExcelFormat
    {
        public string Vendor { get; set; }
        public int ProductId { get; set; }
        public decimal? Incomes { get; set; }
        public decimal? Expenses { get; set; }
        public decimal? TaxPercentage { get; set; }
    }
}
