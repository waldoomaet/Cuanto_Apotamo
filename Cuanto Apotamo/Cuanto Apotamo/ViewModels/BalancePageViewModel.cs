using Cuanto_Apotamo.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.ViewModels
{
    class BalancePageViewModel : BaseViewModel, INavigatedAware
    {
        public User User { get; set; }
        public BalancePageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            User = new User(parameters);
        }
    }
}
