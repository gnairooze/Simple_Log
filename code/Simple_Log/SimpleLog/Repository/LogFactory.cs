using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
   internal  class LogFactory
    {
        public static object GetLogContext(string context, dynamic settings)
        {
            if (settings != null)
            {
                settings.ContextName = context;
            }

            switch (context)
            {
                case SimpleLog.Constants.LOG_CONSOLE:
                    return new LogConsoleContext(settings);
                case SimpleLog.Constants.LOG_DB:
                    return new LogDBContext(settings);
                case SimpleLog.Constants.LOG_TEXT_FILE:
                    return new LogTextFileContext(settings);
                default:
                    return new LogConsoleContext(settings);
            }
        }
    }
}
