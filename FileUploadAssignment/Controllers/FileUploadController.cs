using Microsoft.AspNetCore.Mvc;
using FileUploadAssignment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileUploadAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        string directoryPath = "E:\\Work\\IncubXperts\\ASP.NET\\FileUploadAssignment";

        // POST api/FileUpload
        [HttpPost]
        public string Post([FromForm] FileUploadClass objectFile, string directoryName)
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
                        return "File has been Uploaded.";
                    }
                }
                else
                {
                    return "File Not Uploaded (Check File Size)";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/FileUpload
        [HttpDelete]
        public string Delete([FromForm] string directoryName, string fileName)
        {
            try
            {
                directoryPath = Path.Combine(directoryPath, directoryName);
                string filePath = Path.Combine(directoryPath, fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    return "File has been Deleted.";
                }
                else
                {
                    return "File Not Deleted.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
