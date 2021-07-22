using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH3.LogAn
{
    public class FileExtensionManager : IExtensionManager
    {    
        public bool isValidLogFileName(string fileName)
        {
            if (!fileName.ToLower().EndsWith(".slf"))
                return false;
            return true;
        }
    }
}
