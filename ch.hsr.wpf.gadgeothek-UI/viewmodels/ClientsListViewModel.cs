using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek_UI.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek_UI.viewmodels
{
    public class ClientsListViewModel
    {
        public AppService AppService;
        public ObservableCollection<Customer> AllClients { get; set; } = new ObservableCollection<Customer>();

        public RelayCommand AddNewClientCommand { get; set; }
        public RelayCommand DeleteClientCommand { get; set; }

        public ClientsListViewModel() { }

        public void PullAllClients()
        {
            AllClients.Clear();
            foreach (var client in AppService.GetAllClients())
            {
                AllClients.Add(client);
            }
        }
    }
}
