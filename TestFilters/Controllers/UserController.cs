using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestFilters.Filters;
using TestFilters.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestFilters.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User User = new();

        // POST api/<UserController>

        /// <summary>
        /// Gets User Details
        /// </summary>
        /// <param name="id">ID of User</param>
        /// <param name="name">Name of the User</param>
        /// <response code="500">Internal Server Error (Inludes Exception Cases)</response>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [TestActionFilter]
        [ExceptionFilter]
        [ResultFilter]
        public void Post(int id, [FromBody] string name)
        {
            User.Id = id;
            User.Name = name;
            if (name.Equals("string"))
            {
                throw new Exception("You Cannot Enter the Default Value for Name");
            }
            //var result = new { statusCode = StatusCode, message = "ResultFilter"};
        }

        // GET: api/<UserController>
        [HttpGet]
        //[ActionFilter]
        public User Get()
        {
            return User;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return user.Name;
        //}
       
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            User.Name = value;
        }

        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
