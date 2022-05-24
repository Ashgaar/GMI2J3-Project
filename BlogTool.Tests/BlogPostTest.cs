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
        private BlogPost _blogPost;
        
        [SetUp]
        public void Setup()
        {
            _blogPost = new BlogPost();
        }

        [Test]
        public void TestToString()
        {
            _blogPost.Title = "test";
            _blogPost.Content = "testtest";
            _blogPost.Date = DateTime.Parse("2020-01-01");
            Assert.AreEqual("Datum: 2020-01-01 Tid: 12:00\nRubrik: test\ntesttest\n", _blogPost.ToString());
        }
    }
}

