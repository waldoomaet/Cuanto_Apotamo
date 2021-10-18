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
                // This is an API bypass
                if (User.FullName == "true")
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
                    var response = await _userService.Create(User);
                    if (response.Status == Constants.ApiResponse.Success)
                    {
                        User returnedUser = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                        await _alertService.DisplayAlertAsync(Constants.SignUp.SuccessTitle, $"{returnedUser.FullName} {Constants.SignUp.SuccessMessage}", Constants.SignUp.SuccessButton);
                        await NavigationService.NavigateAsync($"/{Constants.Navigation.Root}/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Tab}", returnedUser.ToNavigationParameters());
                    }
                    else if (response.Status == Constants.ApiResponse.Fail)
                    {
                        var returnedData = JsonSerializer.Deserialize<Dictionary<string, string>>(JsonSerializer.Serialize(response.Data));
                        await _alertService.DisplayAlertAsync(Constants.SignUp.FailTitle, returnedData.First().Value, Constants.SignUp.FailButton);
                    }
                    else
                    {
                        await _alertService.DisplayAlertAsync(Constants.SignUp.ErrorTitle, response.ErrorMessage, Constants.SignUp.ErrorButton);
                    }
                }
                else
                {
                    await _alertService.DisplayAlertAsync(Constants.SignUp.ErrorTitle, Constants.SignUp.InternetError, Constants.SignUp.ErrorButton);
                }
            }
            catch (Exception err)
            {
                await _alertService.DisplayAlertAsync(Constants.SignUp.ErrorTitle, err.Message, Constants.SignUp.ErrorButton);
            }
        }
    }
}
