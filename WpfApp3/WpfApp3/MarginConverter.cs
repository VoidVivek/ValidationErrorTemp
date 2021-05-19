using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp3
{
    public class MarginConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness thickness = new Thickness(0,0,0,0);

            if (value is AdornedElementPlaceholder adornedElementPlaceholder)
            {
                var something = (adornedElementPlaceholder.AdornedElement as ItemsControl)?.ItemContainerGenerator;
                var items = something.Items;
                for (int i = 0; i < items.Count; i++)
                {
                    DependencyObject doItem = (adornedElementPlaceholder.AdornedElement as ItemsControl)
                        ?.ItemContainerGenerator.ContainerFromIndex(i);
                    if (doItem != null)
                    {
                        if (VisualTreeHelper.GetChild(doItem, 0) is Grid grid)
                        {
                            thickness.Left = grid.ColumnDefinitions[i].ActualWidth + 10;
                            break;
                        }
                    }
                }
            }

            return thickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}