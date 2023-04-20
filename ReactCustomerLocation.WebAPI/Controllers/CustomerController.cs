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
        public IActionResult Post(Customer customer)
        {
            int result = _customerService.AddCustomer(customer);
            if (result.Equals(-1))
            {
                Response response = new
                    (StatusCodes.Status208AlreadyReported, ConstantMessages.customerAlreadyExists, ConstantMessages.customerAlreadyExists);
                return Ok(response);
            }
            else
            {
                Response response = new
                (StatusCodes.Status200OK, ConstantMessages.customerAddedSuccessfully, result);
                return Ok(response);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer updatedCustomer)
        {
            int result = _customerService.UpdateCustomer(id, updatedCustomer);
            if (result.Equals(-1))
            {
                Response response = new
                    (StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, ConstantMessages.customerDoesNotExist);
                return NotFound(response);
            }
            else if (result.Equals(0))
            {
                Response response = new
                    (StatusCodes.Status400BadRequest, ConstantMessages.locationIdDoesntExist, ConstantMessages.locationIdDoesntExist);
                return BadRequest(response);
            }
            else
            {
                Response response = new(StatusCodes.Status200OK, ConstantMessages.dataUpdatedSuccessfully, result);
                return Ok(response);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _customerService.DeleteCustomer(id);
            if (result.Equals(0))
            {
                Response response = new(StatusCodes.Status400BadRequest, ConstantMessages.dataContainsLocations, result);
                return BadRequest(response);
            }
            else if (result.Equals(-1))
            {
                Response response = new(StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
                return NotFound(response);
            }
            else
            {
                Response response = new(StatusCodes.Status200OK, ConstantMessages.dataDeletedSuccessfully, null);
                return Ok(response);
            }
        }
    }
}
