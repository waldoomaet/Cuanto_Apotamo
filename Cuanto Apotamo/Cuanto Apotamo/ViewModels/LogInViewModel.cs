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
                // This is an API bypass
                if (Credentials.UserName == "true" && Credentials.Password == "true")
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
                    await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Tab}", user.ToNavigationParameters());
                }
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var response = await _userService.Authenticate(Credentials);
                    Console.WriteLine(response.Data);
                    if (response.Status == "success")
                    {
                        // await _alertService.DisplayAlertAsync(Constants.LogIn.SuccessTitle, Constants.LogIn.SuccessMessage, Constants.LogIn.SuccessButton);
                        var user = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                        await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Tab}", user.ToNavigationParameters());
                    }
                    else if (response.Status == "fail")
                    {
                        await _alertService.DisplayAlertAsync(Constants.LogIn.FailTitle, Constants.LogIn.FailMessage, Constants.LogIn.FailButton);
                    }
                    else
                    {
                        await _alertService.DisplayAlertAsync(Constants.LogIn.ErrorTitle, response.ErrorMessage, Constants.LogIn.ErrorButton);
                    }
                }
                else
                {
                    await _alertService.DisplayAlertAsync(Constants.LogIn.ErrorTitle, Constants.LogIn.InternetError, Constants.LogIn.ErrorButton);
                }
            }
            catch (Exception err)
            {

                await _alertService.DisplayAlertAsync(Constants.LogIn.ErrorTitle, err.Message, Constants.LogIn.ErrorButton);
            }
        }
    }
}
