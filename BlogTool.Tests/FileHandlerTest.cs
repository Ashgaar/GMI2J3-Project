using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;
using BlogTool;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BlogTool.Tests
{
    internal class FileHandlerTest
    {
        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void TestReadFromFile()
        {
            List<BlogPost> list = new List<BlogPost>();
            var mockFileSystem = new MockFileSystem();
            var fileHandler = new FileHandler(mockFileSystem);
            
            string input = "[{\"Title\":\"test\",\"Content\":\"testtest\"}]";
            var iinput = input.Replace(@"\","");
            var mockInputFile = new MockFileData(iinput);

            mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            fileHandler.ReadJsonFromFile(@"C:\temp\in.txt");
            fileHandler.AddToList(list);

            Assert.AreEqual(list[0].Title, "test");
            Assert.AreEqual(list[0].Content, "testtest");
        }

        [Test]
        public void TestWriteToFile()
        {
            var mockFileSystem = new MockFileSystem();
            var fileHandler = new FileHandler(mockFileSystem);

            string input = "yes";
            MockFileData mockInputFile = new MockFileData(input);
            mockFileSystem.AddFile(@"C:\temp\read.txt", mockInputFile);

            fileHandler.WriteAllText("no",@"C:\temp\read.txt");

            MockFileData mockOutputFile = mockFileSystem.GetFile(@"C:\temp\read.txt");

            string[] output = mockOutputFile.TextContents.Split();

            Assert.AreEqual("no", output[0]);
        }
    }
}
