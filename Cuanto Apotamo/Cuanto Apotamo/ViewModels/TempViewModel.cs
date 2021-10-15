using Cuanto_Apotamo.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.ViewModels
{
    class TempViewModel : BaseViewModel
    {
        public Bet Bet { get; set; } = new Bet("titulo", 1000, "te la entierro", "donde hay tierra", 25);

        public TempViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }



    }
}
