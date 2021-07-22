using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4.LogAn
{
    public class LogAnalyzer
    {
        private readonly IWebService _webService;

        public LogAnalyzer(IWebService webService)
        {
            _webService = webService;
        }

        [Conditional ("DEBUG")]
        public void Anylize(string fileName)
        {
            if (fileName.Length < 8)
                _webService.LogError("File name too short:" + fileName);
        }
    }
}
