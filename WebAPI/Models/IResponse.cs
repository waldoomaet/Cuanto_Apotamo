using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IResponse
    {
        private void SetResponse(object data, string errorMessage) { }
    }
}
