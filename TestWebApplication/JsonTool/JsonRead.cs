using System;
using System.IO;

namespace TestWebApplication.JsonTool
{
    public class JsonRead
    {
        public string Read(string path)
        {
            string jsonResult;
            using (StreamReader sr = new StreamReader(path))
            {
                jsonResult = sr.ReadToEnd();
            }
            return jsonResult;
        }
    }
}