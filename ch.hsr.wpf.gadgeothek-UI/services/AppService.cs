using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Configuration;
using System.Collections.Generic;
using ch.hsr.wpf.gadgeothek_UI.viewmodels;

namespace ch.hsr.wpf.gadgeothek_UI.services
{
    public class AppService
    {
        public String ServerUrl { get; set; }
        public LibraryAdminService Service { get; set; }

        public GadgetsListViewModel GadgetsListViewModel { get; internal set; }
        public LoansListViewModel LoansListViewModel { get; internal set; }
        public ClientsListViewModel ClientsListViewModel { get; internal set; }

        public AppService()
        {
            ServerUrl = ConfigurationManager.AppSettings["server"].ToString();
            Service = new LibraryAdminService(ServerUrl);
        }

        public List<Gadget> GetAllGadgets() => Service.GetAllGadgets();
        public List<Loan> GetAllLoans() => Service.GetAllLoans();
        public List<Customer> GetAllClients() => Service.GetAllCustomers();
    }
}
