using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;

namespace BlogTool.Tests
{
    internal class InputUtilityTest
    {
        private InputUtility _inputUtility;
        private StringWriter _stringWriter;

        [SetUp]
        public void Setup()
        {
            _inputUtility = new InputUtility();
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }
        
        [Test]
        public void TestInputValid()
        {
            var input = new StringReader("Hello");
            Console.SetIn(input);
            var result = _inputUtility.Input("Input:");

            Assert.AreEqual("Hello", result); 
        }

        [Test]
        public void TestInputEmpty()
        {
            var input = new StringReader("");
            Console.SetIn(input);
            var result = _inputUtility.Input("Input: ");

            Assert.AreEqual(null, result);
        }

        [Test]
        public void TestCorrectPrompt()
        {
            var input = new StringReader("yes");
            Console.SetIn(input);
            _inputUtility.Input("Input: ");

            Assert.AreEqual("Input: ", _stringWriter.ToString());
        }
    }
}
