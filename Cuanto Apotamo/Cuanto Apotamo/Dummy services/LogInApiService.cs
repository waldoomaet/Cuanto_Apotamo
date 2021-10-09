using Cuanto_Apotamo.Models;
using Cuanto_Apotamo.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Dummy_services
{
    class LogInApiService : ILogInApiService
    {
        public async Task<LogInApiResponse> Authenticate(Credentials userCredentials)
        {
            if (string.IsNullOrEmpty(userCredentials.UserName))
            {
                return new LogInApiResponse() { Status = "fail", ErrorMessage = "User field missing" };
            }
            else if (string.IsNullOrEmpty(userCredentials.Password))
            {
                return new LogInApiResponse() { Status = "fail", ErrorMessage = "User password missing" };
            }
            else if(userCredentials.UserName == "true" && userCredentials.Password == "true")
            {
                var foundUser = new User() {
                    FullName = "Waldo Omaet Ruiz Isaac",
                    Username = "wruiz",
                    IdentificationDocument = "abc1234",
                    Email = "email@email.com",
                    CreditCardNumber = 1234567812345678,
                    CVV = 123,
                    CreditCardExpirationDate = DateTime.Now,
                    Balance = 100
                };
                return new LogInApiResponse() { Status = "success", Data = foundUser, ErrorMessage = "" };
            }
            else
            {
                return new LogInApiResponse() { Status = "fail", ErrorMessage = "User or password missing" };
            }
        }
    }
}
