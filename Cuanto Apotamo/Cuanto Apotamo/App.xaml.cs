using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cuanto_Apotamo.Views;
using Cuanto_Apotamo.ViewModels;
using Cuanto_Apotamo.Services;
using Cuanto_Apotamo.Models;

namespace Cuanto_Apotamo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            var user = new User()
            {
                Id = 1,
                FullName = "Waldo Ruiz",
                Username = "wruiz",
                IdentificationDocument = "abc123",
                CreditCardNumber = "1234123412341234",
                CVV = 123,
                CreditCardExpirationDate = DateTime.Now,
                Email = "Email@email.com",
                Balance = 215.68f
            };
            NavigationService.NavigateAsync($"{Constants.Navigation.Root}/{Constants.Navigation.NavigationPage}/{Constants.Navigation.Balance}", user.ToNavigationParameters());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RootTabbedPage, RootTabbedViewModel>(Constants.Navigation.Tab);
            containerRegistry.RegisterForNavigation<BalancePage, BalanceViewModel>(Constants.Navigation.Balance);
            containerRegistry.RegisterForNavigation<SearchPage>(Constants.Navigation.Search);
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.Navigation.NavigationPage);
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(Constants.Navigation.MainPage);
            containerRegistry.RegisterForNavigation<Root, RootViewModel>(Constants.Navigation.Root);
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpViewModel>(Constants.Navigation.SignUp);
            containerRegistry.RegisterForNavigation<LogInPage, LogInViewModel>(Constants.Navigation.LogIn);
            containerRegistry.RegisterForNavigation<TempPage, TempViewModel>(Constants.Navigation.Temp);
            containerRegistry.Register<IUserApiService, UserApiService>();
        }
    }
}
