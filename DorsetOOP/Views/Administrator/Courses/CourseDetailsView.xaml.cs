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
    /// Interaction logic for CourseDetailsView.xaml
    /// </summary>
    public partial class CourseDetailsView : Window, INotifyPropertyChanged
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged;

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCourse"));
            }
        }

        private ObservableCollection<Grade> _selectedStudentGradesInCourse = new ObservableCollection<Grade>();
        public ObservableCollection<Grade> SelectedStudentGradesInCourse
        {
            get { return _selectedStudentGradesInCourse; }
            set
            {
                _selectedStudentGradesInCourse = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedStudentGradesInCourse"));
            }
        }

        private ObservableCollection<Lesson> _selectedStudentLessonsInCourse = new ObservableCollection<Lesson>();
        public ObservableCollection<Lesson> SelectedStudentLessonsInCourse
        {
            get { return _selectedStudentLessonsInCourse; }
            set
            {
                _selectedStudentLessonsInCourse = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedStudentLessonsInCourse"));
            }
        }

        private Student _selectedStudent = new Student();
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedStudent"));

                if (SelectedStudent != null)
                {
                    SelectedStudentGradesInCourse = new ObservableCollection<Grade>(
                    SelectedStudent.Grades.
                    ToList().FindAll(
                        g => g.Course.CourseId == SelectedCourse.CourseId));

                    SelectedStudentLessonsInCourse = new ObservableCollection<Lesson>(
                        SelectedStudent.Lessons.
                        ToList().FindAll(
                            l => l.Course.CourseId == SelectedCourse.CourseId));
                }
                
            }
        }
        #endregion
        public CourseDetailsView(Course _inputCourse)
        {
            InitializeComponent();
            SelectedCourse = _inputCourse;
        }
    }
}
