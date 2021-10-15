using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain
{
    public class UserBet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BetOptionId { get; set; }
        public BetOption BetOption { get; set; }
        public float Amount { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
