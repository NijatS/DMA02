--1. Retrieve all customers

Select CustomerID,CompanyName from Customers

--2. List all orders with their corresponding customer name

Select o.OrderID,o.OrderDate,c.ContactName,c.City from Orders o
join Customers c
on o.CustomerID = c.CustomerID

--3. Find the total number of orders placed by each customer sql

select c.ContactName,COUNT( o.OrderID) as 'Sifaris Sayi' from Orders o
join Customers c
on o.CustomerID = c.CustomerID
group by c.ContactName
order by 'Sifaris Sayi' desc

--4. List products with their supplier's name

Select p.ProductName,s.ContactName from Products p 
inner join Suppliers s
on p.SupplierID = s.SupplierID



--5. Find the top 5 most expensive products

SELECT 
TOP(5) *
FROM
	Products 
Order by UnitPrice DESC

--6. List all employees who have not reported to anyone (NULL in ReportsTo)


select *from Employees
where ReportsTo is null


-- 7. Calculate the total sales for each product
select PRODUCTID,PRODUCTNAME, (UnitPrice* UnitsOnOrder)AS[TOTAL SALES] from Products

--8. Find the total number of products in each category

SELECT C.CategoryName, COUNT(ProductID) Say FROM Products P
JOIN Categories C On C.CategoryID = P.CategoryID
group by C.CategoryName

--9. List all employees along with their manager's name

select e.LastName, e.FirstName, m.LastName [menecerSurname] 
, m.FirstName [menecerName] from Employees e
join Employees m 
on e.ReportsTo= m.EmployeeID


--10. Retrieve all orders made in the year 1997

select  * from Orders
where  year (OrderDate)= 1997

--11. List all products that have not been ordered

select * from Products
where UnitsOnOrder = 0




--12. Find customers who have placed more than 10 orders

select c.ContactName,COUNT(o.OrderID) [Count of Orders] from Orders o
JOIN Customers c on o.CustomerID = c.CustomerID 
group by ContactName
having COUNT(o.OrderID) > 10
order by -COUNT(o.OrderID) 

--13. Find the average unit price of products in each category

select c.CategoryName,avg(p.UnitPrice) as [ortalama] from Products p
join Categories c on c.CategoryID=p.CategoryID
group by  c.CategoryName


--14. List all orders along with the total amount for each order

select OrderID,sum(od.UnitPrice*od.Quantity ) as endirimsiz, 
sum(od.UnitPrice*od.Quantity * (1-od.Discount))as endirimli 
from [Order Details] od
group by od.OrderID

--15. List the names of customers who have ordered products from the 'Beverages' category
select c.ContactName,cat.CategoryName,p.ProductName from Customers c
join Orders o on o.CustomerID = c.CustomerID
join [Order Details] od on od.OrderID = o.OrderID
join Products p on p.ProductID = od.ProductID
join Categories cat on cat.CategoryID = p.CategoryID
where cat.CategoryName = 'Beverages'

