using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    internal interface IFileHandler
    {
        public void WriteAllText(string text);
        public string ConvertToJson(List<BlogPost> list);
        public void ReadJsonFromFile();
        public void CreateOrReadFile();
        public void AddToList(List<BlogPost> list);
    }
}
