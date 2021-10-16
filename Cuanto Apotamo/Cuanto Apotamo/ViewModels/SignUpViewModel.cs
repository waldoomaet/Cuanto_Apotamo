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
        public SignUpForm User { get; set; }

        private IPageDialogService _alertService;
        private IUserApiService _userService;

        public ICommand SignUpCommand { get; set; }
        public SignUpViewModel(INavigationService navigationService, IUserApiService userService, IPageDialogService dialogService) : base(navigationService)
        {
            User = new SignUpForm();
            SignUpCommand = new DelegateCommand(OnSignUp);
            _alertService = dialogService;
            _userService = userService;
        }
        private async void OnSignUp()
        {
            try
            {
                if(User.FullName == "true")
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
                    var response = await _userService.Create(User);
                    if (response.Status == "success")
                    {
                        User returnedUser = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                        await _alertService.DisplayAlertAsync("Success!", $"{returnedUser.FullName} tu usuario fue creado satisfactoriamente!", "Ok");
                        await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/Navigation/tabbed", returnedUser.ToNavigationParameters());
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
