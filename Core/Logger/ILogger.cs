using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Logger
{
    public interface ILogger
    {
        void Log(string log);
        void ErrorLog(string errorMessage);
    }
}
