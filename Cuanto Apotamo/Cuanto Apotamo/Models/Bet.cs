using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.Models
{
    class Bet
    {
        public string Title { get; set; }
        public float TotalBet { get; set; }
        public string Deal { get; set; }
        public string BetClose { get; set; }
        public int TotalPlayers { get; set; }
        List<BetOption> Options { get; set; }
    }
}
