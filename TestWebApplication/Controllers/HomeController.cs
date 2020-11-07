using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.Models;
using Newtonsoft.Json;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            JsonTool.JsonWrite writer = new JsonTool.JsonWrite();
            string path = ControllerContext.HttpContext.Server.MapPath("~/JsonDB/Item.json");
            List<Item> Items = new List<Item>();
            JsonTool.JsonRead reader = new JsonTool.JsonRead();
            Items = JsonConvert.DeserializeObject<List<Item>>(reader.Read(path));
            return View(Items);
        }
        
        [HttpPost]
        public ActionResult Index(Item ItemModel) // create/update 
        {
            List<Item> Items = new List<Item>();
            JsonTool.JsonRead reader = new JsonTool.JsonRead();
            string path = ControllerContext.HttpContext.Server.MapPath("~/JsonDB/Item.json");
            Items = JsonConvert.DeserializeObject<List<Item>>(reader.Read(path));
            Item newItem = Items.FirstOrDefault(x => x.Id == ItemModel.Id);
            if (newItem == null)
            {
                Items.Add(ItemModel);
            }
            else
            {
                int index = Items.FindIndex(x => x.Id == ItemModel.Id);
                Items[index] = ItemModel;
            }
            string jSONString = JsonConvert.SerializeObject(Items);
            JsonTool.JsonWrite writer = new JsonTool.JsonWrite();
            writer.Write(path, jSONString);
            return View(Items);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            List<Item> Items = new List<Item>();
            JsonTool.JsonRead reader = new JsonTool.JsonRead();
            string path = ControllerContext.HttpContext.Server.MapPath("~/JsonDB/Item.json");
            Items = JsonConvert.DeserializeObject<List<Item>>(reader.Read(path));
            int index = Items.FindIndex(x => x.Id == id);
            Items.RemoveAt(index);
            string jSONString = JsonConvert.SerializeObject(Items);
            JsonTool.JsonWrite writer = new JsonTool.JsonWrite();
            writer.Write(path, jSONString);
            return RedirectToAction("index", "Home");
        }
    }
}