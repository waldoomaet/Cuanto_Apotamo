using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cuanto_Apotamo.Models
{
    class User : NavigationParameterManager
    {
        public User() { }
        public User(INavigationParameters navigationParameters) : base(navigationParameters) { }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("identificationDocument")]
        public string IdentificationDocument { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("creditCardNumber")]
        public string CreditCardNumber { get; set; }

        [JsonPropertyName("cvv")]
        public int? CVV { get; set; }

        [JsonPropertyName("creditCardExpirationDate")]
        public DateTime? CreditCardExpirationDate { get; set; } = DateTime.Now;

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("balance")]
        public float Balance { get; set; }
    }
}
