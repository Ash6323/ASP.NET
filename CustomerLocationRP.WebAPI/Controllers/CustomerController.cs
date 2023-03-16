using Microsoft.AspNetCore.Mvc;
using CustomerLocationRP.Services.Interfaces;
using CustomerLocationRP.Services.Models;
using CustomerLocationRP.Services;

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

        /// <summary>
        /// Returns All Customer Data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Customer/
        ///
        /// </remarks>
        /// <response code="200">  If Customers are Found and Response is Given</response>
        /// <response code="400">  If Anything is Missing from Client Side's Request</response>
        [HttpGet]
        public IActionResult Get()
        {
            List<Customer> result = _customerService.GetAllCustomer();
            if (result != null)
            {
                Response response = new (StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, result);
                return Ok(response);
            }

            return NoContent();
        }

        // GET api/<CustomerController>/5

        /// <summary>
        /// Returns a single Customer Data by taking the Customer's ID
        /// </summary>
        /// <param name="id">ID of Customer whose Data is to be Retrieved</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Customer/3
        ///
        /// </remarks>
        /// <response code="200">  If Customer is Found and Response is Given</response>
        /// <response code="400">  If Anything is Missing from Client Side's Request</response>
        /// <response code="404">  If Customer not Found</response>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            IEnumerable<Customer> result = _customerService.GetCustomer(id);
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

        /// <summary>
        /// Takes a Single Customer Data and Sends through API
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/Customer/
        ///
        /// </remarks>
        /// <response code="201">  If Customer Data is Submitted Successfully</response>
        /// <response code="208">  If Customer with the the same ID already Exists</response>
        /// <response code="400">  If Anything is Missing from Client Side's Request</response>
        [HttpPost]
        public IActionResult Post(Customer value)
        {
            Customer result = _customerService.AddCustomer(value);
            if (result == value)
            {
                var response = new Response
                    (StatusCodes.Status201Created, ConstantMessages.customerAddedSuccessfully, result);
                return Ok(response);
            }
            else
            {
                Response response = new
                    (StatusCodes.Status208AlreadyReported, ConstantMessages.customerAlreadyExists, value);
                return Ok(response);
            }
        }

        // PUT api/<CustomerController>/5

        /// <summary>
        /// Updates a Single Customer's Data by taking as Input the ID of Existing Customer
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/Customer/3
        ///
        /// </remarks>
        /// <response code="200">  If Customer is Found and the Data is Updated</response>
        /// <response code="400">  Bad Request</response>
        /// <response code="404">  If Controller or Data not Found</response>
        [HttpPut("{id}")]
        public IActionResult Put(string id, string streetAddress, [FromBody] Address inputAddress)
        {
            Customer result = _customerService.UpdateCustomer(id, streetAddress, inputAddress);
            if (result != null)
            {
                Response response = new(StatusCodes.Status200OK, ConstantMessages.dataUpdatedSuccessfully, result);
                return Ok(response);
            }
            else
            {
                Response response = new(StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
                return NotFound(response);
            }
        }

        // DELETE api/<CustomerController>/5

        /// <summary>
        /// Deletes a Single Customer's Data (if Locations are Empty) by taking as Input the ID of Customer
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /api/Customer/3
        ///
        /// </remarks>
        /// <response code="204">  Customer is Deleted Successfully. No reponse Data is included as it is deleted</response>
        /// <response code="400">  If Customer has Existing Locations in Data</response>
        /// <response code="404">  If Customer not Found</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Customer result = _customerService.DeleteCustomer(id);
            if (result != null)
            {
                Response response = new(StatusCodes.Status400BadRequest, ConstantMessages.dataContainsLocations, result);
                return BadRequest(response);
            }
            else
            {
                Response response = new(StatusCodes.Status204NoContent, ConstantMessages.dataDeletedSuccessfully, null);
                return Ok(response);
            }
        }
    }
}
