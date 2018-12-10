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
    public class LoansListViewModel
    {
        public AppService AppService;
        public ObservableCollection<Loan> AllLoans { get; set; } = new ObservableCollection<Loan>();

        public RelayCommand AddNewLoanCommand { get; set; }
        public RelayCommand EndLoanCommand { get; set; }

        public LoansListViewModel()
        {
        }

        public void PullAllLoans()
        {
            AllLoans.Clear();
            foreach (var loan in AppService.GetAllLoans())
            {
                AllLoans.Add(loan);
            }
        }
    }
}
