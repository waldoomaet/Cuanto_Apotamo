using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SuccessResponse:IResponse
    {
        public string Status { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; } = "";
        public SuccessResponse(object data) => this.SetResponse(data);

        private void SetResponse(object data, string errorMessage = "")
        {
            this.Status = "success";
            this.Data = data;
        }
    }
}
