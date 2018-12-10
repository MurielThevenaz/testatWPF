﻿using ch.hsr.wpf.gadgeothek_UI.viewmodels;
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
    /// Interaction logic for ClientsListView.xaml
    /// </summary>
    public partial class ClientsListView : UserControl
    {
        public ClientsListViewModel ClientsListViewModel;

        public ClientsListView()
        {
            InitializeComponent();
            ClientsListViewModel = new ClientsListViewModel();
            DataContext = ClientsListViewModel;
        }
    }
}
