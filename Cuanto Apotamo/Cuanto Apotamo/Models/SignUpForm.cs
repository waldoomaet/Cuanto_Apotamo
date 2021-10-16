using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.Models
{
    class SignUpForm
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string IdentificationDocument { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public int? CVV { get; set; }
        public DateTime? CreditCardExpirationDate { get; set; } = DateTime.Now;
        public string Password { get; set; }
        public string ReEnteredPassword { get; set; }
    }
}
