using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cuanto_Apotamo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BetView : Frame
    {
        public BetView()
        {
            InitializeComponent();
        }
        //private void OnSegmentSelected(object sender, Plugin.Segmented.Event.SegmentSelectEventArgs e)
        //{
        //    var selectedIndex = e.NewValue;
        //    switch (selectedIndex)
        //    {
        //        case 0:
        //            selectedValue.Text = "1";
        //            break;
        //        case 1:
        //            selectedValue.Text = "2";
        //            break;
        //        case 2:
        //            selectedValue.Text = "3";
        //            break;
        //    }
        //}
    }
}