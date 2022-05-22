using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlogTool
{
    class FileHandler : IFileHandler
    {
        static List<BlogPost> objs = new List<BlogPost>();
        public void CreateOrReadFile()
        {
            string path = "./SavedBlogPosts.json";

            if (!File.Exists(path))
            {
                using FileStream fs = File.Create(path);
                var data = "[]";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fs.Write(bytes, 0, bytes.Length);
            }
            else
            {
                ReadJsonFromFile();
            }
        }

        public void ReadJsonFromFile()
        {
            string path = "./SavedBlogPosts.json";
            
            string json = File.ReadAllText(path);
            
            objs = JsonSerializer.Deserialize<List<BlogPost>>(json);
        }

        public string ConvertToJson(List<BlogPost> data)
        {
            string json = JsonSerializer.Serialize(data);
            return json;
        }
        public void WriteAllText(string text)
        {
            string path = "SavedBlogPosts.json";
            File.WriteAllText(path, text);
        }

        public void AddToList(List<BlogPost> list)
        {
            objs.ForEach(list.Add);
        }
    }
}
