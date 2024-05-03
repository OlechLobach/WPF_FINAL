using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using WPF_FINAL.Commands;
using WPF_FINAL.Models;

namespace WPF_FINAL.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public Student? SelectedStudent { get; set; } // Вибраний студент

        public ICommand AddStudentCommand { get; set; }
        public ICommand SaveStudentsCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }

        public MainViewModel()
        {
            // Команди
            AddStudentCommand = new RelayCommand(p => AddStudent(p));
            SaveStudentsCommand = new RelayCommand(p => SaveStudents());
            DeleteStudentCommand = new RelayCommand(p => DeleteStudent(p));

            LoadStudentsFromFile(); // Завантаження даних із файлу при ініціалізації
        }

        // Додати нового студента
        private void AddStudent(object? parameter)
        {
            var newStudent = new Student { Name = "Новий Учень", Age = 0, Grade = 0 };
            Students.Add(newStudent);
            SelectedStudent = newStudent;
            OnPropertyChanged(nameof(SelectedStudent)); // Повідомити про зміну
        }

        // Видалити вибраного студента
        private void DeleteStudent(object? parameter)
        {
            if (SelectedStudent != null)
            {
                Students.Remove(SelectedStudent);
                SelectedStudent = null;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        // Збереження студентів у файл
        private void SaveStudents()
        {
            try
            {
                var json = JsonSerializer.Serialize(Students);
                File.WriteAllText("students.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні студентів: {ex.Message}");
            }
        }

        // Завантаження студентів із файлу
        private void LoadStudentsFromFile()
        {
            try
            {
                if (File.Exists("students.json"))
                {
                    var json = File.ReadAllText("students.json");
                    var loadedStudents = JsonSerializer.Deserialize<ObservableCollection<Student>>(json);

                    if (loadedStudents != null)
                    {
                        Students.Clear(); // Очистити існуючий список
                        foreach (var student in loadedStudents)
                        {
                            Students.Add(student); // Додати завантажених студентів
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні студентів: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}