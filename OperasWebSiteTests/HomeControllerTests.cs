using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using OperasWebSites.Controllers;
using OperasWebSites.Models;

namespace OperasWebSiteTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            HomeController controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
