using System.Globalization;
using System.Windows.Data;

namespace WPF_FINAL.Converters
{
    public class GradesToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<int> grades)
            {
                return string.Join(", ", grades); // Об'єднує колекцію чисел у рядок
            }
            return string.Empty; // Якщо колекція порожня
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string text)
                {
                    var grades = new List<int>();
                    var parts = text.Split(',');

                    foreach (var part in parts)
                    {
                        if (int.TryParse(part.Trim(), out int result))
                        {
                            grades.Add(result);
                        }
                        else
                        {
                            Console.WriteLine($"Could not convert '{part}' to a number.");
                            return new List<int>(); // Повертає порожній список у разі помилки
                        }
                    }
                    return grades; // Повертає список чисел
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion error: {ex.Message}"); // Обробка винятка
            }

            return new List<int>(); // Повертає порожній список у разі помилки
        }
    }
}