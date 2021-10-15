using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public string Text => "Hello world";
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
