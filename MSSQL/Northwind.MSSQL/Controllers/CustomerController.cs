using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.MSSQL.Data;
using Northwind.MSSQL.Models;

namespace Northwind.MSSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;

        public CustomerController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        // Loading related data
        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _northwindContext
                .Customers
                .Take(5)
                .Include(c => c.Orders).ToList();
        }

        // Loading data from stored procedure
        // Loading data from view
    }
}