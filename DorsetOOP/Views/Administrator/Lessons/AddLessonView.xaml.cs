using DorsetOOP.Models;
using DorsetOOP.Models.Users;
using DorsetOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DorsetOOP
{
    /// <summary>
    /// Logique d'interaction pour AddLessonView.xaml
    /// </summary>
    public partial class AddLessonView : Window, INotifyPropertyChanged
    {

        public AddLessonView()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudents());
        }
        #region View Models

        public event PropertyChangedEventHandler PropertyChanged;

        private Lesson _lessonToAdd = new Lesson();
        public Lesson LessonToAdd
        {
            get { return _lessonToAdd; }
            set
            {
                _lessonToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LessonToAdd"));
            }
        }

        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Students"));
            }
        }


        #endregion

        private void AddLessonButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

