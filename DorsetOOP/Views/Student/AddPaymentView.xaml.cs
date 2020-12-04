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
    /// Interaction logic for AddPaymentView.xaml
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
    public partial class AddPaymentView : Window, INotifyPropertyChanged
    {
        #region View Models
        public event PropertyChangedEventHandler PropertyChanged;

        private Payment _paymentToAdd = new Payment();
        public Payment PaymentToAdd
        {
            get { return _paymentToAdd; }
            set
            {
                _paymentToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PaymentToAdd"));
            }
        }
        #endregion

        private Student StudentConcerned { get; set; }

        public AddPaymentView(Student _stud)
        {
            InitializeComponent();
            StudentConcerned = _stud;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void addPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            var p = PaymentToAdd;
            p.Date = DateTime.Now;
            p.Student = StudentConcerned;
            PaymentToAdd = p;

            if (VirtualCollegeContext.AddPayment(PaymentToAdd)) // To edit
            {
                MessageBox.Show("Payment added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Too much!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
