using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using RepoPractice.Models;
using RepoPractice.Models.DAL;
using RepoPractice.Models.DAL.Product;

namespace RepoPractice.Controllers
{

    public class ProductController : Controller
    {
        private IRepository<ProductModel> InterFaceObj;

        public ProductController()
        {
            this.InterFaceObj = new GenericRepository<ProductModel>();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel collection)
        {
            InterFaceObj.Add(collection);
            InterFaceObj.Save();
            return RedirectToAction("DisplayAllProducts");
        }

        public ActionResult DisplayAllProducts()
        {
            return View(from i in InterFaceObj.GetAll() select i); 
        }
        
        public ActionResult UpdateProducts(int id)
        {
            ProductModel p = InterFaceObj.GetAllById(id);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProducts(int id, ProductModel collection)
        {
            InterFaceObj.Update(collection);
            InterFaceObj.Save();
            return RedirectToAction("DisplayAllProducts");
        }

        public ActionResult DeleteProduct(int id)
        {
            ProductModel p = InterFaceObj.GetAllById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id , ProductModel collection)
        {
            InterFaceObj.Delete(id);
            InterFaceObj.Save();
            return RedirectToAction("DisplayAllProducts");
        }

    }
}