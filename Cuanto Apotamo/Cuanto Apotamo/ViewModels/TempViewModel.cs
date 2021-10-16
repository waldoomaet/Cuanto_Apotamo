using Cuanto_Apotamo.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Cuanto_Apotamo.ViewModels
{
    class TempViewModel : BaseViewModel
    {
        public BetViewModel bet { get; set; }
        
        public TempViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
    }
}
