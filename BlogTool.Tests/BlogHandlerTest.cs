using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;
using System.Diagnostics;
using System.IO;

namespace BlogTool.Tests
{
    public class BlogHandlerTest
    {
        private MockFileSystem _mockFileSystem;
        private FileHandler _fileHandler;
        private BlogHandler _blogHandler;
        private StringWriter _stringWriter;

        [SetUp]
        public void Setup()
        {
            _mockFileSystem = new MockFileSystem();
            _fileHandler = new FileHandler(_mockFileSystem);
            _blogHandler = new BlogHandler(_fileHandler);
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }


        //mocking console
        [Test]
        public void TestBlogPostListEmpty()
        {
            _blogHandler.BlogPostList();

            Assert.AreEqual("Du har inga sparade inlägg. \r\n", _stringWriter.ToString());
        }

        //mocking console
        [Test]
        public void TestBlogPostList()
        {
            BlogPost blogPost = new BlogPost();
            blogPost.Title = "test";
            blogPost.Content = "testtest";
            blogPost.Date = DateTime.Parse("2020-01-01");

            _blogHandler.posts.Add(blogPost);

            _blogHandler.BlogPostList();

            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n\r\n", _stringWriter.ToString());
        }

        [Test]
        public void TestCreatePost()
        {
            _blogHandler.CreatePost("test","testtest", DateTime.Parse("2020-01-01"));

            Assert.AreEqual("Datum: 2020-01-01 00:00:00\r\nDatum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n\r\n", _stringWriter.ToString());
            Assert.AreEqual(1, _blogHandler.posts.Count);
        }
    }
}

