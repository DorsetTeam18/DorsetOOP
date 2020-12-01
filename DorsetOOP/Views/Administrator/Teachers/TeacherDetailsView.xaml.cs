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
    /// Interaction logic for TeacherDetailsView.xaml
    /// </summary>
    public partial class TeacherDetailsView : Window, INotifyPropertyChanged
    {

        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

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

        private Lesson _selectedLesson;
        public Lesson SelectedLesson
        {
            get { return _selectedLesson; }
            set
            {
                _selectedLesson = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedLesson"));
            }
        }
        #endregion

        public TeacherDetailsView(Teacher _inputTeacher)
        {
            InitializeComponent();
            SelectedTeacher = _inputTeacher;
        }

        private void editTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            new EditTeacherView(SelectedTeacher).ShowDialog();
            this.Close();
        }

        private void deleteTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("Are you sure to delete this teacher?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (msg == MessageBoxResult.Yes)
            {
                VirtualCollegeContext.RemoveUser(SelectedTeacher);
                this.Close();
            }
        }
    }
}