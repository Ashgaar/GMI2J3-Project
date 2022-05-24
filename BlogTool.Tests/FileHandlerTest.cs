using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;
using BlogTool;

namespace BlogTool.Tests
{
    internal class FileHandlerTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}

        [Test]
        public void TestReadFromFile()
        {
            List<BlogPost> mm = new List<BlogPost>();            
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("[{ \"Date \": \"2022 - 05 - 24T11: 48:18.4018147 + 02:00 \",  \"Title \": \"yes \",  \"Content \": \"yesyesyse\"}]");

            mockFileSystem.AddFile(@"C:\temp\test.json", mockInputFile);

            var sut = new FileHandler(mockFileSystem);
            sut.ReadJsonFromFile(@"C:\temp\test.json");
            sut.AddToList(mm);

            //MockFileData mockOutputFile = mockFileSystem.GetFile(@"C:\temp\test.json");
            //mm[0].Title = "yes";

            Assert.AreEqual("yes", mm[0]);
        }
    }
}
