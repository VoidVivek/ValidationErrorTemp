using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    public class CharacteristicInfoRowTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Return the correct template, based on the type of the row that we want to show.
        /// </summary>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            RowBase row = item as RowBase;
            FrameworkElement element = container as FrameworkElement;

            if (row == null || element == null) return null;

            if (row is CounterTypeCharacteristicRow)
            {
                return element.FindResource("CounterTypeTemplate") as DataTemplate;
            }

            if (row is CounterValueCharacteristicRow)
            {
                return element.FindResource("CounterValueTemplate") as DataTemplate;
            }

            return null;
        }
    }
}
