﻿using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cuanto_Apotamo.Views;
using Cuanto_Apotamo.ViewModels;
using Cuanto_Apotamo.Services;

namespace Cuanto_Apotamo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Root}/{Constants.Navigation.MainPage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.Navigation.NavigationPage);
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(Constants.Navigation.MainPage);
            containerRegistry.RegisterForNavigation<Root, RootViewModel>(Constants.Navigation.Root);
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpViewModel>(Constants.Navigation.SignUp);
            containerRegistry.RegisterForNavigation<LogInPage, LogInViewModel>(Constants.Navigation.LogIn);
            containerRegistry.Register<ISignUpApiService, Dummy_services.SignUpApiService>();
            containerRegistry.Register<ILogInApiService, Dummy_services.LogInApiService>();
        }
    }
}
