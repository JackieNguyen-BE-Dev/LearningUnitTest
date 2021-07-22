using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4.LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTest
    {
#if DEBUG
        [Test]
        public void Analyze_TooShortFileName_CallWebService()
        {
            FakeWebService mockService = new FakeWebService();

            LogAnalyzer Log = new LogAnalyzer(mockService);
            Log.Anylize("someFile.exe");

            StringAssert.Contains("File name too short:someFile.exe", mockService.LastError);

        }
#endif
    }

    public class FakeWebService : IWebService
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
