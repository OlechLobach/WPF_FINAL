using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPF_FINAL.Models
{
    public class Student : INotifyPropertyChanged
    {
        private string name;
        private int age;
        private int grade;
        private ObservableCollection<int> grades; // Збірник оцінок

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public int Grade
        {
            get => grade;
            set
            {
                grade = value;
                OnPropertyChanged(nameof(Grade));
            }
        }

        public ObservableCollection<int> Grades // Властивість для оцінок
        {
            get => grades ??= new ObservableCollection<int>();
            set
            {
                grades = value;
                OnPropertyChanged(nameof(Grades));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}