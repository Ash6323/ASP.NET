using System.Security.Cryptography.Xml;
using CustomerLocationAssignment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerLocationAssignment.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static CustomerListClass allCustomersData = new CustomerListClass();

        // GET: api/Customer

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
        /// <response code="404">  If Data not Found</response>
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Customer>> response = new Response<List<Customer>>(StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, allCustomersData.customersList);
            return Ok(response);
        }

        // GET api/Customer/{CustomerID}

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
            if (allCustomersData.customersList.Any(w => w.customerId == id))
            {
                var customerExistsResponse = new Response<IEnumerable<Customer>>(StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, allCustomersData.customersList.Where(w => w.customerId == id));
                return Ok(customerExistsResponse);
            }
            var customerNotExistsresponse = new Response<IEnumerable<Customer>>(StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
            return NotFound(customerNotExistsresponse);
        }

        // POST api/Customer

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
        public IActionResult Post([FromBody] Customer value)
        {
            IEnumerable<Customer> result = allCustomersData.customersList.Where(w => w.customerId == value.customerId);
            if (result.Any())
            {
                var response = new Response<IEnumerable<Customer>>(StatusCodes.Status208AlreadyReported, ConstantMessages.customerAlreadyExists, result);
                return Accepted(response);
            }
            else
            {
                allCustomersData.customersList.Add(value);
                Response<Customer> response = new Response<Customer>(StatusCodes.Status201Created, ConstantMessages.customerAddedSuccessfully, value);
                return Ok(response);
            }
        }

        // PUT api/Customer/{id}

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
            Customer singleCustomer = allCustomersData.customersList.FirstOrDefault(w => w.customerId == id);
            if (singleCustomer != null)
            {
                Address customerAddress = singleCustomer.locations.FirstOrDefault(w => w.street == streetAddress);
                customerAddress.street = inputAddress.street;
                customerAddress.town = inputAddress.town;
                customerAddress.city = inputAddress.city;
                Response<Customer> response = new Response<Customer>(StatusCodes.Status200OK, ConstantMessages.dataUpdatedSuccessfully, singleCustomer);
                return Ok(response);
            }
            else
            {
                Response<Customer> response = new Response<Customer>(StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
                return NotFound(response);
            }
        }

        // DELETE api/Customer/{id}

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
            Customer singleCustomer = allCustomersData.customersList.FirstOrDefault(w => w.customerId == id);
            if (singleCustomer.locations[0].street != String.Empty && singleCustomer.locations[0].town != String.Empty && singleCustomer.locations[0].city != String.Empty)
            {
                Response<Customer> response = new Response<Customer>(StatusCodes.Status400BadRequest, ConstantMessages.dataContainsLocations, singleCustomer);
                return BadRequest(response);
            }
            else if (singleCustomer.locations[0].street == String.Empty && singleCustomer.locations[0].town == String.Empty && singleCustomer.locations[0].city == String.Empty)
            {
                allCustomersData.customersList.Remove(singleCustomer);
                Response<Customer> response = new Response<Customer>(StatusCodes.Status204NoContent, ConstantMessages.dataDeletedSuccessfully, null);
                return Ok(response);
            }
            else
            {
                Response<Customer> response = new Response<Customer>(StatusCodes.Status404NotFound, ConstantMessages.customerDoesNotExist, null);
                return NotFound(response);
            }
        }
    }
}