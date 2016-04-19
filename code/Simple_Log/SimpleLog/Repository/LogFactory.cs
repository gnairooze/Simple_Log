using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
   internal  class LogFactory
    {
        public static object GetLogContext(string context, int count, string filename)
        {
            switch (context)
            {
                case SimpleLog.Constants.LOG_CONSOLE:
                    return new ConsoleContext(count);
                case SimpleLog.Constants.LOG_DB:
                    return new LogContext();
                case SimpleLog.Constants.LOG_TEXT_FILE:
                    return new TextFileContext(filename);
                default:
                    return new LogContext();
            }
        }
    }
}
