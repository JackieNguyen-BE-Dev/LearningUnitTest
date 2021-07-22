using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH5.LogAn
{
    public class LogAnalyzer
    {
        private ILogger _logger;

        public LogAnalyzer(ILogger logger)
        {
            _logger = logger;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string fileName)
        {
            _logger.LogError($"File name too short:{fileName}");
        }
    }
}
