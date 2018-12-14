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
        public RelayCommandWithParameter<Loan> ChangeLoanCommand { get; set; }
        public RelayCommandWithParameter<Loan> DeleteLoanCommand { get; set; }

        public LoansListViewModel()
        {
            AddNewLoanCommand = new RelayCommand(() => this.AddNewLoan());
            ChangeLoanCommand = new RelayCommandWithParameter<Loan>((loan) => this.ChangeLoan(loan));
            DeleteLoanCommand = new RelayCommandWithParameter<Loan>((loan) => this.DeleteLoan(loan));
        }

        public void PullAllLoans()
        {
            AllLoans.Clear();
            foreach (var loan in AppViewModel.GetAllLoans())
            {
                AllLoans.Add(loan);
            }
        }

        private void AddNewLoan()
        {
            Loan loan = new Loan();
            EditLoanWindow EditLoanWindow = new EditLoanWindow(loan);
            if (EditLoanWindow.ShowDialog() == true)
            {
                if (AppViewModel.AddLoan(loan))
                {
                    PullAllLoans();
                }
                else
                {
                    throw new Exception("Add Loan Failed!");
                }
            }
        }

        private void ChangeLoan(Loan loan)
        {
            if (loan == null)
            {
                MessageBox.Show("Wählen Sie bitte eine Ausleihe in der Liste aus");
                return;
            }
            Loan editableLoan = new Loan
            {
                CustomerId = loan.CustomerId,
                GadgetId = loan.GadgetId,
                PickupDate = loan.PickupDate,
                ReturnDate = loan.ReturnDate
            };

            EditLoanWindow EditLoanWindow = new EditLoanWindow(editableLoan);
            if (EditLoanWindow.ShowDialog() == true)
            {
                loan.CustomerId = editableLoan.CustomerId;
                loan.GadgetId = editableLoan.GadgetId;
                loan.PickupDate = editableLoan.PickupDate;
                loan.ReturnDate = editableLoan.ReturnDate;

                if (AppViewModel.UpdateLoan(loan))
                {
                    PullAllLoans();
                }
                else
                {
                    throw new Exception("Update Loan Failed!");
                }
            }
        }

        private void DeleteLoan(Loan loan)
        {
            if (loan == null)
            {
                MessageBox.Show("Wählen Sie bitte eine Ausleihe in der Liste aus");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diese Ausleihe löschen möchten?", "", MessageBoxButton.YesNo);

            if (result.Equals(MessageBoxResult.Yes))
            {
                if (AppViewModel.DeleteLoan(loan))
                {
                    PullAllLoans();
                }
                else
                {
                    throw new Exception("Delete Loan Failed!");
                }
            }
        }
    }
}
