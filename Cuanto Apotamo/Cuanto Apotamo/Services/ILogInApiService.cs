using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    interface ILogInApiService
    {
        Task<LogInApiResponse> Authenticate(Credentials userCredentials);
    }
}
