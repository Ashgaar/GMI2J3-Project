using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace BlogTool
{
    public class BlogHandler : IBlogHandler
    {
        public List<BlogPost> posts = new List<BlogPost>();
        
        private IFileHandler _fileHandler;
        private IInputUtility _inputUtility;

        public BlogHandler(IFileHandler fileHandler, IInputUtility inputUtility)
        {
            _fileHandler = fileHandler;
            _inputUtility = inputUtility;
            _fileHandler.CreateOrReadFile("./SavedBlogPosts.json");           
            _fileHandler.AddToList(posts);
        }

        public void BlogPost(string title, string content,DateTime date, string path)
        {
            CreatePost(title, content,date );
            var jsonData = _fileHandler.ConvertToJson(posts);
            _fileHandler.WriteAllText(jsonData, path );
            _fileHandler.ReadJsonFromFile(path);
        }

        public void BlogPostList()
        {
            if (posts.Count == 0)
            {
                Console.WriteLine("Du har inga sparade inlägg. ");
            }
            else
            {
                posts.ForEach(Console.WriteLine);
            }
        }
        
        public void BlogPostSearch()
        {
            string search = _inputUtility.Input("Skriv titel: ");
            try {
                int i = posts.FindIndex(x => x.Title.Contains(search));
                Console.WriteLine(posts[i]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Inget inlägg med titeln " + search + " hittades.");
            }
        }
        public void CreatePost(string title, string content, DateTime date)
        {
            BlogPost post = new BlogPost();

            post.Date = date;
            post.Title = title;
            post.Content = content;

            posts.Add(post);

            Console.WriteLine(post);
        }
    }
}
