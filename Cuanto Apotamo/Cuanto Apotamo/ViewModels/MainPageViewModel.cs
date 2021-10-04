using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        public string Text => "Hello world";
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
