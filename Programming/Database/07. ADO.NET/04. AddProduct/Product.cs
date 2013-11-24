using System;

class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public short UnitsOnOrder { get; set; }
    public short ReorderLevel { get; set; }
    public bool Discontinued { get; set; }

    public override string ToString()
    {
        string text = String.Format(
            "Product(ProductID={0}, ProductName={1}, SupplierID={2}, CategoryID={3}, QuantityPerUnit={4}," +
             "UnitPrice={5}, UnitsInStock={6}, UnitsOnOrder={7}, ReorderLevel={8}, Discontinued={9})",
            this.ProductID, this.ProductName, this.SupplierID, this.CategoryID, this.QuantityPerUnit,
            this.UnitPrice, this.UnitsInStock, this.UnitsOnOrder, this.ReorderLevel, this.Discontinued);
        return text;
    }
}
