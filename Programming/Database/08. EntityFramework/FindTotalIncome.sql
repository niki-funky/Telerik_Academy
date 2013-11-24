USE NORTHWND
GO

CREATE PROC usp_FindTotalIncome (@supplierName nvarchar(50), @startDate datetime,  @endDate DateTime)
AS
SELECT SUM(od.Quantity*od.UnitPrice) AS TotalIncome
FROM Suppliers s, Products p, [ORDER Details] od, Orders o
	WHERE s.SupplierID = p.SupplierID
	AND od.ProductID = p.ProductID
	AND od.OrderID = o.OrderID
	AND s.CompanyName = @supplierName 
		AND (o.OrderDate >= @startDate AND o.OrderDate <= @endDate)
GO

EXEC usp_FindTotalIncome  'Tokyo Traders', '1994-01-01', '2000-12-31'