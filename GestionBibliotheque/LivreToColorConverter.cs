using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GestionBibliotheque;

public class LivreToColorConverter : IValueConverter
{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int anneePublicationTmp = (int)value;

            if (anneePublicationTmp < 2010)
            {
                return Brushes.Red;
            }
            else
            {
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
}

    
