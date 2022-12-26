using RepoPractice.Models.DAL.Product;
using RepoPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;

namespace RepoPractice.Controllers
{
    #region
    /// <summary>
    /// Contains all buyer actions
    /// </summary>
    public class BuyerController : Controller
    {
        ShoppingCartDBContext db = new ShoppingCartDBContext();
        private IRepository<UserModel> userObj;
        private IRepository<ProductModel> productObj;
        private IRepository<CartModel> cartObj;
        private IRepository<OrderModel> orderObj;
        private IRepository<WalletModel> walletObj;


        public BuyerController()
        {
            this.productObj = new GenericRepository<ProductModel>();
            this.userObj = new GenericRepository<UserModel>();
            this.cartObj = new GenericRepository<CartModel>();
            this.orderObj = new GenericRepository<OrderModel>();
            this.walletObj = new GenericRepository<WalletModel>();
        }

        [Authorize]
        public ActionResult Index()
        {
            try
            {
                return View(from i in productObj.GetAll().OrderByDescending(x => x.ProductId) select i);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #region
        /// <summary>
        /// Send order confirmation mail to buyer
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SendMail()
        {
            try
            {

                MailMessage mm = new MailMessage("radhakrishna36495@gmail.com", User.Identity.Name);
                mm.Subject = "Order Confirmed";
                mm.Body = "Your Order Id " + (int)Session["lastOrderId"] + " Order is Confirmed";
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;


                NetworkCredential nc = new NetworkCredential("radhakrishna36495@gmail.com", "iufedzbfhqlpypdl");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = nc;
                smtp.Send(mm);

                return RedirectToAction("BuyerDisplayAllProduct");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// Display all products on home page
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyerDisplayAllProduct()
        {
            try
            {
                return View(from i in productObj.GetAll() select i);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// Add to cart action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddToCart(int id)
        {

            ProductModel p = productObj.GetAllById(Convert.ToInt32(id));
            return View(p);

        }
        List<CartModel> li = new List<CartModel>();
        [HttpPost]
        public ActionResult AddToCart(/*ProductModel pi*/ string qty, int? Id)
        {

            ProductModel po = productObj.GetAllById(Convert.ToInt32(Id));
            CartModel co = new CartModel();
            co.ProductModel_ProductId = po.ProductId;
            co.productname = po.ProductName;
            co.price = (int)po.Price;
            co.Quantity = Convert.ToInt32(qty);
            co.TotalAmount = co.price * co.Quantity;

            if (TempData["cart"] == null)
            {
                li.Add(co);
                TempData["cart"] = li;
            }
            else
            {
                List<CartModel> li2 = TempData["cart"] as List<CartModel>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.CartId == co.ProductModel_ProductId)
                    {
                        item.Quantity = co.Quantity;
                        item.TotalAmount = co.TotalAmount;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    li2.Add(co);
                }

                TempData["cart"] = li2;
            }
            TempData.Keep();

            cartObj.Add(co);
            cartObj.Save();



            return RedirectToAction("ViewCart");

        }
        #endregion

        #region
        /// <summary>
        /// Remove from cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Remove(int? id)
        {
            try
            {
                cartObj.Delete(Convert.ToInt32(id));
                cartObj.Save();
                return RedirectToAction("ViewCart");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// Display Cart
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ViewCart()
        {
            try
            {
                List<CartModel> cart = cartObj.GetAll().ToList();
                var cartId = (from x in cart select x.CartId).FirstOrDefault();
                if (cartId != 0)
                {

                    var GrandTotal = Convert.ToInt32((from x in cart select x.TotalAmount).Sum());

                    Session["GrandTotal"] = GrandTotal;

                    ViewBag.GrandTotal = (int)Session["GrandTotal"];
                    return View(from i in cartObj.GetAll() select i);

                }
                else
                {
                    return RedirectToAction("CartNull");
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult CartNull()
        {
            return View();
        }
        #endregion

        #region
        /// <summary>
        /// to update user profile
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UpdateProfile()
        {
            var id = (int)Session["UserId"];

            UserModel u = userObj.GetAllById(id);
            return View(u);
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserModel collection)
        {
            try
            {
                userObj.Update(collection);
                userObj.Save();
                return RedirectToAction("Checkout");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        public ActionResult CreateWallet()
        {
            var id = (int)Session["UserId"];

            List<WalletModel> wmList = walletObj.GetAll().ToList();

            var credentials = db.WalletSet.Where(x => x.UserModel_UserId == id).FirstOrDefault();
            if (credentials != null)
            {
                var widList = (from i in wmList where i.UserModel_UserId == id select i.UserModel_UserId).ToList();
                var wid = Convert.ToInt32(widList[0]);

                if (wid == id)
                {
                    return RedirectToAction("AddBalance");
                }
                return Content("Unhandled Exception");
            }
            else
            {
                WalletModel wm = new WalletModel();

                wm.CurrentBalance = 0;
                wm.UserModel_UserId = id;
                walletObj.Add(wm);
                walletObj.Save();

                return RedirectToAction("AddBalance");
            }
        }

        #region
        /// <summary>
        /// To add balance in wallet
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddBalance()
        {
            try
            {
                var id = (int)Session["UserId"];

                var credentials = db.WalletSet.Where(x => x.UserModel_UserId == id).FirstOrDefault();
                var wid = credentials.WalletId;

                WalletModel w = walletObj.GetAllById(wid);
                return View(w);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBalance(WalletModel collection)
        {
            try
            {
                walletObj.Update(collection);
                walletObj.Save();
                return RedirectToAction("Checkout");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// direct to checkout page
        /// </summary>
        /// <returns></returns>
        public ActionResult Checkout()
        {
            try
            {
                TempData.Keep();
                return View();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// to choose payment mode
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult PaymentMode()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult PaymentMode(OrderModel order)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// to confirm order
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult OrderConfirmed(string ModeOfPayment)
        {
            Session["ModeOfPayment"] = ModeOfPayment;

            try
            { if (ModeOfPayment == "Wallet")
                {
                    var userId = (int)Session["UserId"];

                    List<WalletModel> wallet = walletObj.GetAll().ToList();
                    var currentBalance = (from i in wallet where i.UserModel_UserId == userId select i.CurrentBalance).ToList();

                    if (currentBalance[0] >= (int)Session["GrandTotal"])
                    {
                        return RedirectToAction("OrderDetails");
                    }
                    else
                    {
                        return RedirectToAction("BalanceLow");
                    }
                }
                else
                {
                    return RedirectToAction("OrderDetails");
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// Order Details
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderDetails()
        {
            OrderModel order = new OrderModel();

            var date = DateTime.Now.ToString("yyyyMMdd");

            order.OrderDate = DateTime.Now;
            if ((string)Session["ModeOfPayment"] == "COD")
            {
                order.AmountPaid = 0;

                List<CartModel> cart = cartObj.GetAll().ToList();
                var cartId =  (from i in cart select i.CartId).ToList();
                var length = cart.Count();

                for(var i =0; i <cartId.Count; i++)
                {
                    var item = (int)cartId[i];
                    cartObj.Delete(item);
                }
                cartObj.Save();
            }
            else
            {
                order.AmountPaid = (int)Session["GrandTotal"];
            }
            order.ModeOfPayment = (string)Session["ModeOfPayment"];
            order.OrderStatus = "Confirmed";

            orderObj.Add(order);
            orderObj.Save();

            return RedirectToAction("FinalPage");

        }
        #endregion
        public ActionResult FinalPage()
        {
            List<OrderModel> orders = orderObj.GetAll().ToList();

            var lastOrder = orders.LastOrDefault();

            Session["lastOrderId"] = lastOrder.OrderId;
            Session["lastOrderDate"] = lastOrder.OrderDate;
            Session["lastOrderPaymentMode"] = lastOrder.ModeOfPayment;
            Session["lastOrderAmountPaid"] = lastOrder.AmountPaid;

            return View();
        }
        #region
        /// <summary>
        /// display only searched product
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ActionResult Search(string searchString)
        {
            try
            {
                var det = db.ProductSet.Where(d => d.ProductName.ToUpper().Contains(searchString.ToUpper())).ToList();

                return View(det);
            } 
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

    }

    #endregion
}
