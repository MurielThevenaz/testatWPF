using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek_UI.helpers;
using ch.hsr.wpf.gadgeothek_UI.services;
using ch.hsr.wpf.gadgeothek_UI.views;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ch.hsr.wpf.gadgeothek_UI.viewmodels
{
    public class GadgetsListViewModel: BindableBase
    {
        public AppViewModel AppViewModel;

        private ObservableCollection<Gadget> _allGadgets = new ObservableCollection<Gadget>();
        public ObservableCollection<Gadget> AllGadgets
        {
            get { return _allGadgets; }
            set
            {
                SetProperty(ref _allGadgets, value, nameof(AllGadgets));
            }
        }

        public RelayCommand AddNewGadgetCommand { get; set; }
        public RelayCommandWithParameter<Gadget> ChangeGadgetCommand { get; set; }
        public RelayCommandWithParameter<Gadget> DeleteGadgetCommand { get; set; }

        public GadgetsListViewModel()
        {
            AddNewGadgetCommand = new RelayCommand(() => this.AddNewGadget());
            ChangeGadgetCommand = new RelayCommandWithParameter<Gadget>((gadget) => this.ChangeGadget(gadget));
            DeleteGadgetCommand = new RelayCommandWithParameter<Gadget>((gadget) => this.DeleteGadget(gadget));
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
                if (AppViewModel.AddGadget(gadget))
                {
                    PullAllGadgets();
                }
                else
                {
                    throw new Exception("Add Gadget Failed!");
                }
            }
        }

        private void ChangeGadget(Gadget gadget)
        {
            if (gadget == null)
            {
                MessageBox.Show("Wählen Sie bitte ein Gadget in der Liste aus");
                return;
            }
            Gadget editableGadget = new Gadget
            {
                InventoryNumber = gadget.InventoryNumber,
                Name = gadget.Name,
                Price = gadget.Price,
                Condition = gadget.Condition,
                Manufacturer = gadget.Manufacturer
            };

            EditGadgetWindow EditGadgetWindow = new EditGadgetWindow(editableGadget);
            if (EditGadgetWindow.ShowDialog() == true)
            {
                gadget.InventoryNumber = editableGadget.InventoryNumber;
                gadget.Name = editableGadget.Name;
                gadget.Price = editableGadget.Price;
                gadget.Condition = editableGadget.Condition;
                gadget.Manufacturer = editableGadget.Manufacturer;

                if (AppViewModel.UpdateGadget(gadget))
                {
                    PullAllGadgets();
                }
                else
                {
                    throw new Exception("Update Gadget Failed!");
                }
            }
        }

        private void DeleteGadget(Gadget gadget)
        {
            if (gadget == null)
            {
                MessageBox.Show("Wählen Sie bitte ein Gadget in der Liste aus");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie dieses Gadget löschen möchten?", "", MessageBoxButton.YesNo);

            if (result.Equals(MessageBoxResult.Yes))
            {
                if (AppViewModel.DeleteGadget(gadget))
                {
                    PullAllGadgets();
                }
                else
                {
                    throw new Exception("Delete Gadget Failed!");
                }
            }
        }
    }
}
