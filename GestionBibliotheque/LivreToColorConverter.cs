using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GestionBibliotheque;

public class LivreToColorConverter : IValueConverter
{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          
            Boolean dispotmp = (Boolean)value;
            if (dispotmp == true)
            {
                return Brushes.Green;
            }
            else
            {
                return Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
}

    
