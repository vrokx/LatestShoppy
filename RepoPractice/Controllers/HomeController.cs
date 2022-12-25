using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using RepoPractice.Models;
using RepoPractice.Models.DAL.Product;

namespace RepoPractice.Controllers
{
    
    public class HomeController : Controller
    {
        private IProductRepository productRepository;

        public HomeController()

        {

            this.productRepository = new ProductRepository(new ShoppingCartDBContext());

        }
        // GET: Home
        public ActionResult Index()
        {
            var list = productRepository.GetProducts().ToList();
            return View(list);
        }
    }
}