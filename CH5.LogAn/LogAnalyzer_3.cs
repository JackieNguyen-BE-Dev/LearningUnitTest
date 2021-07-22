using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH5.LogAn
{
    public class LogAnalyzer_3
    {
        public IWebService _webService;
        public ILogger _logger;

        public int MinNameLength { get; set; }

        public LogAnalyzer_3(IWebService webService, ILogger logger)
        {
            _webService = webService;
            _logger = logger;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError($"File name too short:{fileName}");
                }
                catch (Exception ex)
                {
                    _webService.Write("Error From Logger:" + ex);
                }
            }
        }
    }
}
