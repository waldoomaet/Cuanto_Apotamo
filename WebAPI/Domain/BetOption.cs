using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain
{
    public class BetOption
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public Bet Bet { get; set; }
        public string Title { get; set; }
        public float TotalBets { get; set; }
        public int TotalPlayers { get; set; }
        public float Stake { get; set; }
        public bool DidWin { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<UserBet> UserBets { get; set; }
    }
}
