using Cuanto_Apotamo.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Cuanto_Apotamo.ViewModels
{
    class RootTabbedViewModel : BaseViewModel, INavigatedAware
    {
        public User User { get; set; }
        public BetOption SelectedBetOption { get; set; }
        public ObservableCollection<Bet> Bets { get; set; }
        public int test { get; set; } = 0;
        public ICommand SelectBetOptionCommand { get; set; }
        public RootTabbedViewModel(INavigationService navigationService) : base(navigationService)
        {
            SelectBetOptionCommand = new DelegateCommand<BetOption>((BetOption betOption) => 
            {
                var bets = Bets.ToList();
                foreach(var innerBet in bets)
                {
                    foreach(var innerBetOption in innerBet.BetOptions)
                    {
                        if(innerBetOption.Title == betOption.Title)
                        {
                            var index = bets.IndexOf(innerBet);
                            Bets[index].SelectedBetOption = betOption;
                            innerBet.SelectedBetOption = betOption;
                            break;
                        }
                    }
                }
            });
          
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
