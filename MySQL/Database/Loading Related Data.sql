select p.ProductName,s.* from products p
inner join suppliers s on s.SupplierID = p.SupplierID
where ProductName = 'Chai'