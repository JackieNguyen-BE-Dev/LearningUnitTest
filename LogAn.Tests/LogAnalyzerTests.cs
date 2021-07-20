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
        [Test]
        public void isValidLogFileName_BadExtension_ReturnFalse()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();
            //Act
            var result = analyzer.isValidLogFileName("someFile.exe");
            //Assert
            Assert.False(result);
        }
    }
}
