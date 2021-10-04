using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    interface ISignUpApiService
    {
        Task<string> Test();
        Task<SignUpApiResponse> Create(User newUser);
    }
}
