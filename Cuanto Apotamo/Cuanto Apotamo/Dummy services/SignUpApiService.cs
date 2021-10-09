using Cuanto_Apotamo.Models;
using Cuanto_Apotamo.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Dummy_services
{
    class SignUpApiService : ISignUpApiService
    {
        public async Task<SignUpApiResponse> Create(User newUser)
        {
            if (newUser.Password != newUser.ReEnteredPassword)
            {
                Dictionary<string, string> responseData = new Dictionary<string, string>()
                {
                    {"password", "Both passwords must be equal!"}
                };
                return new SignUpApiResponse() { Status = "fail", Data = responseData, ErrorMessage = "" };
            }

            // Basic validation to assure that any property is null
            foreach (PropertyInfo prop in newUser.GetType().GetProperties())
            {
                if (prop.GetValue(newUser) is null)
                {
                    Dictionary<string, string> responseData = new Dictionary<string, string>()
                    {
                        {prop.Name, $"{prop.Name} is required! {prop.GetValue(newUser)} was passed."}
                    };
                    return new SignUpApiResponse() { Status = "fail", Data = responseData, ErrorMessage = "" };
                }
            }

            return new SignUpApiResponse() { Status = "success", Data = newUser, ErrorMessage = "" };
        }

        public async Task<string> Test()
        {
            return "Hello world!";
        }
    }
}
