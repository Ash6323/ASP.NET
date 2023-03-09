using Microsoft.AspNetCore.Mvc;
using FileUploadAssignment.Models;
using CustomerLocationAssignment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileUploadAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        string directoryPath = Environment.CurrentDirectory;

        // POST api/FileUpload

        /// <summary>
        /// Takes a File and new Directory Name in which File is to be Uploaded 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/FileUpload/
        ///
        /// </remarks>
        /// <response code="201">  If File is Uploaded Successfully</response>
        /// <response code="400">  If Anything is Missing from Client Side's Request</response>
        [HttpPost]
        public IActionResult Post([FromForm] FileUploadClass objectFile, string directoryName)
        {
            try
            {
                if(objectFile.file.Length > 10485760)   //10 MB in Bytes (10 * 1024 * 1024)
                {
                    directoryPath = Path.Combine(directoryPath, directoryName);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    using (FileStream fileStream = System.IO.File.Create(Path.Combine(directoryPath, objectFile.file.FileName)))
                    {
                        objectFile.file.CopyTo(fileStream);
                        Response responseFileUploaded = new (StatusCodes.Status201Created, ConstantMessages.FileUploaded);
                        return Ok(responseFileUploaded);
                    }
                }
                Response responseCheckFileSize = new(StatusCodes.Status400BadRequest, ConstantMessages.CheckFileSize);
                return BadRequest(responseCheckFileSize);
            }
            catch(Exception ex)
            {
                Response response = new(StatusCodes.Status400BadRequest, ex.Message);
                return BadRequest(response);
            }
        }

        // DELETE api/FileUpload

        /// <summary>
        /// Takes Direcotory Name, File Name as Input and Deletes the File
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /api/FileUpload
        ///
        /// </remarks>
        /// <response code="204">  File is Deleted Successfully. No reponse Data is included as it is deleted</response>
        /// <response code="400">  Bad Request by Client</response>
        /// <response code="404">  If File not Found</response>
        [HttpDelete]
        public IActionResult Delete([FromForm] string directoryName, string fileName)
        {
            try
            {
                directoryPath = Path.Combine(directoryPath, directoryName);
                string filePath = Path.Combine(directoryPath, fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    Response responseFileDeleted = new(StatusCodes.Status200OK, ConstantMessages.FileDeleted);
                    return Ok(responseFileDeleted);
                }
                Response responseFileNotDeleted = new(StatusCodes.Status400BadRequest, ConstantMessages.FileNotDeleted);
                return Ok(responseFileNotDeleted);
            }
            catch (Exception ex)
            {
                Response response = new(StatusCodes.Status400BadRequest, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
