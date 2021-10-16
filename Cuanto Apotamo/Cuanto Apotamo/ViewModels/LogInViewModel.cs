using Cuanto_Apotamo.Models;
using Cuanto_Apotamo.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Cuanto_Apotamo.ViewModels
{
    class LogInViewModel : BaseViewModel
    {
        public Credentials Credentials { get; set; }

        private IPageDialogService _alertService;
        private IUserApiService _userService;

        public ICommand LogInCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        public LogInViewModel(INavigationService navigationService, IUserApiService userService, IPageDialogService dialogService) : base(navigationService)
        {
            Credentials = new Credentials();
            LogInCommand = new DelegateCommand(OnLogIn);
            CreateAccountCommand = new DelegateCommand(async () =>
            {
                await NavigationService.NavigateAsync($"{Constants.Navigation.SignUp}");
            });
            _alertService = dialogService;
            _userService = userService;
        }
        private async void OnLogIn()
        {
            try
            {
                if(Credentials.UserName == "true" && Credentials.Password == "true")
                {
                    var user = new User()
                    {
                        FullName = "Waldo Ruiz",
                        Username = "wruiz",
                        IdentificationDocument = "abc123",
                        CreditCardNumber = "1234123412341234",
                        CVV = 123,
                        CreditCardExpirationDate = DateTime.Now,
                        Email = "Email@email.com",
                        Balance = 215.68f
                    };
                    await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/Navigation/tabbed", user.ToNavigationParameters());
                }
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var response = await _userService.Authenticate(Credentials);
                    Console.WriteLine(response.Data);
                    if (response.Status == "success")
                    {
                        await _alertService.DisplayAlertAsync("Success!", $"Tu usuario fue autenticado satisfactoriamente!", "Ok");
                        //var user = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                        var user = (User)response.Data;
                        await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/Navigation/tabbed", user.ToNavigationParameters());
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
            catch (Exception err)
            {

                await _alertService.DisplayAlertAsync("Error", err.Message, "Ok");
            }
        }
    }
}
