using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain
{
    public enum BetStatus
    {
        Open =1,
        Close=2,
        Complete=3
    }
    public class Bet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float TotalBets { get; set; }
        public int TotalPlayers { get; set; }
        public BetStatus Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<BetOption> BetOptions { get; set; }
    }
}
