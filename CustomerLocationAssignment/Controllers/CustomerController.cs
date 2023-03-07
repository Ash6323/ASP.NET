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
        public CustomerListClass GetAllCustomers()
        {
            //string responseBody = $"\"statusCode: 200,message\\\":\"+allCustomersData{}";
            return allCustomersData;
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
        [HttpGet("{id}")]
        public Customer Get(string id)
        {
            foreach (var singleCustomer in allCustomersData.customersList)
            {
                if (singleCustomer.customerId == id)
                    return singleCustomer;
            }
            Customer nullCustomer = new Customer();
            nullCustomer.customerId = "This Customer ID Does Not Exist";
            nullCustomer.locations = null;
            return nullCustomer;
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
        /// <response code="200">  If Customers Data is Submitted</response>
        /// <response code="400">  If Anything is Missing from Client Side's Request</response>
        /// <response code="404">  If Controller or Method not Found</response>
        [HttpPost]
        public string Post([FromBody] Customer value)
        {
            string responseBody;
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == value.customerId))
            {
                return "Customer with the same ID already Exists.";
            }
            allCustomersData.customersList.Add(value);
            responseBody = $"Status Code: 200\nMessage: Customer Added\nData: {value}";     //Changes Here
            return responseBody;
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
        public string Put(string id, [FromBody] Customer inputCustomer)
        {
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == id))
            {
                singleCustomer.customerId = inputCustomer.customerId;
                singleCustomer.locations = inputCustomer.locations;
                return "Customer Details Updated.";
            }
            return "Customer Not Found.";
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
        /// <response code="200">  If Customer is Found and the Data is Updated</response>
        /// <response code="400">  If Controller parameter is Missing</response>
        /// <response code="404">  If Controller or Data not Found</response>
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            foreach (var singleCustomer in allCustomersData.customersList.Where(w => w.customerId == id))
            {
                if (singleCustomer.locations[0] == null)
                {
                    allCustomersData.customersList.Remove(singleCustomer);
                    return "Customer Record Deleted.";
                }
                else
                    return "Customer Record Contains Locations. Remove Locations First.";
            }
            return "Customer Not Found.";
        }
    }
}
