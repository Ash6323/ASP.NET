using Microsoft.AspNetCore.Mvc;
using Lexicon.Data.DTO;
using Lexicon.Data.Models;
using Lexicon.Data;
using Lexicon.Services.Interfaces;

namespace Lexicon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttorneyController : ControllerBase
    {
        private readonly IAttorney _attorneyService;
        public AttorneyController(IAttorney attorneyRepository)
        {
            _attorneyService = attorneyRepository;
        }
        // GET: api/<AttorneyController>
        [HttpGet]
        public IActionResult Get()
        {
            List<AttorneyDto> result = _attorneyService.GetAttorneys();
            if (result != null)
            {
                Response response = new
                    Response(StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, result);
                return Ok(response);
            }
            return NoContent();
        }

        // GET api/<AttorneyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttorneyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AttorneyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttorneyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
