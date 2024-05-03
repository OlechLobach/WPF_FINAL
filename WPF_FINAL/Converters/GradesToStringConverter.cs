using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace WPF_FINAL.Converters
{
    public class GradesToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<int> grades)
            {
                return string.Join(", ", grades); // Об'єднання чисел у рядок
            }
            return string.Empty; // Повертає порожній рядок, якщо колекція порожня
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                var grades = new List<int>();
                var parts = text.Split(',');

                foreach (var part in parts)
                {
                    if (int.TryParse(part.Trim(), out int result))
                    {
                        grades.Add(result); // Додає число до списку
                    }
                    else
                    {
                        // Обробляє помилку, щоб уникнути завершення програми
                        Console.WriteLine($"Could not convert '{part}' to a number.");
                        return new List<int>(); // Повертає порожній список у разі помилки
                    }
                }
                return grades; // Повертає список чисел
            }

            return new List<int>(); // Повертає порожній список, якщо значення не є рядком
        }
    }
}