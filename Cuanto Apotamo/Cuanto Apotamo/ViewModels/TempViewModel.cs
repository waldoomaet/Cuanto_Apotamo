using Cuanto_Apotamo.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.ViewModels
{
    class TempViewModel : BaseViewModel
    {
        public Bet Bet { get; set; }

        public TempViewModel(INavigationService navigationService) : base(navigationService)
        {
            Bet = new Bet()
            {
                Title = "Probando",
                BetClose= "jsfajoifajf",
                TotalBet= 1000,
                TotalPlayers=30,
                Deal="si te agacha te lo meto"
            };
        }



    }
}
