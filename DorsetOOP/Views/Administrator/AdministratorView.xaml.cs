//Team 18
//Student names |ID:
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
using System.Collections;
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

        #region LESSONS
        private ObservableCollection<Lesson> _lessons;
        public ObservableCollection<Lesson> Lessons
        {
            get { return _lessons; }
            set
            {
                _lessons = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Lessons"));
            }
        }

        private string _searchLessonsText;
        public string SearchLessonsText
        {
            get { return _searchLessonsText; }
            set
            {
                if (value == "e")
                {

                }
                _searchLessonsText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchLessonsText"));
                GetLessonsThatMatch(SearchLessonsText);
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
                if(SelectedLesson != null) StudentsInSelectedLesson = new ObservableCollection<Student>(SelectedLesson.Students);
            }
        }

        public ObservableCollection<Student> _studentsInSelectedLesson;
        public ObservableCollection<Student> StudentsInSelectedLesson
        {
            get { return _studentsInSelectedLesson; }
            set
            {
                _studentsInSelectedLesson = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentsInSelectedLesson"));
                if (StudentsInSelectedLesson != null) SetCheckBoxesValues();
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
            GetAllLessons();
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

        private void GetAllLessons()
        {
            Lessons = new ObservableCollection<Lesson>(VirtualCollegeContext.GetAllLessons());

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

        private void GetLessonsThatMatch(string _searchBoxValue)
        {
            Lessons = new ObservableCollection<Lesson>(VirtualCollegeContext.GetAllLessonsThatMatchTitle(_searchBoxValue));
        }
        #endregion

        #region Creating a new entity
        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            new AddStudentView().ShowDialog();
            GetAllUsers();
        }

        private void addTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            new AddTeacherView().ShowDialog();
            GetAllUsers();
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
            GetAllUsers();
        }

        private void Students_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            new StudentDetailsView(SelectedStudent).ShowDialog();
            GetAllUsers();
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
            if (SelectedCourse == null) MessageBox.Show("Please select a course!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                VirtualCollegeContext.RemoveCourse(SelectedCourse);
                GetAllLessons(); GetAllCourses();
            }
        }

        private void editCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCourse != null)
            {
                new EditCourseView(SelectedCourse).ShowDialog();
                Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCourses());
            }
            else MessageBox.Show("Please select a course", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }

        private void moreDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCourse != null)
            {
                new CourseDetailsView(SelectedCourse).ShowDialog();
                GetAllCourses();
                GetAllUsers();
                GetAllLessons();
            }
            else MessageBox.Show("Please select a course", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void addLessonButton_Click(object sender, RoutedEventArgs e)
        {
            new AddLessonView().ShowDialog();
            GetAllLessons();
            GetAllUsers();
            GetAllCourses();
            
        }

        private void editLessonButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLesson != null)
            {
                new EditLessonView(SelectedLesson).ShowDialog();
                VirtualCollegeContext.UpdateLesson(SelectedLesson);
                GetAllLessons();
                GetAllUsers();
                GetAllCourses();
                
            }
            else MessageBox.Show("Please select a lesson", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void deleteLessonButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLesson == null) MessageBox.Show("Please select a course!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                VirtualCollegeContext.RemoveLesson(SelectedLesson);
                Lessons = new ObservableCollection<Lesson>(VirtualCollegeContext.GetAllLessons());
                
                GetAllUsers();
                GetAllCourses();
            }
        }

        private void SetCheckBoxesValues()
        {
            studentsInSelectedLessonDataGrid.UpdateLayout();
            var rows = GetDataGridRows(studentsInSelectedLessonDataGrid).ToList();
            foreach (var row in rows)
            {
                Student currentStudent = (Student)row.Item;
                CheckBox cb = (CheckBox)studentsInSelectedLessonDataGrid.Columns.ToList()[1].GetCellContent(row);
                if (VirtualCollegeContext.StudentIsPresent(currentStudent, SelectedLesson)) cb.IsChecked = true;
            }
        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void studentsInSelectedLessonDataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach (var row in GetDataGridRows(studentsInSelectedLessonDataGrid).ToList())
            {
                Student currentStudent = (Student)row.Item;
                CheckBox cb = (CheckBox)studentsInSelectedLessonDataGrid.Columns.ToList()[1].GetCellContent(row);
                if (cb.IsChecked == true) { VirtualCollegeContext.SetStudentAsPresent(currentStudent, SelectedLesson); }
                else VirtualCollegeContext.SetStudentAsNotPresent(currentStudent, SelectedLesson);
            }
        }
    }
}
