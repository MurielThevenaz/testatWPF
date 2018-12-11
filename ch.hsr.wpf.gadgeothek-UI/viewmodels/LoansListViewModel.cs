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
    public class LoansListViewModel: INotifyPropertyChanged
    {
        public AppService AppService;

        private ObservableCollection<Loan> _allLoans = new ObservableCollection<Loan>();
        public ObservableCollection<Loan> AllLoans
        {
            get { return _allLoans; }
            set
            {
                _allLoans = value;
                OnPropertyChanged(nameof(AllLoans));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddNewLoanCommand { get; set; }
        public RelayCommand ChangeLoanCommand { get; set; }
        public RelayCommand EndLoanCommand { get; set; }

        public LoansListViewModel()
        {
        }


        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
