using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class FailResponse : IResponse
    {
        public string Status { get; set; }
        public object Data { get; set; }

        public string ErrorMessage { get; set; } = "";
        public FailResponse(object data) => this.SetResponse(data);

        private void SetResponse(object data, string errorMessage = "")
        {
            this.Status = "fail";
            this.Data = data;
        }
    }
}
