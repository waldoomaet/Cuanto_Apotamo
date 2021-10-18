using Cuanto_Apotamo.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cuanto_Apotamo.Services
{
    class UserApiService : IUserApiService
    {
        private static HttpClient _client = new HttpClient();
        public UserApiService()
        {
            _client.BaseAddress = new Uri(Constants.Url.Api);
        }

        public async Task<ApiResponse> Authenticate(Credentials userCredentials)
        {
            var response = await _client.PostAsync(Constants.Url.LogInPath, new StringContent(JsonSerializer.Serialize(userCredentials), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResponse>(responseString);
        }

        public async Task<ApiResponse> Create(SignUpForm newUser)
        {
            var response = await _client.PostAsync(Constants.Url.SignUpPath, new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResponse>(responseString);
        }

        public async Task<ApiResponse> Deposit(TransactionForm transaction)
        {
            var response = await _client.PostAsync(Constants.Url.DepositPath, new StringContent(JsonSerializer.Serialize(transaction), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResponse>(responseString);
        }
        public async Task<ApiResponse> Withdraw(TransactionForm transaction)
        {
            var response = await _client.PostAsync(Constants.Url.WithdrawPath, new StringContent(JsonSerializer.Serialize(transaction), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResponse>(responseString);
        }
    }
}
