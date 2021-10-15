using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.Models
{
    class Bet
    {
        public Bet(string title, float totalBet, string deal, string betClose, int totalPlayers)
        {
            Title = title;
            TotalBet = totalBet;
            Deal = deal;
            BetClose = betClose;
            TotalPlayers = totalPlayers;
        }

        public string Title { get; set; }
        public float TotalBet { get; set; }
        public string Deal { get; set; }
        public string BetClose { get; set; }
        public int TotalPlayers { get; set; }
        List<BetOption> Options { get; set; }
    }
}
