using Microsoft.AspNetCore.Mvc;
using Lexicon.Data.DTO;
using Lexicon.Data.Models;
using Lexicon.Data;
using Lexicon.Services.Interfaces;

namespace Lexicon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _clientService;
        public ClientController(IClient clientRepository)
        {
            _clientService = clientRepository;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public IActionResult Get()
        {
            List<ClientDto> result = _clientService.GetClients();
            if (result != null)
            {
                Response response = new
                    Response(StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(response);
            }
            return NoContent();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ClientDto result = _clientService.GetClient(id);
            if (result != null)
            {
                Response clientExistsResponse = new
                    (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(clientExistsResponse);
            }
            Response clientNotExistsResponse = new
                (StatusCodes.Status404NotFound, ConstantMessages.ClientDoesNotExist, null);
            return NotFound(clientNotExistsResponse);
        }

        // POST api/<ClientController>
        [HttpPost]
        public IActionResult Post(ClientDto client)
        {
            int result = _clientService.AddClient(client);

            Response response = new
            (StatusCodes.Status200OK, ConstantMessages.DataAddedSuccessfully, result);
            return Ok(response);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientDto updatedClient)
        {
            int result = _clientService.UpdateClient(id, updatedClient);
            if (result.Equals(0))
            {
                Response response = new
                    (StatusCodes.Status404NotFound, ConstantMessages.ClientDoesNotExist,
                                                    ConstantMessages.ClientDoesNotExist);
                return NotFound(response);
            }
            else
            {
                Response response = new(StatusCodes.Status200OK, ConstantMessages.DataUpdatedSuccessfully, result);
                return Ok(response);
            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _clientService.DeleteClient(id);
            if (result.Equals(0))
            {
                Response response =
                    new(StatusCodes.Status400BadRequest, ConstantMessages.ClientDoesNotExist, result);
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
