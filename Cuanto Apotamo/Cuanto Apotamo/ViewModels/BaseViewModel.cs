using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cuanto_Apotamo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigationService NavigationService { get; private set; }
        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
