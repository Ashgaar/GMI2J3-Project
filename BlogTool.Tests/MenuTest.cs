using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using BlogTool;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace BlogTool.Tests
{
    internal class MenuTest
    {
        private InputUtility _inputUtility;
        private StringWriter _stringWriter;
        private BlogHandler _blogHandler;
        private FileHandler _fileHandler;
        private MockFileSystem _fileSystem;
        //private InputUtility _inputUtility;
        private Menu _menu;

        [SetUp]
        public void Setup()
        {
            _inputUtility = new InputUtility();
            _stringWriter = new StringWriter();
            _fileHandler = new FileHandler(_fileSystem);
            _blogHandler = new BlogHandler(_fileHandler);
            _menu = new Menu(_blogHandler, _inputUtility);
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void TestSearchMenu()
        {
            
        }
    }
}
