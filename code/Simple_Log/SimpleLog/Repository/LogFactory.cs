using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
   internal  class LogFactory
    {
        public static ILogContext GetLogContext(string context, int count = 50)
        {
            switch (context)
            {
                case SimpleLog.Constants.LOG_CONSOLE:
                    return new ConsoleContext(count);
                case SimpleLog.Constants.LOG_DB:
                    return new LogContext();
                default:
                    return new LogContext();
            }
        }
    }
}
