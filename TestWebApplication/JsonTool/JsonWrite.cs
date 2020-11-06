using System;
using System.IO;

namespace TestWebApplication.JsonTool
{
    public class JsonWrite
    {
        public void Write(string fileName, string location, string jstring)
        {
            string root = "wwwroot";
            var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            root,
            location,
            fileName);

            using (var sw = File.CreateText(path))
            {
                sw.Write(jstring);
            }
        }
    }
}