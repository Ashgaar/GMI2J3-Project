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
        [SetUp]
        public void Setup()
        {
        }


        //mocking console
        [Test]
        public void TestBlogPostListEmpty()
        {
            var mockFileSystem = new MockFileSystem();
            var fileHandler = new FileHandler(mockFileSystem);
            var blogHandler = new BlogHandler(fileHandler);

            
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            blogHandler.BlogPostList();

            Assert.AreEqual("Du har inga sparade inlägg. \r\n", stringWriter.ToString());
        }

        //mocking console
        [Test]
        public void TestBlogPostList()
        {
            var mockFileSystem = new MockFileSystem();
            var fileHandler = new FileHandler(mockFileSystem);
            var blogHandler = new BlogHandler(fileHandler);

            BlogPost blogPost = new BlogPost();
            blogPost.Title = "test";
            blogPost.Content = "testtest";
            blogPost.Date = DateTime.Parse("2020-01-01");

            blogHandler.posts.Add(blogPost);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            blogHandler.BlogPostList();


            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n\r\n", stringWriter.ToString());
        }
    }

}

