using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.Models
{
    class Bet
    {
        public Bet(string title, float totalBets, int totalPlayers, string betclose, List<BetOption> options)
        {
            Title = title;
            TotalBets = totalBets;
            TotalPlayers = totalPlayers;
            BetClose = betclose;
            BetOptions = options;
            SelectedBetOption = options[0];
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BetClose { get; set; }
        public float TotalBets { get; set; }
        public int TotalPlayers { get; set; }
        public BetStatus Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public BetOption SelectedBetOption { get; set; }
        public List<BetOption> BetOptions { get; set; }
    }
    public enum BetStatus
    {
        Open = 1,
        Close = 2,
        Complete = 3
    }
}
