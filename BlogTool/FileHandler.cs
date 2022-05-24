using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO.Abstractions;

namespace BlogTool
{
    public class FileHandler : IFileHandler
    {

        private readonly IFileSystem _fileSystem;


        public FileHandler(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        List<BlogPost> objs = new List<BlogPost>();
        public void CreateOrReadFile(string path)
        {
            //string path = "./SavedBlogPosts.json";

            if (!_fileSystem.File.Exists(path))
            {
                using Stream fs = (FileStream)_fileSystem.File.Create(path);
                var data = "[]";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fs.Write(bytes, 0, bytes.Length);
            }
            else
            {
                ReadJsonFromFile(path);
            }
        }

        public void ReadJsonFromFile(string path)
        {
            string json = _fileSystem.File.ReadAllText(path);

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
            _fileSystem.File.WriteAllText(path, text);
        }

        public void AddToList(List<BlogPost> list)
        {
            objs.ForEach(list.Add);
        }
    }
}
