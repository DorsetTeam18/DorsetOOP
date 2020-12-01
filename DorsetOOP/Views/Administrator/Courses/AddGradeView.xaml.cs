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

        private Grade _gradeToAdd;
        public Grade GradeToAdd
        {
            get { return _gradeToAdd; }
            set
            {
                _gradeToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GradeToAdd"));
            }
        }

        #endregion
        public AddGradeView()
        {
            InitializeComponent();

        }

        
    }
}
