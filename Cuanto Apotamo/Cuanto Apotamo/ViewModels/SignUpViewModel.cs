using Cuanto_Apotamo.Models;
using Cuanto_Apotamo.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Cuanto_Apotamo.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        public User User { get; set; }
        public string Test { get; set; } = "Prueba";

        private IPageDialogService _alertService;
        private ISignUpApiService _signUpService;

        public ICommand SignUpCommand { get; set; }
        public SignUpViewModel(INavigationService navigationService, ISignUpApiService signUpApiService, IPageDialogService dialogService) : base(navigationService)
        {
            User = new User();
            SignUpCommand = new DelegateCommand(OnSignUp);
            _alertService = dialogService;
            _signUpService = signUpApiService;
        }
        private async void OnSignUp()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await _signUpService.Create(User);
                if (response.Status == "success")
                {
                    User returnedUser = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                    await _alertService.DisplayAlertAsync("Success!", $"{returnedUser.FullName} tu usuario fue creado satisfactoriamente!", "Ok");
                    var navigationParams = new NavigationParameters { };
                    await NavigationService.NavigateAsync($"/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Root}/{Constants.Navigation.MainPage}");
                }
                else if (response.Status == "fail")
                {
                    var returnedData = JsonSerializer.Deserialize<Dictionary<string, string>>(JsonSerializer.Serialize(response.Data));
                    await _alertService.DisplayAlertAsync("Error", $"{returnedData.First().Value}", "Ok");
                }
                else
                {
                    await _alertService.DisplayAlertAsync("Error", $"Algo ocurrio: {response.ErrorMessage}", "Ok");
                }
            }
            else
            {
                await _alertService.DisplayAlertAsync("Error", "Sin conexión a Internet", "Ok");
            }
        }
    }
}
