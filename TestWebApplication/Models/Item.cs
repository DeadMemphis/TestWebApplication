using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    public class Item
    {
        public Item()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}