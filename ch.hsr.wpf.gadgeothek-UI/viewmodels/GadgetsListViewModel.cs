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
    public class GadgetsListViewModel
    {
        public AppService AppService;
        public ObservableCollection<Gadget> AllGadgets { get; set; } = new ObservableCollection<Gadget>();

        public RelayCommand AddNewGadgetCommand { get; set; }
        public RelayCommand DeleteGadgetCommand { get; set; }

        public GadgetsListViewModel() { }

        public void PullAllGadgets()
        {
            AllGadgets.Clear();
            foreach (var gadget in AppService.GetAllGadgets())
            {
                AllGadgets.Add(gadget);
            }
        }
    }
}
