using System;
using System.IO;
using System.Web.Mvc;

namespace TestWebApplication.JsonTool
{
    public class JsonWrite
    {
        public void Write(string path, string jstring)
        {
            using (var sw = File.CreateText(path))
            {
                sw.Write(jstring);
            }
        }
    }
}