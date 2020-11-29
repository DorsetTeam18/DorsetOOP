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
    /// Interaction logic for AddCourseView.xaml
    /// </summary>
    public partial class AddCourseView : Window, INotifyPropertyChanged
    {
        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

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

        private Course _courseToAdd = new Course();
        public Course CourseToAdd
        {
            get { return _courseToAdd; }
            set
            {
                _courseToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CourseToAdd"));
                if (CourseToAdd.Title == "Espaces Vectoriels") { }
            }
        }
        #endregion

        public AddCourseView()
        {
            InitializeComponent();
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var row in GetDataGridRows(teachersAbleToTeachDataGrid).ToList())
            {
                Teacher currentTeacher = (Teacher)row.Item;
                CheckBox cb = (CheckBox)teachersAbleToTeachDataGrid.Columns.ToList()[0].GetCellContent(row);
                if (cb.IsChecked==true)
                {
                    CourseToAdd.Teachers.Add(currentTeacher);
                }
            }

            if (VirtualCollegeContext.CreateCourse(CourseToAdd))
            {
                MessageBox.Show("Course created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else MessageBox.Show("Couldn't create course. Check if it doesn't already exsit!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
