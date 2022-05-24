using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.IO.Abstractions;

namespace BlogTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputUility = new InputUtility();
            var fileHandler = new FileHandler(fileSystem: new FileSystem());
            var blogHandler = new BlogHandler(fileHandler,inputUility);
            var menu = new Menu(blogHandler,inputUility);

            menu.MainMenu();
        }
    }
}