using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Cuanto_Apotamo.ViewModels
{
    class RootViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; set; }
        public RootViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(async (string path) =>
            {
                await NavigationService.NavigateAsync(path);
            });
        }
    }
}