using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek_UI.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek_UI.viewmodels
{
    public class ClientsListViewModel: INotifyPropertyChanged
    {
        public AppViewModel AppViewModel;

        private ObservableCollection<Customer> _allClients = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> AllClients
        {
            get { return _allClients; }
            set
            {
                _allClients = value;
                OnPropertyChanged(nameof(AllClients));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddNewClientCommand { get; set; }
        public RelayCommand ChangeClientCommand { get; set; }
        public RelayCommand DeleteClientCommand { get; set; }

        public ClientsListViewModel() { }

        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PullAllClients()
        {
            AllClients.Clear();
            foreach (var client in AppViewModel.GetAllClients())
            {
                AllClients.Add(client);
            }
        }
    }
}
