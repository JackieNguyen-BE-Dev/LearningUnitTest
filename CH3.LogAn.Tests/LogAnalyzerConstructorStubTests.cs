using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH3.LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerConstructorStubTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtention_ReturnTrue()
        {
            StubExtensionManager manager = new StubExtensionManager();
            manager.shouldBeValid = true;

            LogAnalyzerConstructorStub logAnalyzer = new LogAnalyzerConstructorStub(manager as IExtensionManager);

            Assert.True(logAnalyzer.IsValidLogFileName("someFile.txt"));
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager manager = new FakeExtensionManager();

            LogAnalyzerConstructorStub logAnalyzer = new LogAnalyzerConstructorStub(manager as IExtensionManager);

            Assert.False(logAnalyzer.IsValidLogFileName("someFile.txt"));
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnFalse()
        {
            FakeExtensionManager manager = new FakeExtensionManager();
            manager.willThrows = new Exception("This is fake exception");

            LogAnalyzerConstructorStub logAnalyzer = new LogAnalyzerConstructorStub(manager as IExtensionManager);

            Assert.False(logAnalyzer.IsValidLogFileName("someFile.exe"));
        }

    }

    public class StubExtensionManager : IExtensionManager
    {
        public bool shouldBeValid;

        public bool isValidLogFileName(string fileName)
        {
            return shouldBeValid;
        }
    }

    public class FakeExtensionManager : IExtensionManager
    {
        public bool willbeInvalid = false;
        public Exception willThrows = null;


        public bool isValidLogFileName(string fileName)
        {
            if (willThrows != null)
                throw willThrows;

            return willbeInvalid;
        }
    }

}
