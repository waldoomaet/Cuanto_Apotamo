using Cuanto_Apotamo.Models;
using Cuanto_Apotamo.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Cuanto_Apotamo.ViewModels
{
    class BalanceViewModel : BaseViewModel, INavigatedAware
    {
        public User User { get; set; }
        public float OperationAmount { get; set; }
        public ICommand DepositCommand { get; set; }
        public ICommand WithdrawCommand { get; set; }
        private IUserApiService _userService;
        private IPageDialogService _alertService;
        public BalanceViewModel(INavigationService navigationService, IUserApiService userService, IPageDialogService dialogService) : base(navigationService)
        {
            _userService = userService;
            _alertService = dialogService;
            DepositCommand = new DelegateCommand(OnDepositOperation);
            WithdrawCommand = new DelegateCommand(OnWithdrawOperation);
        }

        private async void OnWithdrawOperation()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                TransactionForm withdraw = new TransactionForm() { UserId = User.Id, Balance = OperationAmount };
                var response = await _userService.Withdraw(withdraw);
                if (response.Status == Constants.ApiResponse.Success)
                {
                    await _alertService.DisplayAlertAsync(Constants.Balance.SuccessTitle, Constants.Balance.SuccessMessage, Constants.Balance.SuccessButton);
                    var user = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                    await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Balance}", user.ToNavigationParameters());
                }
                else if (response.Status == Constants.ApiResponse.Success)
                {
                    await _alertService.DisplayAlertAsync(Constants.Balance.FailTitle, Constants.Balance.FailMessage, Constants.Balance.FailButton);
                }
                else
                {
                    await _alertService.DisplayAlertAsync(Constants.Balance.ErrorTitle, $"{response.ErrorMessage}", Constants.Balance.ErrorButton);
                }
            }
            else
            {
                await _alertService.DisplayAlertAsync(Constants.Balance.ErrorTitle, Constants.Balance.InternetError, Constants.Balance.ErrorButton);
            }
        }

        private async void OnDepositOperation()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                TransactionForm withdraw = new TransactionForm() { UserId = User.Id, Balance = OperationAmount };
                var response = await _userService.Deposit(withdraw);
                if (response.Status == Constants.ApiResponse.Success)
                {
                    await _alertService.DisplayAlertAsync(Constants.Balance.SuccessTitle, Constants.Balance.SuccessMessage, Constants.Balance.SuccessButton);
                    var user = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                    await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Balance}", user.ToNavigationParameters());
                }
                else if (response.Status == Constants.ApiResponse.Success)
                {
                    await _alertService.DisplayAlertAsync(Constants.Balance.FailTitle, Constants.Balance.FailMessage, Constants.Balance.FailButton);
                }
                else
                {
                    await _alertService.DisplayAlertAsync(Constants.Balance.ErrorTitle, $"{response.ErrorMessage}", Constants.Balance.ErrorButton);
                }
            }
            else
            {
                await _alertService.DisplayAlertAsync(Constants.Balance.ErrorTitle, Constants.Balance.InternetError, Constants.Balance.ErrorButton);
            }
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
