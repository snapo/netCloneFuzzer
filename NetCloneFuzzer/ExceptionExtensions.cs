using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCloneFuzzer
{
    static class ExceptionExtensions
    {
        public static string GetFullMessage(this Exception ex)
        {
            if (ex == null) { return null; }
            StringBuilder fullMsg = new StringBuilder();
            fullMsg.Append(ex.Message);
            ex = ex.InnerException;
            while (ex != null)
            {
                fullMsg.AppendFormat(" {0}", ex.Message);
                ex = ex.InnerException;
            }
            return fullMsg.ToString();
        }

    }
}
