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
    /// Interaction logic for AddGradeView.xaml
    /// </summary>
    public partial class AddGradeView : Window, INotifyPropertyChanged
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged;

        private Grade _gradeToAdd = new Grade();
        public Grade GradeToAdd
        {
            get { return _gradeToAdd; }
            set
            {
                _gradeToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GradeToAdd"));
            }
        }

        private Student _studentToAdd = new Student();
        public Student StudentToAdd
        {
            get { return _studentToAdd; }
            set
            {
                _studentToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentToAdd"));
            }
        }

        public Course _courseForGrade;
        public Course CourseForGrade
        {
            get { return _courseForGrade; }
            set
            {
                _courseForGrade = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CourseForGrade"));
            }
        }
        #endregion

        public AddGradeView(Course _inputCourse)
        {
            InitializeComponent();
            CourseForGrade = _inputCourse;
            GradeToAdd.Course = CourseForGrade;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (VirtualCollegeContext.AddGrade(GradeToAdd, StudentToAdd))
            {
                MessageBox.Show("Grade added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else MessageBox.Show("Couldn't add grade!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
