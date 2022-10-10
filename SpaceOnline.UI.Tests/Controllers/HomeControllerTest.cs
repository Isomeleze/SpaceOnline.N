using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceOnline.Core.Contracts;
using SpaceOnline.Core.Models;
using SpaceOnline.Core.ViewModels;
using SpaceOnline.UI;
using SpaceOnline.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SpaceOnline.UI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnProduct()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> categoryContext = new Mocks.MockContext<ProductCategory>();
            HomeController controller = new HomeController(productContext, categoryContext);
            productContext.Insert(new Product());

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListVM)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());
        }


    }
}