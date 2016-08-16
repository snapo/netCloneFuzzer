using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCloneFuzzer
{
    public delegate void AddLogMessageDelegate(LogMessageType type, string message);

    public enum LogMessageType
    {
        Information,
        Warning,
        Error
    }
}
