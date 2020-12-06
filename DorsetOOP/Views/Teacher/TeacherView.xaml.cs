/// Team 18
/// Student names | ID:
/// Wim POIGNON 23408
/// Maélis YONES 23217
/// Rémi LOMBARD 23210
/// Christophe NGUYEN 23219
/// Gwendoline MAREK 23397
/// Maxime DENNERY 23203
/// Victor TACHOIRES 22844

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
    /// <summary>
    /// Logic behind the Teacher Window.
    /// Auto-implemented MVVM is used. Therefore, we inherit from INotifyPropertyChanged. 
    /// The goal is to bind our View to our Models.
    /// When a property corresponding to a model (our ViewModel) is changed, we notify everything using it to change.
    /// </summary>
    public partial class TeacherView : Window, INotifyPropertyChanged 
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged; // Implementation of INotifyPropertyChanged

        private Teacher _loggedInTeacher; // Get the logged in teacher
        public Teacher LoggedInTeacher
        {
            get { return _loggedInTeacher; }
            set
            {
                _loggedInTeacher = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LoggedInTeacher"));
            }
        }

        private ObservableCollection<Student> _students = new ObservableCollection<Student>(); // Collection of students. Will be used for binding and will vary in function of the selected lesson
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Students"));
            }
        }

        private string _searchStudentTextBox; // Corresponds to the output of the search textbox
        public string SearchStudentTextBox
        {
            get { return _searchStudentTextBox; }
            set
            {
                _searchStudentTextBox = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchStudentTextBox"));
                // When the search text changes, we refresh the Students property
                if (SearchStudentTextBox != "" && SearchStudentTextBox != "") Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudentsOfTutorThatMatchFullName(LoggedInTeacher, SearchStudentTextBox));
            }
        }

        private Student _selectedStudent; // Contains the selected student in a datagrid
        public Student SelectedStudent
        {
            get { return _selectedStudent; }

            set
            {
                _selectedStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedStudent"));
            }
        }

        private Course _selectedCourse; // Contains the selected course in a datagrid
        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCourse"));
                if (LoggedInTeacher != null && SelectedCourse != null)
                {
                    TeacherLessons = new ObservableCollection<Lesson>(VirtualCollegeContext.GetLessonsFromCourse(LoggedInTeacher, SelectedCourse));
                    Grades = new ObservableCollection<Grade>(VirtualCollegeContext.GetAllGrades(SelectedCourse));
                    SelectedLesson = null;
                    SelectedStudents = null;
                }
            }
        }

        private ObservableCollection<Lesson> _teacherLessons; // Collection of lessons of the logged in teacher. Used for the datagrid
        public ObservableCollection<Lesson> TeacherLessons
        {
            get { return _teacherLessons; }
            set
            {
                _teacherLessons = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TeacherLessons"));
            }
        }

        private Lesson _selectedLesson; // The selected lesson
        public Lesson SelectedLesson
        {
            get { return _selectedLesson; }
            set
            {
                _selectedLesson = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedLesson"));
                if (SelectedLesson != null) SelectedStudents = new ObservableCollection<Student>(SelectedLesson.Students);
            }
        }

        private ObservableCollection<Student> _selectedStudents; // Used to handle the checkboxes values for the presence
        public ObservableCollection<Student> SelectedStudents
        {
            get { return _selectedStudents; }
            set
            {
                _selectedStudents = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedStudents"));
                if (SelectedLesson != null && SelectedStudents != null) SetCheckBoxesValues();
            }
        }

        private Grade _selectedGrade = new Grade(); // Selected grade
        public Grade SelectedGrade
        {
            get { return _selectedGrade; }
            set
            {
                _selectedGrade = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedGrade"));
            }
        }

        private ObservableCollection<Grade> _grades; // All grades
        public ObservableCollection<Grade> Grades
        {
            get { return _grades; }
            set
            {
                _grades = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Grades"));
            }
        }
        #endregion

        public TeacherView(User _inputUser)
        {
            InitializeComponent();
            LoggedInTeacher = (Teacher)_inputUser; // Cast and set the input user
            Students = new ObservableCollection<Student>(LoggedInTeacher.Tutoring); // Set the students in function of the logged in teacher

        }

        #region Datagrid (double click & focus lost)
        private void studentsInLessonDataGrid_LostFocus(object sender, RoutedEventArgs e) // When focus is lost, update the presence of the studens according to the checkboxes
        {
            foreach (var row in GetDataGridRows(studentsInLessonDataGrid).ToList())
            {
                Student currentStudent = (Student)row.Item; 
                CheckBox cb = (CheckBox)studentsInLessonDataGrid.Columns.ToList()[1].GetCellContent(row);
                if (cb.IsChecked == true) { VirtualCollegeContext.SetStudentAsPresent(currentStudent, SelectedLesson); }
                else VirtualCollegeContext.SetStudentAsNotPresent(currentStudent, SelectedLesson);
            }
        }

        private void Students_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            new StudentDetailsView(SelectedStudent).ShowDialog(); // Display the selected students details in the apropriate window
        }

        private void allGradesOfCourse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new EditGradeView(SelectedGrade).ShowDialog(); // Display the edit grade window
            VirtualCollegeContext.UpdateGrade(SelectedGrade);
        }
        #endregion

        #region Click Handlers
        private void deleteGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGrade != null)
            {
                VirtualCollegeContext.RemoveGrade(SelectedGrade);
                MessageBox.Show("Grade deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SelectedCourse = SelectedCourse;
                Grades = new ObservableCollection<Grade>(VirtualCollegeContext.GetAllGrades(SelectedCourse));
            }
            else MessageBox.Show("Please select a grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void addGradeButton_Click(object sender, RoutedEventArgs e)
        {
            new AddGradeView(SelectedCourse).ShowDialog();
            Grades = new ObservableCollection<Grade>(VirtualCollegeContext.GetAllGrades(SelectedCourse));
        }
        #endregion

        #region Backend
        private void SetCheckBoxesValues()
        {
            studentsInLessonDataGrid.UpdateLayout();
            var rows = GetDataGridRows(studentsInLessonDataGrid).ToList();
            foreach (var row in rows)
            {
                Student currentStudent = (Student)row.Item;
                CheckBox cb = (CheckBox)studentsInLessonDataGrid.Columns.ToList()[1].GetCellContent(row);
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
        #endregion
    }
}
