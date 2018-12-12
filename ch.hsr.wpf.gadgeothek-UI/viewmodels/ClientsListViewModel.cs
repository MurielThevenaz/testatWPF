using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek_UI.helpers;
using ch.hsr.wpf.gadgeothek_UI.services;
using ch.hsr.wpf.gadgeothek_UI.views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ch.hsr.wpf.gadgeothek_UI.viewmodels
{
    public class ClientsListViewModel: BindableBase
    {
        public AppViewModel AppViewModel;

        private ObservableCollection<Customer> _allClients = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> AllClients
        {
            get { return _allClients; }
            set
            {
                SetProperty(ref _allClients, value, nameof(AllClients));
            }
        }

        public RelayCommand AddNewClientCommand { get; set; }
        public RelayCommandWithParameter<Customer> ChangeClientCommand { get; set; }
        public RelayCommandWithParameter<Customer> DeleteClientCommand { get; set; }

        public ClientsListViewModel() {
            AddNewClientCommand = new RelayCommand(() => this.AddNewClient());
            ChangeClientCommand = new RelayCommandWithParameter<Customer>((customer) => this.ChangeClient(customer));
            DeleteClientCommand = new RelayCommandWithParameter<Customer>((customer) => this.DeleteClient(customer));
        }

        public void PullAllClients()
        {
            AllClients.Clear();
            foreach (var client in AppViewModel.GetAllClients())
            {
                AllClients.Add(client);
            }
        }

        private void AddNewClient()
        {
            Customer client = new Customer();
            EditClientWindow EditClientWindow = new EditClientWindow(client);
            if (EditClientWindow.ShowDialog() == true)
            {
                if (AppViewModel.AddClient(client))
                {
                    PullAllClients();
                }
                else
                {
                    throw new Exception("Add Client Failed!");
                }
            }
        }

        private void ChangeClient(Customer client)
        {
            if (client == null)
            {
                MessageBox.Show("Wählen Sie bitte einen Kunden in der Liste aus");
                return;
            }
            Customer editableClient = new Customer
            {
                Name = client.Name,
                Password = client.Password,
                Email = client.Email,
                Studentnumber = client.Studentnumber
            };

            EditClientWindow EditClientWindow = new EditClientWindow(editableClient);
            if (EditClientWindow.ShowDialog() == true)
            {
                client.Name = editableClient.Name;
                client.Password = editableClient.Password;
                client.Email = editableClient.Email;
                client.Studentnumber = editableClient.Studentnumber;

                if (AppViewModel.UpdateClient(client))
                {
                    PullAllClients();
                }
                else
                {
                    throw new Exception("Update Client Failed!");
                }
            }
        }

        private void DeleteClient(Customer client)
        {
            if (client == null)
            {
                MessageBox.Show("Wählen Sie bitte einen Kunden in der Liste aus");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diesen Kunden löschen möchten?", "", MessageBoxButton.YesNo);

            if (result.Equals(MessageBoxResult.Yes))
            {
                if (AppViewModel.DeleteClient(client))
                {
                    PullAllClients();
                }
                else
                {
                    throw new Exception("Delete Client Failed!");
                }
            }
        }
    }
}
