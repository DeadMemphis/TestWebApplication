using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.JsonTool
{
    public class JsonSingleton
    {
        private static JsonSingleton instance;
        public JsonRead Reader { get; set; }
        private JsonSingleton()
        { 
        }
        public static JsonSingleton getInstance()
        {
            if (instance == null)
                instance = new JsonSingleton();
            return instance;
        }
    }
}