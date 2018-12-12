using ch.hsr.wpf.gadgeothek.service;
using ch.hsr.wpf.gadgeothek_UI.services;
using ch.hsr.wpf.gadgeothek_UI.viewmodels;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            String ServerUrl = ConfigurationManager.AppSettings["server"].ToString();
            LibraryAdminService Service = new LibraryAdminService(ServerUrl);
            InitializeComponent();
            AppViewModel AppViewModel = new AppViewModel(Service);
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
