using Cuanto_Apotamo.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Cuanto_Apotamo.ViewModels
{
    class BetViewModel : BaseViewModel
    {
        public Bet Bet { get; set; } = new Bet("titulo", 1000, 25, "a definir", new List<BetOption> { new BetOption("1", 10, 11, 12), new BetOption("2", 20, 22, 24), new BetOption("3", 30, 33, 36) });

        public BetOption ActualOption { get; set; }
        public string Label { get; set; } = "hola";
        public ICommand SelectCommand { get; set; }

        public BetViewModel(INavigationService navigationService) : base(navigationService)
        {
            ActualOption = Bet.BetOptions[1];
            SelectCommand = new DelegateCommand<Plugin.Segmented.Event.SegmentSelectEventArgs>(OnSegmentSelected);
        }


        private void OnSegmentSelected(Plugin.Segmented.Event.SegmentSelectEventArgs e)
        {
            var selectedIndex = e.NewValue;
            switch (selectedIndex)
            {
                case 0:
                    Label = "1";
                    break;
                case 1:
                    Label = "2";
                    break;
                case 2:
                    Label = "3";
                    break;
            }
        }
    }
}
