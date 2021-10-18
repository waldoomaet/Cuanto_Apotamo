using Cuanto_Apotamo.Models;
using Cuanto_Apotamo.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Cuanto_Apotamo.ViewModels
{
    class RootTabbedViewModel : BaseViewModel, INavigatedAware
    {
        public User User { get; set; }
        public BetOption SelectedBetOption { get; set; }
        public ObservableCollection<Bet> Bets { get; set; }
        public int test { get; set; } = 0;
        public ICommand SelectBetOptionCommand { get; set; }
        private IBetApiService _betService { get; set; }
        private IPageDialogService _alertService { get; set; }
        public RootTabbedViewModel(INavigationService navigationService, IBetApiService betService, IPageDialogService dialogService) : base(navigationService)
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
            Bets = GetBets("").Result;
        }
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            User = new User(parameters);
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        private async Task<ObservableCollection<Bet>> GetBets(string category)
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var response = await _betService.GetBets(category);
                    Console.WriteLine(response.Data);
                    if (response.Status == Constants.ApiResponse.Success)
                    {
                        var bets = JsonSerializer.Deserialize<IEnumerable<Bet>>(JsonSerializer.Serialize(response.Data));
                        return (ObservableCollection<Bet>)bets;
                    }
                    else if (response.Status == Constants.ApiResponse.Fail)
                    {
                        await _alertService.DisplayAlertAsync(Constants.Balance.FailTitle, Constants.Balance.FailMessage, Constants.Balance.FailButton);
                        return null;
                    }
                    else
                    {
                        await _alertService.DisplayAlertAsync(Constants.Balance.ErrorTitle, response.ErrorMessage, Constants.Balance.ErrorButton);
                        return null;
                    }
                }
                else
                {
                    await _alertService.DisplayAlertAsync(Constants.Balance.ErrorTitle, Constants.Balance.InternetError, Constants.Balance.ErrorButton);
                    return null;
                }
            }
            catch (Exception err)
            {
                await _alertService.DisplayAlertAsync(Constants.Balance.ErrorTitle, err.Message, Constants.Balance.ErrorButton);
                return null;
            }
        }
    }
}
