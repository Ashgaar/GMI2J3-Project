using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    public interface IFileHandler
    {
        public void WriteAllText(string text);
        public string ConvertToJson(List<BlogPost> list);
        public void ReadJsonFromFile(string path);
        public void CreateOrReadFile(string path);
        public void AddToList(List<BlogPost> list);
    }
}
