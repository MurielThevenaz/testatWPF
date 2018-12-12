using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek_UI.services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek_UI.viewmodels
{
    public class LoansListViewModel: BindableBase
    {
        public AppViewModel AppViewModel;

        private ObservableCollection<Loan> _allLoans = new ObservableCollection<Loan>();
        public ObservableCollection<Loan> AllLoans
        {
            get { return _allLoans; }
            set
            {
                SetProperty(ref _allLoans, value, nameof(AllLoans));
            }
        }

        public RelayCommand AddNewLoanCommand { get; set; }
        public RelayCommand ChangeLoanCommand { get; set; }
        public RelayCommand EndLoanCommand { get; set; }

        public LoansListViewModel()
        {
        }

        public void PullAllLoans()
        {
            AllLoans.Clear();
            foreach (var loan in AppViewModel.GetAllLoans())
            {
                AllLoans.Add(loan);
            }
        }
    }
}
