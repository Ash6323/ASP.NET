using Lexicon.Data.DTO;
using Lexicon.Data.Models;
using Lexicon.Data;
using Lexicon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lexicon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurisdictionController : ControllerBase
    {
        private readonly IJurisdiction _jurisdictionService;
        public JurisdictionController(IJurisdiction lexiconRepository)
        {
            _jurisdictionService = lexiconRepository;
        }
        // GET: api/<JurisdictionController>
        [HttpGet]
        public IActionResult Get()
        {
            List<JurisdictionDto> result = _jurisdictionService.GetJurisdictions();
            if (result != null)
            {
                Response response = new 
                    Response(StatusCodes.Status200OK, ConstantMessages.dataRetrievedSuccessfully, result);
                return Ok(response);
            }
            return NoContent();
        }

        // GET api/<JurisdictionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JurisdictionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JurisdictionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JurisdictionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
