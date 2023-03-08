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
            var response = new
            {
                statusCode = StatusCodes.Status200OK,
                message = "Data Retrieval Successful",
                data = allCustomersData
            };
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
        /// <response code="404">  If Controller or Data not Found</response>
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            foreach (var singleCustomer in allCustomersData.customersList)
            {
                if (singleCustomer.customerId == id)
                {
                    var response1 = new
                    {
                        statusCode = StatusCodes.Status200OK,
                        message = "Data Retrieval Successful",
                        data = allCustomersData
                    };
                    return Ok(response1);
                }                   
            }
            var response2 = new
            {
                statusCode = StatusCodes.Status404NotFound,
                message = "Unsuccessful Data Retrieval. Customer with this ID does not Exist",
                data = "N.A."
            };
            return NotFound(response2);
        }

        // POST api/Customer
        //[HttpPost]
        //[Route("AllCustomerData")]
        //public string Post([FromBody] CustomerListClass value)
        //{
        //    allCustomersData = value;
        //    return "All Customers Added.";
        //}


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
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == value.customerId))
            {
                var response = new
                {
                    statusCode = StatusCodes.Status208AlreadyReported,
                    message = "Customer with the same ID already Exists",
                    data = singleCustomer
                };
                return Accepted(response);
            }
            allCustomersData.customersList.Add(value);
            var response2 = new
            {
                statusCode = StatusCodes.Status201Created,
                message = "Customer Added Successfully",
                data = value
            };
            return Created($"~api/Customer/{value.customerId}", response2);
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
        public IActionResult Put(string id, [FromBody] Customer inputCustomer)
        {
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == id))
            {
                singleCustomer.customerId = inputCustomer.customerId;
                singleCustomer.locations = inputCustomer.locations;
                var response = new
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Data Updated Successfully",
                    data = singleCustomer
                };
                return Ok(response);
            }                                               //What is updated ID already exists??
            Customer nullCustomer = new Customer();
            nullCustomer.customerId = null;
            nullCustomer.locations = null;
            var response2 = new
            {
                statusCode = StatusCodes.Status404NotFound,
                message = "Unsuccessful Data Updation. Customer with this ID does not Exist",
                data = nullCustomer
            };
            return NotFound(response2);
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
        /// <response code="404">  If Controller or Data not Found</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == id))
            {
                if (singleCustomer.locations[0] == null)
                {
                    allCustomersData.customersList.Remove(singleCustomer);
                    var response = new
                    {
                        statusCode = StatusCodes.Status204NoContent,
                        message = "Data Deletion Successful",
                        data = "No Content"
                    };
                    return Ok(response);
                }
                else
                {
                    var response2 = new
                    {
                        statusCode = StatusCodes.Status400BadRequest,
                        message = "Unsuccessful Data Deletion- Customer Record Contains Locations. Remove Locations First",
                        data = singleCustomer
                    };
                    return BadRequest(response2);
                }
            }
            Customer nullCustomer = new Customer();
            nullCustomer.customerId = null;
            nullCustomer.locations = null;
            var response3 = new
            {

                statusCode = StatusCodes.Status404NotFound,
                message = "Unsuccessful Data Deletion. Customer with this ID does not Exist",
                data = nullCustomer
            };
            return NotFound(response3);
        }
    }
}
