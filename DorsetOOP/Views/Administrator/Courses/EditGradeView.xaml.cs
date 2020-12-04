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
    /// Interaction logic for EditGradeView.xaml
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
    public partial class EditGradeView : Window, INotifyPropertyChanged
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged;

        private Grade _gradeToEdit;
        public Grade GradeToEdit
        {
            get { return _gradeToEdit; }
            set
            {
                _gradeToEdit = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GradeToEdit"));
            }
        }

        #endregion

        public EditGradeView(Grade _inputGrade)
        {
            InitializeComponent();
            GradeToEdit = _inputGrade;
        }

        private void CloseGradeButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
