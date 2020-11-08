using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using TestWebApplication.Models;

namespace TestWebApplication.JsonTool
{
    public class JsonHelper
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory;
        private string DBName = "Item.json";
        private readonly static JsonHelper instanse = new JsonHelper();
        private JsonRead Reader { get; set; }
        private JsonWrite Writer { get; set; }
        //db context
        public List<Item> itemsSet;
        private JsonHelper()
        {
            path = GetWorkingDirecrory();
            Reader = new JsonRead();
            Writer = new JsonWrite();
            itemsSet = JsonConvert.DeserializeObject<List<Item>>(Load());
        }

        public static JsonHelper GetInstance()
        {
            return instanse;
        }

        private string GetWorkingDirecrory()
        {
            string dir = string.Empty;
            string[] dirs = Directory.GetDirectories(path);
            foreach (string str in Directory.GetDirectories(path))
            {
                if (str.Contains("JsonDB"))
                {
                    dir = str;
                }
            }
            return Path.Combine(dir, DBName);
        }
        private string Load()
        {
            return Reader.Read(path);
        }
        public void Save()
        {
            string jsonstr = JsonConvert.SerializeObject(itemsSet);
            Writer.Write(path, jsonstr);
        }
    }
}