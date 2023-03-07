using Microsoft.AspNetCore.Mvc;
using StudentData.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public List<StudentDataClass> Get()
        {
            StudentDataListClass sdList = new StudentDataListClass();
            return sdList.studentDataList;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public StudentDataClass Get(int id)
        {
            StudentDataClass forReturn = null;
            StudentDataListClass sdList = new StudentDataListClass();
            foreach ( StudentDataClass sd in sdList.studentDataList)
            {
                if(sd.roll == id)
                {
                    forReturn = sd;
                    break;
                }
            }
            return forReturn;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
