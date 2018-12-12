using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek_UI.viewmodels;
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
    /// Interaction logic for EditGadgetWindow.xaml
    /// </summary>
    public partial class EditGadgetWindow : Window
    {
        public EditGadgetWindow(Gadget gadget)
        {
            InitializeComponent();
            DataContext = gadget;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (ID.Text == string.Empty || Name.Text == string.Empty || Manufacturer.Text == string.Empty)
            {
                MessageBox.Show("Füllen Sie bitte alle Felder");
                return;
            }
            DialogResult = true;
        }
    }
}
