using Cuanto_Apotamo.Models;
using Cuanto_Apotamo.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
                TransactionForm withdraw = new TransactionForm();
                var response = await _userService.Withdraw(withdraw);
                if (response.Status == "success")
                {
                    await _alertService.DisplayAlertAsync("Success!", $"Operación completada con éxito.!", "Ok");
                    //var user = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                    var user = (User)response.Data;
                    await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/Navigation/balance", user.ToNavigationParameters());
                }
                else if (response.Status == "fail")
                {
                    await _alertService.DisplayAlertAsync("Error", $"Usuario o Contraseña Incorrectos", "Ok");
                }
                else
                {
                    await _alertService.DisplayAlertAsync("Error", $"Algo ocurrio: {response.ErrorMessage}", "Ok");
                }
            }
            else
            {
                await _alertService.DisplayAlertAsync("Error", "Compruebe su conexion a Internet", "Ok");
            }
        }

        private async void OnDepositOperation()
        {
            throw new NotImplementedException();
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
