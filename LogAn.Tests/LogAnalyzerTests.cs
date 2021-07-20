using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer analyzer;

        [SetUp]
        public void SetUP(){
            analyzer = new LogAnalyzer();
        }


        [Test]
        public void isValidLogFileName_BadExtension_ReturnFalse(){
            //Arrange
            //LogAnalyzer analyzer = new LogAnalyzer();
            //Act
            var result = analyzer.isValidLogFileName("someFile.exe");
            //Assert
            Assert.False(result);
        }

        [TestCase("somFile.txt", false)]
        public void isValidLogFileName_VariousExtension_ChecksThem(string fileName, bool expectation) {
            //Arrange
            //Act
            var result = analyzer.isValidLogFileName(fileName);
            //Assert
            Assert.AreEqual(result, expectation);
        }

        [Test]
        public void isValidLogFileName_EmptyFileName_ThrowsEx()
        {
            //Arrange
            //Act
            var ex = Assert.Catch<Exception>(() => analyzer.isValidLogFileName(""));
            //Assert
            StringAssert.Contains("Filename must to be provided", ex.Message);
        }

    }
}
