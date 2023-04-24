using Microsoft.AspNetCore.Mvc;
using Lexicon.Data.DTO;
using Lexicon.Data.Models;
using Lexicon.Data;
using Lexicon.Services.Interfaces;

namespace Lexicon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatterController : ControllerBase
    {
        private readonly IMatter _matterService;
        
        public MatterController(IMatter matterRepository)
        {
            _matterService = matterRepository;
        }
        // GET: api/<MatterController>
        [HttpGet]
        public IActionResult Get()
        {
            List<MatterDto> result = _matterService.GetMatters();
            if (result != null)
            {
                Response response = new
                    Response(StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(response);
            }
            return NoContent();
        }

        // GET api/<MatterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            MatterDto result = _matterService.GetMatter(id);
            if (result != null)
            {
                Response matterExistsResponse = new
                (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(matterExistsResponse);
            }
            Response matterNotExistsResponse = new
            (StatusCodes.Status404NotFound, ConstantMessages.MatterDoesNotExist, null);
            return NotFound(matterNotExistsResponse);
        }
        [HttpGet("GetByClients")]
        public IActionResult GetByClients()
        {
            IEnumerable<IGrouping<int, MatterDto>> result = _matterService.GetMattersByClients();
            if (result == null)
            {
                Response noMattersByClientsResponse = new
                (StatusCodes.Status404NotFound, ConstantMessages.MattersByClientsNotFound, null);
                return NotFound(noMattersByClientsResponse);
            }
            else
            {
                Response mattersByClientsExistsResponse = new
                (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(mattersByClientsExistsResponse);
            }
        }
        [HttpGet("GetByClient/{id}")]
        public IActionResult GetByClient(int id)
        {
            List<MatterDto> result = _matterService.GetMattersByClient(id);
            if (result == null)
            {
                Response noMattersByClientResponse = new
                (StatusCodes.Status404NotFound, ConstantMessages.MattersByClientNotFound, null);
                return NotFound(noMattersByClientResponse);
            }
            else
            {
                Response mattersByClientExistsResponse = new
                (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(mattersByClientExistsResponse);
            }
        }

        // POST api/<MatterController>
        [HttpPost]
        public IActionResult Post(MatterDto matter)
        {
            int result = _matterService.AddMatter(matter);
            if (result.Equals(0))
            {
                Response response = new
                    (StatusCodes.Status400BadRequest, ConstantMessages.MatterAlreadyExists, 
                                                      ConstantMessages.MatterAlreadyExists);
                return BadRequest(response);
            }
            else if(result.Equals(-1))
            {
                Response response = new
                    (StatusCodes.Status400BadRequest, ConstantMessages.NoMatchingJurisdiction,
                                                      ConstantMessages.NoMatchingJurisdiction);
                return BadRequest(response);
            }
            else
            {
                Response response = new
                (StatusCodes.Status200OK, ConstantMessages.DataAddedSuccessfully, result);
                return Ok(response);
            }
        }

        // PUT api/<MatterController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MatterDto updatedMatter)
        {
            int result = _matterService.UpdateMatter(id, updatedMatter);
            if (result.Equals(0))
            {
                Response response = new
                    (StatusCodes.Status404NotFound, ConstantMessages.MatterDoesNotExist,
                                                    ConstantMessages.MatterDoesNotExist);
                return NotFound(response);
            }
            else
            {
                Response response = new(StatusCodes.Status200OK, ConstantMessages.DataUpdatedSuccessfully, result);
                return Ok(response);
            }
        }

        // DELETE api/<MatterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _matterService.DeleteMatter(id);
            if (result.Equals(0))
            {
                Response response =
                    new(StatusCodes.Status400BadRequest, ConstantMessages.MatterDoesNotExist, result);
                return BadRequest(response);
            }
            else
            {
                Response response = new(StatusCodes.Status200OK, ConstantMessages.DataDeletedSuccessfully, null);
                return Ok(response);
            }
        }
    }
}
