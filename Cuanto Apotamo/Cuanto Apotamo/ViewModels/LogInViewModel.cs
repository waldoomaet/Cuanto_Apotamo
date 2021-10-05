﻿using Cuanto_Apotamo.Models;
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
    class LogInViewModel : BaseViewModel
    {
        public Credentials Credentials { get; set; }

        private IPageDialogService _alertService;
        private ILogInApiService _logInService;

        public ICommand LogInCommand { get; set; }
        public LogInViewModel(INavigationService navigationService, ILogInApiService LogInApiService, IPageDialogService dialogService) : base(navigationService)
        {
            Credentials = new Credentials();
            LogInCommand = new DelegateCommand(OnLogIn);
            _alertService = dialogService;
            _logInService = LogInApiService;
        }
        private async void OnLogIn()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await _logInService.Authenticate(Credentials);
                if (response.Status == "success")
                {
                    await _alertService.DisplayAlertAsync("Success!", $"Tu usuario fue autenticado satisfactoriamente!", "Ok");
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
    }
}
