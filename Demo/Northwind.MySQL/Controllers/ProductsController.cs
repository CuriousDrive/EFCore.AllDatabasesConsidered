using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;

namespace Northwind.MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly NorthwindContextProcedures _contextProcedures;

        public ProductsController(NorthwindContext context, 
            NorthwindContextProcedures contextProcedures)
        {
            _context = context;
            _contextProcedures = contextProcedures;

        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        //loading related data
        [HttpGet("GetSupplierFromProductName")]
        public async Task<Product?> GetSupplierFromProductName(string? productName)
        {
            return await _context.Products
                .Include(p => p.Supplier)
                .Where(p => p.ProductName == productName)
                .FirstOrDefaultAsync();
        }

        //calling a view
        [HttpGet("GetAlphabeticalListOfProducts")]
        public async Task<IEnumerable<AlphabeticalListOfProduct>> GetAlphabeticalListOfProducts()
        {
            return await _context.AlphabeticalListOfProducts.ToListAsync();
        }

        //calling stored procedure
        [HttpGet("GetCustOrderHistory")]
        public async Task<IEnumerable<CustOrderHistory>> GetCustOrderHistory(string customerId)
        {
            return await _contextProcedures.CustOrderHistories
                .FromSqlRaw("call cust_order_history({0})", customerId)
                .ToListAsync();
        }
    }
}
