using System;
using System.IO;

namespace TestWebApplication.JsonTool
{
    public class JsonRead
    {
        public string Read(string fileName, string location)
        {
            string root = "wwwroot";
            var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            root,
            location,
            fileName);

            string jsonResult;

            using (StreamReader sr = new StreamReader(path))
            {
                jsonResult = sr.ReadToEnd();
            }
            return jsonResult;
        }
    }
}