using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cuanto_Apotamo.Models
{
    class User
    {
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("identificationDocument")]
        public string IdentificationDocument { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("creditCardNumber")]
        public Int64? CreditCardNumber { get; set; }

        [JsonPropertyName("cvv")]
        public int? CVV { get; set; }

        [JsonPropertyName("creditCardExpirationDate")]
        public DateTime? CreditCardExpirationDate { get; set; } = DateTime.Now;

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("reEnteredPassword")]
        public string ReEnteredPassword { get; set; }

        [JsonPropertyName("balance")]
        public int Balance { get; set; }

        //public Dictionary<>
    }
}
