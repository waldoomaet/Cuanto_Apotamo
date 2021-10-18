using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    class BetApiService : IBetApiService
    {
        private static HttpClient _client = new HttpClient();
        public BetApiService()
        {
            _client.BaseAddress = new Uri(Constants.Url.Api);
        }
        public async Task<BetsApiResponse> GetBets(string category)
        {
            var response = await _client.GetAsync($"{Constants.Url.BetsPath}{category}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<BetsApiResponse>(responseString);
        }
    }
}
