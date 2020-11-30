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
        public Student LoggedInStudent
        {
            get { return _loggedInStudent; }
            set
            {
                _loggedInStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LoggedInStudent"));
            }
        }

        private decimal _studentDeposit;
        public decimal StudentDeposit
        {
            get
            {
                return _studentDeposit;
            }
            set
            {
                _studentDeposit = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentDeposit"));
                StudentDue -= StudentDeposit;
            }
        }

        private decimal _studentDue;
        public decimal StudentDue
        {
            get
            {
                //return LoggedInStudent.Fees - studentDeposit;
                return _studentDue;
            }
            set
            {
                _studentDue = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentDue"));
            }
        }

        private ObservableCollection<Payment> _payments;
        public ObservableCollection<Payment> Payments
        {
            get { return _payments; }
            set
            {
                _payments = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Payments"));
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

        #endregion

        #endregion

        public StudentView(User _student)
        {
            InitializeComponent();
            LoggedInStudent = (Student)_student;
            StudentDue = LoggedInStudent.Fees;
            GetPayments();
            GetAllCourses();
        }

        #region Get Lists

        private void GetAllCourses()
        {
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCourses(LoggedInStudent));
        }

        private void GetPayments()
        {
            Payments = new ObservableCollection<Payment>(LoggedInStudent.Payments);

            decimal deposit = 0;
            List<Payment> fees = LoggedInStudent.Payments.ToList();
            for (int i = 0; i < fees.Count; i++)
            {
                deposit += LoggedInStudent.Payments.ElementAt(i).Amount;
            }
            StudentDeposit = deposit;
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
        private void addPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            new AddPaymentView(LoggedInStudent).ShowDialog();
            GetPayments();
        }
        #endregion

        #region Key Down
        //private void viewTeachersDataGrid_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.D)
        //    {
        //        VirtualCollegeContext.RemoveUser((Teacher)viewTeachersDataGrid.SelectedItem);
        //        Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
        //    }
        //}

        private void viewStudentsDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                VirtualCollegeContext.RemoveUser(SelectedStudent);
                Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudents());
            }
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

    }
}
