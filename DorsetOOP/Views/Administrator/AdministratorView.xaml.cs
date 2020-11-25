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
        public Student SelectedStudent
        { 
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedStudent"));
            }
        }

        private Student _dataStudent = new Student();
        public Student DataStudent
        {
            get { return _dataStudent; }
            set
            {
                _dataStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DataStudent"));
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

        public AdministratorView(User _admin)               
        {
            InitializeComponent();
            LoggedInAdmin = (Administrator)_admin;
            GetAllStudents();
        }

        private void GetAllStudents()
        {
            Students = new ObservableCollection<Student>(VirtualCollegeContext.GetStudents());
        }

        private void GetStudentsThatMatch(string t)
        {
            var tempStuds = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                var a = myDB.Addresses.ToList();
                tempStuds = myDB.Users.OfType<Student>().ToList().FindAll(s => s.FullName.ToLower().Contains(t.ToLower()));
            }
            Students = new ObservableCollection<Student>(tempStuds);
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            new AddStudentView().ShowDialog();
            GetAllStudents();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            new StudentDetailsView(DataStudent).ShowDialog();
            Console.WriteLine();
        }

        private void viewStudentsDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                var a = Students.ToList();
                a.Remove((Student)viewStudentsDataGrid.SelectedItem);
                Students = new ObservableCollection<Student>(a);
                //var t = Students.ToList().Remove((Student)viewStudentsDataGrid.SelectedItem);
            }
        }
    }
}
