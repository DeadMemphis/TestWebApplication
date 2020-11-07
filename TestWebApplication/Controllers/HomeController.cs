using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.Models;
using Newtonsoft.Json;
using PagedList;
using TestWebApplication.JsonTool;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        JsonHelper jsondb = new JsonHelper();
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CategorySortParm = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            switch (sortOrder)
            {
                case "category_desc":
                    return View(jsondb.itemsSet.OrderByDescending(cat => cat.Category).ToPagedList(pageNumber, pageSize));
                default:
                    return View(jsondb.itemsSet.OrderBy(cat => cat.Category).ToPagedList(pageNumber, pageSize));
            }
            //return View(Items);
        }

        public ActionResult Create() // create/update 
        {
            return PartialView("Create");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            jsondb.itemsSet.Add(item);
            jsondb.Save();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int ItemId)
        {
            Item itemToEdit = jsondb.itemsSet.Find(x => x.Id == ItemId);
            if (itemToEdit != null)
            {
                return PartialView("Edit", itemToEdit);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            int index = jsondb.itemsSet.FindIndex(x => x.Id == item.Id);
            jsondb.itemsSet[index] = item;
            jsondb.Save();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int ItemId)
        {
            Item itemToDelete = jsondb.itemsSet.Find(x => x.Id == ItemId);
            if (itemToDelete != null)
            {
                jsondb.itemsSet.Remove(itemToDelete);
                jsondb.Save();
                return PartialView("Delete", itemToDelete);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int ItemId)
        {
            Item itemToDelete = jsondb.itemsSet.Find(x => x.Id == ItemId);
            if (itemToDelete != null)
            {
                jsondb.itemsSet.Remove(itemToDelete);
                jsondb.Save();
            }
            return RedirectToAction("Index");
        }
    }
}