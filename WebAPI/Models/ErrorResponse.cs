using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ErrorResponse : IResponse
    {
        public string Status { get; set; }

        public object Data { get; set; } = null;
        public string ErrorMessage { get; set; }

        public ErrorResponse(string message) => this.SetResponse(errorMessage:message);

        public void SetResponse(object data = null, string errorMessage = "")
        {
            this.Status = "error";
            this.ErrorMessage = errorMessage;
        }
    }
}
