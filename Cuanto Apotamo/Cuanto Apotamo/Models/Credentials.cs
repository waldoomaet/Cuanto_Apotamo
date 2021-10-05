using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cuanto_Apotamo.Models
{
    class Credentials
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
