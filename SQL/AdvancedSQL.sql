
--Views
create view WAEmployees as
select * from Employees
Where Region = 'WA'


Select * from WAEmployees


--*View: ActiveCustomers
--List all customers who have placed at least one order.
create view ActiveCustomers as
select c.ContactName, count (orderID) as ordercount from Orders o 
join  Customers c on o.CustomerID = c.CustomerID 
group by c.ContactName
having count (OrderID)>10 

select * from ActiveCustomers




--*View: ProductsInStock
--List all products that are currently in stock.



go
create view ProductsInStock
as
select * from Products
where UnitsInStock > 0
go

select * from ProductsInStock
--*View: ProductsInStock
--Show a list of employees with their contact information.
create view EmployeeContactInfo as
select (LastName+' '+FirstName) as[fullname],PostalCode,HomePhone from Employees
select *from EmployeeContactInfo

--*View: OrdersByCountry
--List the number of orders placed by customers from each country.

select * from Orders

go
create View OrdersByCountry as 
(select C.Country, COUNT(O.OrderID) OrderCount from Customers C
Join Orders O on C.CustomerID = O.CustomerID
group by C.Country)
go


select * from OrdersByCountry


--*View: ProductSales
--Show the total sales for each product.

go

create view ProductSales as
select 
	P.ProductName,
	SUM(OD.UnitPrice * OD.Quantity * (1 - OD.Discount))  AS [TotalSales]
from
	[Order Details] OD
JOIN Products P ON P.ProductID = OD.ProductID
GROUP BY ProductName
GO

SELECT * FROM ProductSales



--Stored Procedures

--*Procedure: GetCustomerOrders
--This procedure retrieves all orders placed by a specific customer.



ALTER PROCEDURE GetCustomerOrders @CustomerId nchar(5)
AS
select * from Orders as [O]
where CustomerID = @CustomerId


exec GetCustomerOrders @CustomerId = 'VINET'


--*Procedure: GetProductsInStock
--This procedure retrieves all products that are currently in stock.


create procedure GetProductsInStock 
as
  select * from Products p 
  where p.UnitsInStock > 0

exec GetProductsInStock


--*Procedure: GetEmployeeContactInfo
--This procedure retrieves the contact information of all employees.

CREATE PROCEDURE GetEmployeeContactInfo
as
select LastName + ' ' + FirstName [FullName], PostalCode, HomePhone from Employees
exec
GetEmployeeContactInfo


--*Procedure: GetOrdersByCountry
--This procedure retrieves the number of orders placed by customers from a specific country.


select * from Orders

create procedure GetOrdersByCountry @CountryName nvarchar(15) as
select Count(OrderID) as TotalOrders from Orders O
join Customers C on O.CustomerID = C.CustomerID
Group by Country 
Having Country = @CountryName

exec GetOrdersByCountry @CountryName = 'Germany'


--*Procedure: GetProductSales
--This procedure retrieves the total sales for a specific product.



















