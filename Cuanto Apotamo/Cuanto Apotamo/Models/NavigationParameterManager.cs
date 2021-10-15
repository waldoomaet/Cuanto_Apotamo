using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Cuanto_Apotamo.Models
{
    class NavigationParameterManager
    {
        public NavigationParameterManager() { }
        public NavigationParameterManager(INavigationParameters navegationParameters)
        {
            this.ToObject(navegationParameters);
        }

        private void ToObject(INavigationParameters navegationParameters)
        {
            foreach(var pair in navegationParameters)
            {
                PropertyInfo prop = this.GetType().GetProperty(pair.Key);
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if(type == typeof(DateTime))
                {
                    prop.SetValue(this, DateTime.Parse(navegationParameters.GetValue<string>(pair.Key)));
                }
                else if(type == typeof(float))
                {
                    prop.SetValue(this, float.Parse(navegationParameters.GetValue<string>(pair.Key)));
                }
                else
                {
                    prop.SetValue(this, pair.Value);
                }
            }
        }
        public INavigationParameters ToNavigationParameters()
        {
            var navParameters = new NavigationParameters();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                navParameters.Add(prop.Name, prop.GetValue(this));
            }
            return navParameters;
        }
    }
}
