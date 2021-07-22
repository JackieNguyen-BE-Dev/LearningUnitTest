using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH5.LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();

            LogAnalyzer log = new LogAnalyzer(logger);
            log.MinNameLength = 6;
            log.Analyze("someFile.exe");

            logger.Received().LogError("File name too short:someFile.exe");
        }

        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName("someFile.exe").Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("someFile.exe"));
        }

        [Test]
        public void Returns_ArgAny_WorksForHardCodeArgument()
        {
            IFileNameRules fakesRules = Substitute.For<IFileNameRules>();

            fakesRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.IsTrue(fakesRules.IsValidLogFileName("myFavourite.exe"));
        }

        [Test]
        public void Returns_ThrowException_WorksForHardCodedArgument()
        {

            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                     .Do(context =>
                     {
                         throw new Exception("Fake Exception");
                     });


            Assert.Throws<Exception>(() =>
            {
                fakeRules.IsValidLogFileName("IDontCare");
            });
        }

        [Test]
        public void Analyze_LoggerThrows_CallWebServiceWithNSubObject()
        {
            IWebService webService = Substitute.For<IWebService>();
            ILogger logger = Substitute.For<ILogger>();

            logger.When(x => x.LogError(Arg.Any<string>()))
                .Do(context =>
                {
                    throw new Exception("Fake exception");
                });

            LogAnalyzer_3 analyzer = new LogAnalyzer_3(webService, logger);
            analyzer.MinNameLength = 8;

            string tooShortFileName = "someFile.txt";

            analyzer.Analyze(tooShortFileName);


            webService.Received().Write(Arg.Is<string>(str => str.Contains("Error From Logger:Fake exception")));
        }

        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            Presenter presenter = new Presenter(mockView);
            mockView.Loaded += Raise.Event<Action>();

            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }
    }
}
