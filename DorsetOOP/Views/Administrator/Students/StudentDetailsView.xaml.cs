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
    /// Interaction logic for StudentDetailsView.xaml
	/// Team 18
    /// Name of the Students :
    /// Wim POIGNON 23408
    /// Maélis YONES 23217
    /// Rémi LOMBARD 23210
    /// Christophe NGUYEN 23219
    /// Gwendoline MAREK 23397
    /// Maxime DENNERY 23203
    /// Victor TACHOIRES 22844
    /// </summary>
    public partial class StudentDetailsView : Window, INotifyPropertyChanged
    {
        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        private Student _selectedStudent = new Student ();
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedStudent"));
            }
        }
        #endregion
        public StudentDetailsView(Student _inputStudent)
        {
            InitializeComponent();
            SelectedStudent = _inputStudent;
        }

        private void editStudentButton_Click(object sender, RoutedEventArgs e)
        {
            new EditStudentView(SelectedStudent).ShowDialog();
            this.Close();
        }

        private void deleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("Are you sure to delete this student?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (msg == MessageBoxResult.Yes)
            {
                VirtualCollegeContext.RemoveUser(SelectedStudent);
                this.Close();
            }
        }
    }
}
