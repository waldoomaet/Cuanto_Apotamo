using Cuanto_Apotamo.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Cuanto_Apotamo.ViewModels
{
    class RootTabbedViewModel : BaseViewModel, INavigatedAware
    {
        public User User { get; set; }
        public ObservableCollection<Bet> Bets { get; set; }
        public ICommand TestCommand { get; set; }
        public RootTabbedViewModel(INavigationService navigationService) : base(navigationService)
        {
            TestCommand = new DelegateCommand(() => 
            { 
                Console.WriteLine("Hola"); 
            });
            Bets = new ObservableCollection<Bet>() 
            { 
                new Bet("Hola", 100, 100, "This bet is open", new List<BetOption>()),
                new Bet("Hola", 100, 100, "This bet is open", new List<BetOption>()),
                new Bet("Hola", 100, 100, "This bet is open", new List<BetOption>()),
                new Bet("Hola", 100, 100, "This bet is open", new List<BetOption>())
            };
        }
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            User = new User(parameters);
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }
    }
}
