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
        static List<BlogPost> posts = new List<BlogPost>();
        
        private IFileHandler _fileHandler;

        public BlogHandler(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
            _fileHandler.CreateOrReadFile("./SavedBlogPosts.json");           
            _fileHandler.AddToList(posts);
        }

        public void BlogPost(string title, string content)
        {
            CreatePost(title, content);
            var jsonData = _fileHandler.ConvertToJson(posts);
            _fileHandler.WriteAllText(jsonData, "./SavedBlogPosts.json" );
            _fileHandler.ReadJsonFromFile("./SavedBlogPosts.json");
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
            Console.Write("Skriv titel: ");
            
            string search = Console.ReadLine();
            try {
                int i = posts.FindIndex(x => x.Title.Contains(search));
                Console.WriteLine(posts[i]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Inget inlägg med titeln " + search + " hittades.");
            }
        }
        public void CreatePost(string title, string content)
        {
            BlogPost post = new BlogPost();

            DateTime date = DateTime.Now;

            post.Date = date;

            Console.WriteLine("Datum: {0}", date);

            post.Title = title;
            post.Content = content;

            posts.Add(post);
            foreach(var i in posts){
                Console.WriteLine(i);
            }


            Console.WriteLine(post);
        }
    }
}
