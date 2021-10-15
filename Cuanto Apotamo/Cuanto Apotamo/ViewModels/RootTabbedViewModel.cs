using Cuanto_Apotamo.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.ViewModels
{
    class RootTabbedViewModel : BaseViewModel, INavigatedAware
    {
        public User User { get; set; }
        public string Test { get; set; }
        public RootTabbedViewModel(INavigationService navigationService) : base(navigationService)
        {
            Test = "test";
        }
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            User = new User(parameters);
            Test = User.FullName;
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }
    }
}
