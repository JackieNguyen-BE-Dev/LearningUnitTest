using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4.LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzer_2Test
    {
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            StubService stubService = new StubService();
            stubService.willThrow = new Exception("Fake exception");


            MockService mockService = new MockService();

            LogAnalyzer_2 analyzer_2 = new LogAnalyzer_2(stubService, mockService);
            analyzer_2.Analyze("someFile.exe");


            Assert.AreEqual("longindusrobot@gmail.com", mockService.To);
            Assert.AreEqual("fake exception", mockService.Body);
            Assert.AreEqual("can't log", mockService.Subject);
        }
    }


    public class StubService : IWebService
    {
        public Exception willThrow;


        public void LogError(string message)
        {
            if (willThrow != null)
                throw willThrow;
        }
    }


    public class MockService : IEmailService
    {
        public string To;

        public string Subject;

        public string Body;


        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
