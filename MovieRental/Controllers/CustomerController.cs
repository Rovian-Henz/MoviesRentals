using Microsoft.AspNetCore.Mvc;
using MovieRental.Customer;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerFeatures _features;

        public CustomerController(ICustomerFeatures features)
        {
            _features = features;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? customerName)
        {
            return Ok(_features.GetCustomers(customerName));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer.Customer customer)
        {
	        return Ok(_features.SaveAsync(customer));
        }               

    }
}
