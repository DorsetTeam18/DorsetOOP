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
    /// Logique d'interaction pour AddLessonView.xaml
    /// </summary>
    public partial class AddLessonView : Window, INotifyPropertyChanged
    {

        public AddLessonView()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudents());
            Courses = new ObservableCollection<Course>(VirtualCollegeContext.GetAllCourses());
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
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

        #endregion

        private void AddLessonButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var row in GetDataGridRows(StudentsAbleToAttendDataGrid).ToList())
            {
                Student currentStudent = (Student)row.Item;
                CheckBox cb = (CheckBox)StudentsAbleToAttendDataGrid.Columns.ToList()[0].GetCellContent(row);
                if (cb.IsChecked == true)
                {
                    LessonToAdd.Students.Add(currentStudent);
                }
            }

            if (VirtualCollegeContext.CreateLesson(LessonToAdd))
            {
                MessageBox.Show("Lesson created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else MessageBox.Show("Couldn't create lesson. Check if it doesn't already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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


    }
}

