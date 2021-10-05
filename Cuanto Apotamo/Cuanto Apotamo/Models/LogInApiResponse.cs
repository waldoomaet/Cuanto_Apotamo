using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cuanto_Apotamo.Models
{
    class LogInApiResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
