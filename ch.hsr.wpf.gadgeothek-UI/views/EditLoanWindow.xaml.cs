using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
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

namespace ch.hsr.wpf.gadgeothek_UI.views
{
    /// <summary>
    /// Interaction logic for EditLoanWindow.xaml
    /// </summary>
    public partial class EditLoanWindow : Window
    {
        public EditLoanWindow(Loan loan)
        {
            InitializeComponent();
            DataContext = loan;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnDate.Text == string.Empty)
            {
                MessageBox.Show("Füllen Sie bitte alle Felder");
                return;
            }
            DialogResult = true;
        }
    }
}
