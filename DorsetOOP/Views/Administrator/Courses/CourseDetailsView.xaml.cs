//Team 18
//Student names | ID:
//Wim POIGNON 23408
//Maélis YONES 23217
//Rémi LOMBARD 23210
//Christophe NGUYEN 23219
//Gwendoline MAREK 23397
//Maxime DENNERY 23203
//Victor TACHOIRES 22844

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

        private Grade _selectedGrade = new Grade();      
        public Grade SelectedGrade
        {
            get { return _selectedGrade; }
            set
            {
                _selectedGrade = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedGrade"));
            }
        }

        private Lesson _selectedLesson = new Lesson();
        public Lesson SelectedLesson
        {
            get { return _selectedLesson; }
            set
            {
                _selectedLesson = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedLesson"));
            }
        }

        #endregion

        public CourseDetailsView(Course _inputCourse)
        {
            InitializeComponent();
            SelectedCourse = _inputCourse;
            //SetViews();
        }

        //private void SetViews()
        //{
        //    if (SelectedCourse.Lessons == null) lessonsGrid.Visibility = Visibility.Collapsed;
        //    if (SelectedCourse.AllCourseGrades.Count == 0) gradesGrid.Visibility = Visibility.Collapsed;
        //}

        private void allLessonsOfCourse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new EditLessonView(SelectedLesson).ShowDialog();
            VirtualCollegeContext.UpdateLesson(SelectedLesson);
            // UPDATE 
        }

        private void allGradesOfCourse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new EditGradeView(SelectedGrade).ShowDialog();
            VirtualCollegeContext.UpdateGrade(SelectedGrade);
        }

        private void deleteGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGrade != null)
            {
                VirtualCollegeContext.RemoveGrade(SelectedGrade);
                MessageBox.Show("Grade deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SelectedCourse = SelectedCourse;
            }
            else MessageBox.Show("Please select a grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void addGradeButton_Click(object sender, RoutedEventArgs e)
        {
            new AddGradeView(SelectedCourse).ShowDialog();
            this.Close();
            new CourseDetailsView(SelectedCourse).ShowDialog();
        }

        
        private void allGradesOfCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
