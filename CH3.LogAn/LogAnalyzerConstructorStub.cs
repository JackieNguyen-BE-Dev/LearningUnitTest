using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH3.LogAn
{
    public class LogAnalyzerConstructorStub
    {
        private IExtensionManager _manager;

        public LogAnalyzerConstructorStub(IExtensionManager manager)
        {
            _manager = manager;
        }

        public bool IsValidLogFileName(string fileName)
        {
            return _manager.isValidLogFileName(fileName);
        }

    }
}
