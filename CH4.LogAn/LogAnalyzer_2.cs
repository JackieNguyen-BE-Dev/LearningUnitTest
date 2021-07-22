using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4.LogAn
{
    
    public class LogAnalyzer_2
    {
        private readonly IWebService _webService;
        private readonly IEmailService _emailService;

        public LogAnalyzer_2(IWebService webService, IEmailService emailService)
        {
            _webService = webService;
            _emailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if(fileName.Length < 8)
            {
                try
                {
                    _webService.LogError("File name too short:" + fileName);
                }
                catch(Exception ex)
                {
                    _emailService.SendEmail("longindusrobot@gmail.com", "can't log", ex.Message);
                }
            }

        }
    }
}
