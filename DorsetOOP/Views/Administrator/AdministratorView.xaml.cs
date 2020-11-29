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
    public partial class AdministratorView : Window, INotifyPropertyChanged
    {
        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        Administrator _loggedInAdmin = new Administrator();
        public Administrator LoggedInAdmin
        {
            get { return _loggedInAdmin; }
            set
            {
                _loggedInAdmin = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LoggedInAdmin"));
            }
        }


        #region STUDENTS
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

        private Student _selectedStudent = new Student();
        public Student SelectedStudent // 
        { 
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DataStudent"));
            }
        }

        private string _searchStudentsText;
        public string SearchStudentsText
        {
            get { return _searchStudentsText; }
            set
            {
                _searchStudentsText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchStudentsText"));
                GetStudentsThatMatch(SearchStudentsText);
            }
        }
        #endregion

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
        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Courses"));
            }
        }

        private Course _selectedCourse = new Course();
        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;

                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCourse"));
            }
        }

        private string _searchCoursesText;
        public string SearchCoursesText
        {
            get { return _searchCoursesText; }
            set
            {
                _searchCoursesText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchCoursesText"));
                GetCoursesThatMatch(SearchCoursesText);
            }
        }
        #endregion

        #endregion

        public AdministratorView(User _admin)               
        {
            InitializeComponent();
            LoggedInAdmin = (Administrator)_admin;
            GetAllUsers();
            GetAllCourses();
        }

        #region Get Lists
        private void GetAllUsers()
        {
            Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudents());
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
        }

        private void GetAllCourses()
        {
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCourses());
        }
        #endregion

        #region Matching Search Boxes
        private void GetStudentsThatMatch(string _searchBoxValue)
        {
            Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudentsThatMatchFullName(_searchBoxValue));
        }

        private void GetTeachersThatMatch(string _searchBoxValue)
        {
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachersThatMatchFullName(_searchBoxValue));
        }

        private void GetCoursesThatMatch(string _searchBoxValue)
        {
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCoursesThatMatchTitle(_searchBoxValue));
        }
        #endregion

        #region Creating a new entity
        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            new AddStudentView().ShowDialog();
            Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudents());
        }

        private void addCourseButton_Click(object sender, RoutedEventArgs e)
        {
            new AddCourseView().ShowDialog();
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCourses());
        }
        #endregion

        #region Double Clicking
        private void Teachers_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            new TeacherDetailsView(SelectedTeacher).ShowDialog();
        }

        private void Students_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            new StudentDetailsView(SelectedStudent).ShowDialog();
        }
        #endregion

        #region Key Down
        private void viewTeachersDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                VirtualCollegeContext.RemoveUser((Teacher)viewTeachersDataGrid.SelectedItem);
                Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
            }
        }

        private void viewStudentsDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                VirtualCollegeContext.RemoveUser(SelectedStudent);
                Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudents());
            }
        }
        #endregion

        private void deleteCourseButton_Click(object sender, RoutedEventArgs e)
        {
            VirtualCollegeContext.RemoveCourse(SelectedCourse);
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCourses());
        }

        private void editCourseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modification à faire");
        }

        
    }
}
