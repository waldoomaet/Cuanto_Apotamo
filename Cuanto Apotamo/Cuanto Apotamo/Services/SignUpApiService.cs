using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    class SignUpApiService : ISignUpApiService
    {
        private static HttpClient _client = new HttpClient();

        public SignUpApiService()
        {
            _client.BaseAddress = new Uri(Constants.URL.API);
        }
        public async Task<SignUpApiResponse> Create(User newUser)
        {
            var response = await _client.PostAsync("api/SignUp/Create", new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SignUpApiResponse>(responseString);
        }

        public async Task<string> Test()
        {
            try
            {
                var response = await _client.GetAsync("api/SignUp/Test");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}