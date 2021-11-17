select c.CustomerID, o.* from Customers c
inner join Orders o on o.CustomerID = c.CustomerID
where c.CustomerID = 'ALFKI'

-- Order Id - 10248