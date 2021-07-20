using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer
    {
        public bool isValidLogFileName(string fileName)
        {
            /*if (!File.Exists(fileName))
                throw new Exception("No log file with that name exists");
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Filename must to be provided");*/
            if (!fileName.ToLower().EndsWith(".slf"))
                return false;
            return true;
        }
    }
}
