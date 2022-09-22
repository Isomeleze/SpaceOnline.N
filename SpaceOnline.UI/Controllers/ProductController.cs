using SpaceOnline.Core.Models;
using SpaceOnline.Core.ViewModels;
using SpaceOnline.DataAccess.Inmemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceOnline.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository context;
        CategoryRepository productCategories;
        public ProductController()
        {
            context = new ProductRepository();
            productCategories = new CategoryRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            ProductVM viewModel = new ProductVM();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductVM viewModel = new ProductVM();
                viewModel.Product = new Product();
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);

            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }

    }
}