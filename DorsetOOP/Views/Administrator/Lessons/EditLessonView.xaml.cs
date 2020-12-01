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
    /// Interaction logic for EditLessonView.xaml
    /// </summary>
    public partial class EditLessonView : Window, INotifyPropertyChanged
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged;

        private Lesson _lessonToEdit;
        public Lesson LessonToEdit
        {
            get { return _lessonToEdit; }
            set
            {
                _lessonToEdit = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LessonToEdit"));
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

        public EditLessonView(Lesson _inputLesson)
        {
            InitializeComponent();
            LessonToEdit = _inputLesson;
            Students = new ObservableCollection<Student>(VirtualCollegeContext.GetAllStudents());

        }

        private void CloseLessonButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

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

        private void SetCheckBoxesValues()
        {
            var rows = GetDataGridRows(StudentsAbleToAttendDataGrid).ToList();
            foreach (var row in rows)
            {
                Student currentStudent = (Student)row.Item;
                CheckBox cb = (CheckBox)StudentsAbleToAttendDataGrid.Columns.ToList()[0].GetCellContent(row);
                if (LessonToEdit.Students.ToList().FindAll(u => u.UserId == currentStudent.UserId).Count != 0)
                {
                    cb.IsChecked = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetCheckBoxesValues();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            LessonToEdit.Students = new ObservableCollection<Student>();
            foreach (var row in GetDataGridRows(StudentsAbleToAttendDataGrid).ToList())
            {
                Student currentStudent = (Student)row.Item;
                CheckBox cb = (CheckBox)StudentsAbleToAttendDataGrid.Columns.ToList()[0].GetCellContent(row);
                if (cb.IsChecked == true)
                {
                    LessonToEdit.Students.Add(currentStudent);
                }
            }

            if (VirtualCollegeContext.UpdateLesson(LessonToEdit))
            {
                MessageBox.Show("Lesson updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else MessageBox.Show("Couldn't update lesson. Check if it doesn't already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
