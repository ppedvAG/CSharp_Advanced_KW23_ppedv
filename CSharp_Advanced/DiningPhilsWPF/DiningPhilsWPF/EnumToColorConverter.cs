using System;
using System.Windows.Data;
using System.Windows.Media;

namespace DiningPhilsWPF
{
    public   class EnumToColorConverter:IValueConverter
    {
        private Brush[] brushes = new SolidColorBrush[4]
           {
                  Brushes.AntiqueWhite,
                  Brushes.Green,
                  Brushes.Yellow,
                  Brushes.Red
     };
      
        public object Convert(object value, Type targetType, object parameter,
                          System.Globalization.CultureInfo culture)
    {
       
     
          int  enumValue =(int) Enum.Parse(typeof(PhilosopherMode), value.ToString());
     
        return brushes[enumValue];
       
    }

    public object ConvertBack(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            if (null != value)
            {

                return value; 
            }

            return null;
        }
    }
}
