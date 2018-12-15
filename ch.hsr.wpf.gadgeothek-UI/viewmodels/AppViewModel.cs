using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek_UI.viewmodels
{
    public class AppViewModel
    {
        private LibraryAdminService Service;

        public AppViewModel(LibraryAdminService Service)
        {
            this.Service = Service;
        }

        public List<Gadget> GetAllGadgets() => Service.GetAllGadgets();
        public List<Loan> GetAllLoans() => Service.GetAllLoans();
        public List<Customer> GetAllClients() => Service.GetAllCustomers();

        public bool AddGadget(Gadget gadget)
        {
            return Service.AddGadget(gadget);
        }

        public bool UpdateGadget(Gadget gadget)
        {
            return Service.UpdateGadget(gadget);
        }

        public bool DeleteGadget(Gadget gadget)
        {
            return Service.DeleteGadget(gadget);
        }

        public bool AddClient(Customer client)
        {
           return Service.AddCustomer(client);
        }

        public bool UpdateClient(Customer client)
        {
            return Service.UpdateCustomer(client);
        }

        public bool DeleteClient(Customer client)
        {
            return Service.DeleteCustomer(client);
        }

        public bool AddLoan(Loan loan)
        {
            return Service.AddLoan(loan);
        }

        public bool UpdateLoan(Loan loan)
        {
            return Service.UpdateLoan(loan);
        }

        public bool DeleteLoan(Loan loan)
        {
            return Service.DeleteLoan(loan);
        }
    }
}
