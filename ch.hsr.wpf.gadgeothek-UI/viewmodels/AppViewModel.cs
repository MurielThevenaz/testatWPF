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
        public String ServerUrl { get; set; }
        public LibraryAdminService Service { get; set; }

        public AppViewModel()
        {
            ServerUrl = ConfigurationManager.AppSettings["server"].ToString();
            Service = new LibraryAdminService(ServerUrl);
        }

        public List<Gadget> GetAllGadgets() => Service.GetAllGadgets();
        public List<Loan> GetAllLoans() => Service.GetAllLoans();
        public List<Customer> GetAllClients() => Service.GetAllCustomers();
    }
}
