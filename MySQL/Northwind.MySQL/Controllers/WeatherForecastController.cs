using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;

namespace Northwind.MySQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ExtendedNorthwindContext _extendedNorthwindContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ExtendedNorthwindContext extendedNorthwindContext)
        {
            _logger = logger;
            _extendedNorthwindContext = extendedNorthwindContext;

        }

        [HttpGet(Name = "GetCustOrderHistory")]
        public async Task<IEnumerable<CustOrderHistory>> GetCustOrderHistory()
        {
            return await _extendedNorthwindContext.CustOrderHistories.FromSqlRaw("call cust_order_history('ALFKI')").ToListAsync();
        }
    }
}