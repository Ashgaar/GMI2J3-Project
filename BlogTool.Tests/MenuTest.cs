using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;
using BlogTool;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace BlogTool.Tests
{
    internal class MenuTest
    {
        private InputUtility _inputUtility;
        private StringWriter _stringWriter;
        private BlogHandler _blogHandler;
        private FileHandler _fileHandler;
        private MockFileSystem _mockFileSystem;
        //private InputUtility _inputUtility;
        private Menu _menu;

        [SetUp]
        public void Setup()
        {
            _mockFileSystem = new MockFileSystem();
            _inputUtility = new InputUtility();
            _stringWriter = new StringWriter();
            _fileHandler = new FileHandler(_mockFileSystem);
            _blogHandler = new BlogHandler(_fileHandler);
            _menu = new Menu(_blogHandler, _inputUtility);
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void TestSearchMenuPostExists()
        {
            BlogPost blogPost = new BlogPost();
            blogPost.Title = "test";
            blogPost.Content = "testtest";
            blogPost.Date = DateTime.Parse("2020-01-01");
            _blogHandler.posts.Add(blogPost);


            var input = new StringReader("test");
            Console.SetIn(input);
            _menu.SearchMenu();

            Assert.AreEqual("Skriv titel: Datum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n\r\n", _stringWriter.ToString());
        }

        [Test]
        public void TestSearchMenuEmptyInput()
        {
            var input = new StringReader("");
            Console.SetIn(input);
            _menu.SearchMenu();

            Assert.AreEqual("Skriv titel: Inget inlägg med titeln  hittades.\r\n", _stringWriter.ToString());
        }

        [Test]
        public void TestSearchMenuNoPosts()
        {
            var input = new StringReader("test");
            Console.SetIn(input);
            _menu.SearchMenu();

            Assert.AreEqual("Skriv titel: Inget inlägg med titeln test hittades.\r\n", _stringWriter.ToString());
        }
    }
}
