using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;
using System.Diagnostics;
using System.IO;
using Moq;

namespace BlogTool.Tests
{
    public class BlogHandlerTest
    {
        private MockFileSystem _mockFileSystem;
        private FileHandler _fileHandler;
        private BlogHandler _blogHandler;
        private StringWriter _stringWriter;
        private InputUtility inputUtility;

        [SetUp]
        public void Setup()
        {
            _mockFileSystem = new MockFileSystem();
            _fileHandler = new FileHandler(_mockFileSystem);
            _blogHandler = new BlogHandler(_fileHandler,inputUtility);
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void TestBlogPostListEmpty()
        {
            _blogHandler.BlogPostList();

            Assert.AreEqual("Du har inga sparade inlägg. \r\n", _stringWriter.ToString());
        }

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

            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n\r\n", _stringWriter.ToString());
            Assert.AreEqual(1, _blogHandler.posts.Count);
        }

        [Test]
        public void TestCreatePostEmptyTitle()
        {
            _blogHandler.CreatePost("", "testtest", DateTime.Parse("2020-01-01"));

            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: \ntesttest\n\r\n", _stringWriter.ToString());
        }

        [Test]
        public void TestCreatePostEmptyContent()
        {
            _blogHandler.CreatePost("test", "", DateTime.Parse("2020-01-01"));

            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: test\n\n\r\n", _stringWriter.ToString());
        }

        [Test]
        public void TestCreatePostEmptyTitleAndContent()
        {
            _blogHandler.CreatePost("", "", DateTime.Parse("2020-01-01"));

            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: \n\n\r\n", _stringWriter.ToString());
        }

        [Test]
        public void TestBlogPostSearch()
        {
            BlogPost blogPost = new BlogPost();
            blogPost.Title = "test";
            blogPost.Content = "testtest";
            blogPost.Date = DateTime.Parse("2020-01-01");
            _blogHandler.posts.Add(blogPost);
            _blogHandler.BlogPostSearch("test");

            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n\r\n", _stringWriter.ToString());
        }

        [Test]
        public void TestBlogPostSearchEmpty()
        {
            _blogHandler.BlogPostSearch("test");

            Assert.AreEqual("Inget inlägg med titeln test hittades.\r\n", _stringWriter.ToString());
        }
    }
}