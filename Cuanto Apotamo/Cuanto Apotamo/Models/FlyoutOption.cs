using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.Models
{
    public class FlyoutOption
    {
        public string Title { get; set; }
        public bool IsStarted { get; set; } = false;
        public bool IsNotStarted { set { IsNotStarted = !IsStarted; } }
        
        public FlyoutOption(string title)
        {
            Title = title;
        }
    }
}
