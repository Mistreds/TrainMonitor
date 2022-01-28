using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrainMonitor.Model
{
   
        public class DateTimeConvert : IValueConverter
        {
            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
            var date = new DateTime(0001, 1, 1, 0, 0,0);
            if (date == DateTime.Parse(value.ToString()))
            { 
                return "Нет данных";
            }
                return ((DateTime)value).ToString("dd.MM.yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    
}
