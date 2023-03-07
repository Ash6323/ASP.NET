using CustomerLocationAssignment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerLocationAssignment.Controllers
{

    [Route("api/[controller]")]
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
        /// <response code="404">  If Controller or Data not Found</response>
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var response = new
            {
                statusCode = 200,
                message = "Data Retrieval Successful",
                data = allCustomersData
            };
            return new ObjectResult(response);
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
        /// <response code="400">  If Controller parameter is Missing</response>
        /// <response code="404">  If Controller or Data not Found</response>
        /// 
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            foreach (var singleCustomer in allCustomersData.customersList)
            {
                if (singleCustomer.customerId == id)
                {
                    var response1 = new
                    {
                        statusCode = 200,
                        message = "Data Retrieval Successful",
                        data = allCustomersData
                    };
                    return new ObjectResult(response1);
                }                   
            }
            Customer nullCustomer = new Customer();
            nullCustomer.customerId = null;
            nullCustomer.locations = null;
            var response2 = new
            {
                statusCode = 404,
                message = "Unsuccessful Data Retrieval. Customer with this ID does not Exist",
                data = nullCustomer
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
        /// <response code="202">  If Request is Accepted, but Customer with the same ID already Exists</response>
        /// <response code="400">  If Anything is Missing from Client Side's Request</response>
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer value)
        {
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == value.customerId))
            {
                var response = new
                {
                    statusCode = 202,
                    message = "Customer with the same ID already Exists",
                    data = singleCustomer
                };
                return Accepted(response);
            }
            allCustomersData.customersList.Add(value);
            var response2 = new
            {
                statusCode = 201,
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
        /// <response code="400">  If Controller parameter is Missing</response>
        /// <response code="404">  If Controller or Data not Found</response>
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(string id, [FromBody] Customer inputCustomer)
        {
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == id))
            {
                singleCustomer.customerId = inputCustomer.customerId;
                singleCustomer.locations = inputCustomer.locations;
                var response = new
                {
                    statusCode = 200,
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
                statusCode = 404,
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
        /// <response code="200">  If Customer is Deleted Successfully</response>
        /// <response code="202">  If Request is Accepted, but Customer has Existing Locations</response>
        /// <response code="400">  If Controller parameter is Missing</response>
        /// <response code="404">  If Controller or Data not Found</response>
        /// 
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
                        statusCode = 200,
                        message = "Data Deletion Successful",
                        data = singleCustomer
                    };
                    return Ok(response);
                }
                else
                {
                    var response2 = new
                    {
                        statusCode = 202,
                        message = "Unsuccessful Data Deletion- Customer Record Contains Locations. Remove Locations First",
                        data = singleCustomer
                    };
                    return Accepted(response2);
                }
            }
            Customer nullCustomer = new Customer();
            nullCustomer.customerId = null;
            nullCustomer.locations = null;
            var response3 = new
            {

                statusCode = 404,
                message = "Unsuccessful Data Deletion. Customer with this ID does not Exist",
                data = nullCustomer
            };
            return NotFound(response3);
        }
    }
}
