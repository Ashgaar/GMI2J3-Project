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

namespace BlogTool.Tests
{
    internal class FileHandlerTest
    {
        private MockFileSystem _mockFileSystem;
        private FileHandler _fileHandler;

        [SetUp]
        public void Setup()
        {
            _mockFileSystem = new MockFileSystem();
            _fileHandler = new FileHandler(_mockFileSystem);
        }


        [Test]
        public void TestReadJsonFromFile()
        {
            List<BlogPost> list = new List<BlogPost>();
            
            string input = "[{\"Title\":\"test\",\"Content\":\"testtest\"}]";
            var fInput = input.Replace(@"\","");
            var mockInputFile = new MockFileData(fInput);

            _mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            _fileHandler.ReadJsonFromFile(@"C:\temp\in.txt");
            _fileHandler.AddToList(list);

            Assert.AreEqual(list[0].Title, "test");
            Assert.AreEqual(list[0].Content, "testtest");
        }

        [Test]
        public void TestWriteToFile()
        {
            string input = "yes";
            MockFileData mockInputFile = new MockFileData(input);
            _mockFileSystem.AddFile(@"C:\temp\read.txt", mockInputFile);

            _fileHandler.WriteAllText("no",@"C:\temp\read.txt");

            MockFileData mockOutputFile = _mockFileSystem.GetFile(@"C:\temp\read.txt");

            string[] output = mockOutputFile.TextContents.Split();

            Assert.AreEqual("no", output[0]);
        }

        [Test]
        public void TestCreateFile()
        {
            string path = @"C:\temp\create.txt";
            _fileHandler.CreateOrReadFile(path);

            Assert.IsTrue(_mockFileSystem.FileExists(@"C:\temp\create.txt"));
        }

        [Test]
        public void TestConvertToJson() {
            List<BlogPost> list = new List<BlogPost>();
            BlogPost blogPost = new BlogPost();
            blogPost.Title = "test";
            blogPost.Content = "testtest";
            blogPost.Date = DateTime.Parse("2020-01-01");
            list.Add(blogPost);
            var json = _fileHandler.ConvertToJson(list);
            Assert.AreEqual(@"[{""Date"":""2020-01-01T00:00:00"",""Title"":""test"",""Content"":""testtest""}]", json);
        }  
    }
}
