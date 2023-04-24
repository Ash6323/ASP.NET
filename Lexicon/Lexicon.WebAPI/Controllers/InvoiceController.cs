using Microsoft.AspNetCore.Mvc;
using Lexicon.Data.DTO;
using Lexicon.Data.Models;
using Lexicon.Data;
using Lexicon.Services.Interfaces;

namespace Lexicon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _invoiceService;
        public InvoiceController(IInvoice invoiceRepository)
        {
            _invoiceService = invoiceRepository;
        }
        // GET: api/<MatterController>
        [HttpGet]
        public IActionResult Get()
        {
            List<InvoiceDto> result = _invoiceService.GetInvoices();
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
            InvoiceDto result = _invoiceService.GetInvoice(id);
            if (result != null)
            {
                Response invoiceExistsResponse = new
                (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(invoiceExistsResponse);
            }
            Response invoiceNotExistsResponse = new
            (StatusCodes.Status404NotFound, ConstantMessages.InvoiceDoesNotExist, null);
            return NotFound(invoiceNotExistsResponse);
        }
        [HttpGet("GetByMatters")]
        public IActionResult GetByMatters()
        {
            IEnumerable<IGrouping<int, InvoiceDto>> result = _invoiceService.GetInvoicesByMatters();
            if (result == null)
            {
                Response noInvoicesByMattersResponse = new
                (StatusCodes.Status404NotFound, ConstantMessages.InvoicesByMattersNotFound, null);
                return NotFound(noInvoicesByMattersResponse);
            }
            else
            {
                Response invoicesByMattersExistsResponse = new
                (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(invoicesByMattersExistsResponse);
            }
        }
        [HttpGet("GetByMatter/{id}")]
        public IActionResult GetByMatter(int id)
        {
            List<InvoiceDto> result = _invoiceService.GetInvoicesByMatter(id);
            if (result == null)
            {
                Response noInvoicesByMatterResponse = new
                (StatusCodes.Status404NotFound, ConstantMessages.InvoicesByMatterNotFound, null);
                return NotFound(noInvoicesByMatterResponse);
            }
            else
            {
                Response invoicesByMatterExistsResponse = new
                (StatusCodes.Status200OK, ConstantMessages.DataRetrievedSuccessfully, result);
                return Ok(invoicesByMatterExistsResponse);
            }
        }

        // POST api/<MatterController>
        [HttpPost]
        public IActionResult Post(InvoiceDto invoice)
        {
            int result = _invoiceService.AddInvoice(invoice);
            if (result.Equals(0))
            {
                Response response = new
                    (StatusCodes.Status400BadRequest, ConstantMessages.InvoiceAlreadyExists,
                                                        ConstantMessages.InvoiceAlreadyExists);
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
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] MatterDto updatedMatter)
        //{
        //    int result = _invoiceService.UpdateMatter(id, updatedMatter);
        //    if (result.Equals(0))
        //    {
        //        Response response = new
        //            (StatusCodes.Status404NotFound, ConstantMessages.MatterDoesNotExist,
        //                                            ConstantMessages.MatterDoesNotExist);
        //        return NotFound(response);
        //    }
        //    else
        //    {
        //        Response response = new(StatusCodes.Status200OK, ConstantMessages.DataUpdatedSuccessfully, result);
        //        return Ok(response);
        //    }
        //}

        // DELETE api/<MatterController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    int result = _invoiceService.DeleteMatter(id);
        //    if (result.Equals(0))
        //    {
        //        Response response =
        //            new(StatusCodes.Status400BadRequest, ConstantMessages.MatterDoesNotExist, result);
        //        return BadRequest(response);
        //    }
        //    else
        //    {
        //        Response response = new(StatusCodes.Status200OK, ConstantMessages.DataDeletedSuccessfully, null);
        //        return Ok(response);
        //    }
        //}
    }
}
