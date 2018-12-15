using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ch.hsr.wpf.gadgeothek_UI.viewmodels;


namespace Gadgeothek_UnitTests
{
    [TestClass]
    public class ClientsListViewModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClientsListViewModel ClientsListViewModel = new ClientsListViewModel();
            ClientsListViewModel.PullAllClients();
            int result = ClientsListViewModel.AllClients.Count;
            Assert.AreEqual(7,result);
        }
    }
}
