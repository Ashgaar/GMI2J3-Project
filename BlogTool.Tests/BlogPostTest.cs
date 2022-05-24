using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BlogTool.Tests
{
    public class BlogPostTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestToString()
        {
            BlogPost blogPost = new BlogPost();
            blogPost.Title = "test";
            blogPost.Content = "testtest";
            blogPost.Date = DateTime.Parse("2020-01-01");
            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n", blogPost.ToString());
        }
    }
}

