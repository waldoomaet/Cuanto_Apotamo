using Cuanto_Apotamo.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Cuanto_Apotamo.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        public ObservableCollection<FlyoutOption> FlyoutOptions { get; set; }
        public ObservableCollection<FlyoutOption> FavoriteFlyoutOptions { get; set; }
        public FlyoutOption SelectedFavoriteFlyoutOption { get; set; }
        public FlyoutOption SelectedFlyoutOption { get; set; }
        public ICommand NavigateCommand { get; set; }
        public ICommand StarCommand { get; set; }
        public bool HasFavorites { get; set; }
        public string Money { get; set; } = $"$200";
        public RootViewModel(INavigationService navigationService) : base(navigationService)
        {
            // TODO: This must be an API call that brings all the favorite categories of the user
            FavoriteFlyoutOptions = new ObservableCollection<FlyoutOption>();
            HasFavorites = FavoriteFlyoutOptions.Count > 0;
            // TODO: This must be an API call that brings all the categories of the Flyout
            FlyoutOptions = new ObservableCollection<FlyoutOption>() { new FlyoutOption("Politica"), new FlyoutOption("Musica"), new FlyoutOption("Arte") };
            StarCommand = new DelegateCommand<FlyoutOption>(OnStartClicked);
            NavigateCommand = new DelegateCommand<string>(async (string path) =>
            {
                await NavigationService.NavigateAsync($"Navigation/{path.ToLower()}");
            });
        }

        public void OnStartClicked(FlyoutOption option)
        {
            option.IsStarted = !option.IsStarted;
            if (!option.IsStarted)
            {
                FavoriteFlyoutOptions.Remove(option);
                FlyoutOptions.Add(option);
            }
            else
            {
                FlyoutOptions.Remove(option);
                FavoriteFlyoutOptions.Add(option);
            }
            HasFavorites = FavoriteFlyoutOptions.Count > 0;
        }
    }
}