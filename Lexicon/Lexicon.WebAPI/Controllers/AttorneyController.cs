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
                    Response(StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(response);
            }
            return NoContent();
        }

        // GET api/<AttorneyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            AttorneyDto result = _attorneyService.GetAttorney(id);
            if (result != null)
            {
                Response attorneyExistsResponse = new
                    (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(attorneyExistsResponse);
            }
            Response attorneyNotExistsresponse = new
                (StatusCodes.Status404NotFound, ConstantMessages.AttorneyDoesNotExist, null);
            return NotFound(attorneyNotExistsresponse);
        }

        // POST api/<AttorneyController>
        [HttpPost]
        public IActionResult Post(AttorneyDto attorney)
        {
            int result = _attorneyService.AddAttorney(attorney);
            if (result.Equals(-1))
            {
                Response response = new
                    (StatusCodes.Status400BadRequest, ConstantMessages.AttorneyAlreadyExists, ConstantMessages.AttorneyAlreadyExists);
                return BadRequest(response);
            }
            else
            {
                Response response = new
                (StatusCodes.Status200OK, ConstantMessages.DataAddedSuccessfully, result);
                return Ok(response);
            }
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
