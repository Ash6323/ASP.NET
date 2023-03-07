using Microsoft.AspNetCore.Mvc;
using StudentDataNamespace;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController2 : ControllerBase
    {
        // GET: api/<ValuesController2>
        [HttpGet]
        public List<StudentDataClass> Get()
        {
            StudentDataListClass sdList = new StudentDataListClass();
            return sdList.studentDataList;
        }

        // GET api/<ValuesController2>/5
        [HttpGet("{id}")]
        public StudentDataClass Get(int id)
        {
            StudentDataClass forReturn = null;
            StudentDataListClass sdList = new StudentDataListClass();
            foreach (StudentDataClass sd in sdList.studentDataList)
            {
                if (sd.roll == id)
                {
                    forReturn = sd;
                    break;
                }
            }
            return forReturn;
        }

        // POST api/<ValuesController2>
        [HttpPost]
        public void Post([FromBody] StudentDataClass value)
        {
        }

        // PUT api/<ValuesController2>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentDataClass value)
        {
        }

        // DELETE api/<ValuesController2>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
