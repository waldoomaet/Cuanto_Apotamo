using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    interface IUserApiService
    {
        Task<ApiResponse> Authenticate(Credentials userCredentials);
        Task<ApiResponse> Create(SignUpForm newUser);
        Task<ApiResponse> Deposit(TransactionForm transaction);
        Task<ApiResponse> Withdraw(TransactionForm transaction);
    }
}
