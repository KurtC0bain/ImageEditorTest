using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ConsoleWpfAppTest.mvvm.UserControls
{
    public class ImageSourceToSizeConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            if (value is not BitmapImage image)
            {
                throw new ArgumentException("value is not BitmapImage type", nameof(value));
            }

            return $"{image.PixelWidth}x{image.PixelHeight}";
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }
}
