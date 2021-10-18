using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    interface IBetApiService
    {
        Task<BetsApiResponse> GetBets(string category);
    }
}
