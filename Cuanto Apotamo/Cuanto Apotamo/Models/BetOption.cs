using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.Models
{
    class BetOption
    {
        public BetOption(string title, float totalBets, int totalPlayers, float stake)
        {
            Title = title;
            TotalBets = totalBets;
            TotalPlayers = totalPlayers;
            Stake = stake;
        }
        public int Id { get; set; }
        public int BetId { get; set; }
        public string Title { get; set; }
        public float TotalBets { get; set; }
        public int TotalPlayers { get; set; }
        public float Stake { get; set; }
        public bool DidWin { get; set; }
    }
}
