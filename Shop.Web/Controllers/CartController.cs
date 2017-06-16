using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public PartialViewResult AddToCart(int? id)
        {
            Resource resource = db.Resources.Where(x => x.IdResource == id).FirstOrDefault();
            AddToCartViewModel model = new AddToCartViewModel()
            {
                Name = resource.Name
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult AddToCart([Bind( Include = "Id,Name,MediaType,Quantity")] AddToCartViewModel model)
        {
            if (ModelState.IsValid)
            {
                Cart cartUser = GetCart();
                Resource resource = db.Resources.Find(model.Id);
                if (resource == null)
                {
                    return PartialView(model);
                }
                cartUser.AddItem(resource, model.Quantity, model.MediaType);
                ViewBag.CounterStruke = cartUser.CounterResources();
                return PartialView("DoneAddToCart");
            }
            else
                return PartialView(model);
        }

        public PartialViewResult MyCart()
        {
            Cart cartUser = GetCart();
            List<MyCartViewModel> myCart = new List<MyCartViewModel>();
            foreach (var item in cartUser.Positions)
            {
                myCart.Add(new MyCartViewModel() { Name = item.Resource.Name, Media = item.Media, Quantity = item.Quantity, Price = item.Resource.Price });
            }
            ViewBag.SumValue = cartUser.SumValue();
            return PartialView(myCart);
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
