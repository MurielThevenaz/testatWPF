using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek_UI.services;
using ch.hsr.wpf.gadgeothek_UI.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ch.hsr.wpf.gadgeothek_UI.viewmodels
{
    public class GadgetsListViewModel: INotifyPropertyChanged
    {
        public AppViewModel AppViewModel;

        private ObservableCollection<Gadget> _allGadgets = new ObservableCollection<Gadget>();
        public ObservableCollection<Gadget> AllGadgets
        {
            get { return _allGadgets; }
            set
            {
                _allGadgets = value;
                OnPropertyChanged(nameof(AllGadgets));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddNewGadgetCommand { get; set; }
        public RelayCommand ChangeGadgetCommand { get; set; }
        public RelayCommand DeleteGadgetCommand { get; set; }

        public GadgetsListViewModel()
        {
            AddNewGadgetCommand = new RelayCommand(() => this.AddNewGadget());
        }

        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PullAllGadgets()
        {
            AllGadgets.Clear();
            foreach (var gadget in AppViewModel.GetAllGadgets())
            {
                AllGadgets.Add(gadget);
            }
        }

        private void AddNewGadget()
        {
            Gadget gadget = new Gadget();
            EditGadgetWindow EditGadgetWindow = new EditGadgetWindow(gadget);
            if (EditGadgetWindow.ShowDialog() == true)
            {
                if (AppViewModel.Service.AddGadget(gadget))
                {
                    OnPropertyChanged(nameof(AllGadgets));
                    PullAllGadgets();
                }
                else
                {
                    throw new Exception("Add Gadget Failed!");
                }
            }
        }
    }
}
