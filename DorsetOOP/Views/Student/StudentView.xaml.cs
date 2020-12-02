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
    /// Interaction logic for AdministratorView.xaml
    /// </summary>
    public partial class StudentView : Window, INotifyPropertyChanged
    {

        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        Student _loggedInStudent = new Student();
        public Student LoggedInStudent // The logged in student
        {
            get { return _loggedInStudent; }
            set
            {
                _loggedInStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LoggedInStudent"));
            }
        }

        #region TEACHERS
        private ObservableCollection<Teacher> _teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set
            {
                _teachers = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Teachers"));
            }
        }

        private Teacher _selectedTeacher = new Teacher();
        public Teacher SelectedTeacher
        {
            get { return _selectedTeacher; }
            set
            {
                _selectedTeacher = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedTeacher"));
            }
        }

        private string _searchTeachersText;
        public string SearchTeachersText
        {
            get { return _searchTeachersText; }
            set
            {
                _searchTeachersText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchTeachersText"));
                GetTeachersThatMatch(SearchTeachersText);
            }
        }
        #endregion

        #region COURSES
        private ObservableCollection<Course> _courses;
        public ObservableCollection<Course> Courses // Courses of a student
        {
            get { return _courses; }
            set
            {
                _courses = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Courses"));
            }
        }

        private Course _selectedCourse = new Course();
        public Course SelectedCourse // Selected course (used to display grades, lessons etc.)
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;

                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCourse"));
                if(SelectedCourse!=null) GetAllGradesSelectedStudent(); // Gets all of the grades in this course

            }
        }

        private ObservableCollection<Grade> _selectedGrades;
        public ObservableCollection<Grade> SelectedGrades 
        {
            get { return _selectedGrades; }
            set
            {
                _selectedGrades = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedGrades"));
            }
        }
        #endregion

        #endregion

        public StudentView(User _student)
        {
            InitializeComponent();
            LoggedInStudent = (Student)_student;
            GetAllCoursesOfStudent();
        }

        #region Get Lists
        private void GetAllCoursesOfStudent()
        {
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCourses(LoggedInStudent));
        }

        private void GetAllGradesSelectedStudent() // Sets the grades to display to the grades of this student in this course
        {
            SelectedGrades = new ObservableCollection<Grade>(VirtualCollegeContext.GetAllGradesFromStudent(SelectedCourse, LoggedInStudent));
        }
        #endregion

        #region Matching Search Boxes
        private void GetStudentsThatMatch(string _searchBoxValue) // Needs optimization
        {
            LoggedInStudent = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudentsThatMatchFullName(_searchBoxValue))[0];
        }

        private void GetTeachersThatMatch(string _searchBoxValue) // Not implemented yet
        {
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachersThatMatchFullName(_searchBoxValue));
        }

        private void GetCoursesThatMatch(string _searchBoxValue) // Not implemented yet
        {
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCoursesThatMatchTitle(_searchBoxValue));
        }
        #endregion

        #region Creating a new entity
        private void addPaymentButton_Click(object sender, RoutedEventArgs e) // Function to handle a new payment (need to add error handling)
        {
            new AddPaymentView(LoggedInStudent).ShowDialog();
            GetStudentsThatMatch(LoggedInStudent.FullName); // To fix
        }
        #endregion
    }
}
