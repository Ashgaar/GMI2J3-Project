using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace BlogTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileHandler = new FileHandler();
            var blogHandler = new BlogHandler(fileHandler);
            var menu = new Menu(blogHandler);

            menu.MainMenu();
        }
    }
}