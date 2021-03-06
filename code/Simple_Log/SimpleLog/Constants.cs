﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Constants
    {
        #region contexts
        public const string LOG_DB = "Log DB Context";
        public const string LOG_CONSOLE = "Log Console Context";
        public const string LOG_TEXT_FILE = "Log Text File Context";
        #endregion

        #region message types
        public const string MESSAGE_TYPE_ERROR = "error";
        public const string MESSAGE_TYPE_WARNING = "warning";
        public const string MESSAGE_TYPE_INFO = "info";
        #endregion
    }
}
