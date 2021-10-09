using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    class LogInApiService : ILogInApiService
    {
        private static HttpClient _client = new HttpClient();
        public LogInApiService()
        {
            _client.BaseAddress = new Uri(Constants.Url.Api);
        }
        public async Task<LogInApiResponse> Authenticate(Credentials userCredentials)
        {
            var response = await _client.PostAsync("LogIn/Authenticate", new StringContent(JsonSerializer.Serialize(userCredentials), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LogInApiResponse>(responseString);
        }
    }
}
