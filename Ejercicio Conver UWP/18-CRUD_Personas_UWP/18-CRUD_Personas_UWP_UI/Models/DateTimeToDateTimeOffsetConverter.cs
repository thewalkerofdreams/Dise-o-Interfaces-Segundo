using System;
using Windows.UI.Xaml.Data;

namespace _18_CRUD_Personas_UWP_UI.Models
{
    public class DateTimeToDateTimeOffsetConverter : IValueConverter    //Esta clase nos permite convertir un tipo DateTime a DateTimeOffset y viceversa.
    {
        /// <summary>
        /// Comentario: Este método nos permite convertir un tipo de dato DateTime al tipo DateTimeOffset.
        /// </summary>
        /// <param name="value">El tipo DateTime.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTime date = (DateTime)value;
                return new DateTimeOffset(date);
            }
            catch (Exception ex)
            {
                return DateTimeOffset.MinValue;
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite convertir un tipo de dato DateTimeOffset al tipo DateTime.
        /// </summary>
        /// <param name="value">El tipo DateTimeOffset.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTimeOffset dto = (DateTimeOffset)value;
                return dto.DateTime;
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
    }

}
