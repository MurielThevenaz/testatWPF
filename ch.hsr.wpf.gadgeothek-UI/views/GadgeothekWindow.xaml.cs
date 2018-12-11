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
    /// Interaction logic for GadgeothekWindow.xaml
    /// </summary>
    public partial class GadgeothekWindow : Window
    {
        public AppViewModel AppViewModel { get; set; }

        public GadgeothekWindow()
        {
            InitializeComponent();
            AppViewModel = new AppViewModel();
            DataContext = AppViewModel;

            GadgetsListView.GadgetsListViewModel.AppViewModel = AppViewModel;
            GadgetsListView.GadgetsListViewModel.PullAllGadgets();

            LoansListView.LoansListViewModel.AppViewModel = AppViewModel;
            LoansListView.LoansListViewModel.PullAllLoans();

            ClientsListView.ClientsListViewModel.AppViewModel = AppViewModel;
            ClientsListView.ClientsListViewModel.PullAllClients();
        }
    }
}
