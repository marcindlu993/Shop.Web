﻿using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ResourceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Resource
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetResourceData(int? category = null)
        {
            Session["Category"] = category;
            IEnumerable<Resource> resourceslist = new List<Resource>();
            if (category == 3) //pobranie nowości
            {
                DateTime date = DateTime.Now.AddDays(-14);
                DateTime nowTime = DateTime.Now; 
                resourceslist = db.Resources.Where(x => x.ReleaseDate > date && x.ReleaseDate < nowTime).OrderBy(x => x.Name).ToList();
            }
            else if (category == 4) //pobranie zapowiedzi
            {
                DateTime date = DateTime.Now.AddDays(14);
                DateTime nowTime = DateTime.Now;
                resourceslist = db.Resources.Where(x => x.ReleaseDate < date && x.ReleaseDate > nowTime).OrderBy(x => x.Name).ToList();
            }
            else if (category == 5) //pobranie okazji
            {
                resourceslist = db.Resources.Where(x => x.SuperBargain == true).OrderBy(x => x.Name).ToList();
            }
            else if (category == null)   
            {
                resourceslist = db.Resources.OrderBy(x => x.Name).ToList();
            }
            else
            {
                resourceslist = db.Resources.Where(x => x.IdTypeResource == category).OrderBy(x => x.Name).ToList();
            }

            var resourceViewModel = new List<ResourceViewModel>();
            foreach (var item in resourceslist)
            {
                resourceViewModel.Add(new ResourceViewModel
                {
                    IdResource = item.IdResource,
                    Name = item.Name,
                    ReleaseDate = item.ReleaseDate,
                    Price = item.Price,
                    NameOfAuthor = db.Authors.Where(x => x.IdAuthor == item.IdAuthor).FirstOrDefault().NameAuthor,
                    PublishingHouseName = db.PublishingHouses.Where(x => x.IdPublishingHouse == item.IdPublishingHouse).FirstOrDefault().NamePublishingHouse
                });
            }

            return PartialView(resourceViewModel);
        }

        public PartialViewResult SearchGetResourcesData(string word)//, int category)
        {
            int? category = (int?)Session["Category"];
            var resourceslist = new List<Resource>();

            if (category == 3) //pobranie nowości
            {
                DateTime date = DateTime.Now.AddDays(-14);
                DateTime nowTime = DateTime.Now;
                resourceslist = db.Resources.Include("Author").Where(x => x.ReleaseDate > date && x.ReleaseDate < nowTime && x.Name.Contains(word) || x.Author.NameAuthor.Contains(word)).OrderBy(x => x.Name).ToList();
            }
            else if (category == 4) //pobranie zapowiedzi
            {
                DateTime date = DateTime.Now.AddDays(14);
                DateTime nowTime = DateTime.Now;
                resourceslist = db.Resources.Include("Author").Where(x => x.ReleaseDate < date && x.ReleaseDate > nowTime && x.Name.Contains(word) || x.Author.NameAuthor.Contains(word)).OrderBy(x => x.Name).ToList();
            }
            else if (category == 5) //pobranie okazji
            {
                resourceslist = db.Resources.Include("Author").Where(x => x.SuperBargain == true && x.Name.Contains(word) || x.Author.NameAuthor.Contains(word)).OrderBy(x => x.Name).ToList();
            }
            else if (category == null)
            {
                resourceslist = db.Resources.Include("Author").Where(x => x.Name.Contains(word) || x.Author.NameAuthor.Contains(word)).OrderBy(x => x.Name).ToList();
            }
            else
            {
                resourceslist = db.Resources.Include("Author").Where(x => x.IdTypeResource == category && x.Name.Contains(word) || x.Author.NameAuthor.Contains(word)).OrderBy(x => x.Name).ToList();
            }
            // && x.IdTypeResource == category).ToList();
            if (resourceslist.Count == 0 || word == "")
            { 
                ViewBag.AllertNotFound = "W bazie danych nei odnaleziono produktów spełniających podane kryteria szukania";
                //resourcesList = db.Resources.OrderBy(x => x.Name).ToList();
                return PartialView("GetResourceData");
            }
            var resourceViewModel = new List<ResourceViewModel>();
            foreach (var item in resourceslist)
            {
                resourceViewModel.Add(new ResourceViewModel
                {
                    IdResource = item.IdResource,
                    Name = item.Name,
                    ReleaseDate = item.ReleaseDate,
                    Price = item.Price,
                    NameOfAuthor = db.Authors.Where(x => x.IdAuthor == item.IdAuthor).FirstOrDefault().NameAuthor,
                    PublishingHouseName = db.PublishingHouses.Where(x => x.IdPublishingHouse == item.IdPublishingHouse).FirstOrDefault().NamePublishingHouse
                });
            }
            return PartialView("GetResourceData", resourceViewModel);
        }
        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
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

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resource/Edit/5
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

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resource/Delete/5
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
