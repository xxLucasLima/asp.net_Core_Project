using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuudyProject.Services
{
    public interface IMailService
    {
        void SendEmail(string to, string from, string subject, string body);
    }
}
