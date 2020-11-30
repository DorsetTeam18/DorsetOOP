﻿using DorsetOOP.Models;
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
    public partial class EditCourseView : Window, INotifyPropertyChanged
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
            }
        }
        #endregion

        public EditCourseView(Course _courseToEdit)
        {
            InitializeComponent();
            CourseToAdd = _courseToEdit;
            Teachers = new ObservableCollection<Teacher>(VirtualCollegeContext.GetAllTeachers());
        }

        private void SetCheckBoxesValues()
        {
            var rows = GetDataGridRows(teachersAbleToTeachDataGrid).ToList();
            foreach (var row in rows)
            {
                Teacher currentTeacher = (Teacher)row.Item;
                CheckBox cb = (CheckBox)teachersAbleToTeachDataGrid.Columns.ToList()[0].GetCellContent(row);
                if (CourseToAdd.Teachers.ToList().FindAll(u=>u.UserId == currentTeacher.UserId).Count!=0)
                {
                    cb.IsChecked = true;
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetCheckBoxesValues();
        }
    }
}