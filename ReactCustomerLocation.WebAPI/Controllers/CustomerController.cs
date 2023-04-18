using Microsoft.AspNetCore.Mvc;
using ReactCustomerLocation.Data;
using ReactCustomerLocation.Services.Interfaces;
using ReactCustomerLocation.Data.Models;

namespace ReactCustomerLocation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;
        public CustomerController(ICustomer customerRepository)
        {
            _customerService = customerRepository;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Customer> result = _customerService.GetAllCustomer();
            if (result != null)
            {
                Response response = new(StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, result);
                return Ok(response);
            }
            return NoContent();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer result = _customerService.GetCustomer(id);
            if (result != null)
            {
                Response customerExistsResponse = new
                    (StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, result);
                return Ok(customerExistsResponse);
            }
            Response customerNotExistsresponse = new
                (StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
            return NotFound(customerNotExistsresponse);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
