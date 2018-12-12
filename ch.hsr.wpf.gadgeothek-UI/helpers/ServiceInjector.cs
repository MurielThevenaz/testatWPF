using ch.hsr.wpf.gadgeothek.service;
using ch.hsr.wpf.gadgeothek_UI.viewmodels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek_UI.helpers
{
    public class ServiceInjector
    {
        public AppViewModel AppViewModel { get; }

        public ServiceInjector() {
            String ServerUrl = ConfigurationManager.AppSettings["server"].ToString();
            LibraryAdminService Service = new LibraryAdminService(ServerUrl);
            AppViewModel AppViewModel = new AppViewModel(Service);
        }
    }
}
