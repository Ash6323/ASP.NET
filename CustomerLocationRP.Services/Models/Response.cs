using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLocationRP.Services.Models
{
    public class Response<T>
    {
        public Response(int status, string responseMessage, T data)
        {
            this.StatusCode = status;
            this.Message = responseMessage;
            this.Data = data;
        }
        private int StatusCode { get; set; }
        private string Message { get; set; } = String.Empty;
        private T Data { get; set; }
    }
}
