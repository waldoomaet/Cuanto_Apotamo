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
            Bets = new ObservableCollection<Bet>() 
            { 
                new Bet("How will be the weather today?", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("Cloudy", 10, 11, 12), new BetOption("Sunny", 20, 22, 24), new BetOption("Stormy", 30, 33, 36) }),
                new Bet("How much will oil prices rise today? ", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("10.55", 10, 11, 12), new BetOption("20.30", 20, 22, 24), new BetOption("32.3", 30, 33, 36) }),
                new Bet("How many black-outs will EDESUR produce today?", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("10", 10, 11, 12), new BetOption("20", 20, 22, 24), new BetOption("30", 30, 33, 36) }),
                new Bet("How many childs will be born today?", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("100", 10, 11, 12), new BetOption("200", 20, 22, 24), new BetOption("300", 30, 33, 36) })
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
