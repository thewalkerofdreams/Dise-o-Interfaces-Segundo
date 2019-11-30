using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _18_CRUD_Personas_UWP_UI.Models
{
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String fecha = null;
            DateTime dt = new DateTime();

            if (value != null)
            {
                dt = DateTime.Parse(value.ToString());
                fecha = dt.ToString("dd/MM/yyyy");
            }
            
            return fecha;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTime oDate = DateTime.ParseExact((String) value, "dd/MM/yyyy", null);
            return oDate;
        }
    }
}
