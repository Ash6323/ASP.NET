using Microsoft.AspNetCore.Mvc;
using CustomerLocationRP.Services.Interfaces;
using CustomerLocationRP.Services.Models;
using CustomerLocationRP.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerLocationRP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerRepository)
        {
            _customerService = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Customer> result = _customerService.GetAllCustomer();
            Response<List<Customer>> response = new
                            (StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, result);
            return Ok(response);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            IEnumerable<Customer> result = _customerService.GetCustomer(id);
            if (result != null)
            {
                Response<IEnumerable<Customer>> customerExistsResponse = new
                    (StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, result);
                return Ok(customerExistsResponse);
            }
            Response<IEnumerable<Customer>> customerNotExistsresponse = new 
                (StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
            return NotFound(customerNotExistsresponse);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(Customer value)
        {
            Customer result = _customerService.AddCustomer(value);
            if (result == value)
            { 
                var response = new Response<Customer>
                    (StatusCodes.Status201Created, ConstantMessages.customerAddedSuccessfully, result);
                return Ok(response);
            }
            else
            {
                Response<Customer> response = new
                    (StatusCodes.Status208AlreadyReported, ConstantMessages.customerAlreadyExists, value);
                return Accepted(response);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, string streetAddress, [FromBody] Address inputAddress)
        {
            Customer result = _customerService.UpdateCustomer(id, streetAddress, inputAddress);
            if(result != null)
            {
                Response<Customer> response = new(StatusCodes.Status200OK, ConstantMessages.dataUpdatedSuccessfully, result);
                return Ok(response);
            }
            else
            {
                Response<Customer> response = new(StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
                return NotFound(response);
            }          
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Customer result = _customerService.DeleteCustomer(id);
            if (result != null)
            {
                Response<Customer> response = new(StatusCodes.Status400BadRequest, ConstantMessages.dataContainsLocations, result);
                return BadRequest(response);
            }
            else
            {
                Response<Customer> response = new(StatusCodes.Status204NoContent, ConstantMessages.dataDeletedSuccessfully, null);
                return Ok(response);
            }
        }
    }
}
