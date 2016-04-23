using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal class LogConsoleContext : ILogContextAdd
    {
        private int _Counter = 0;

        public LogConsoleContext(dynamic settings)
        {
            this.CanAddError = settings.CanAddError;
            this.CanAddWarning = settings.CanAddWarning;
            this.CanAddInfo = settings.CanAddInfo;

            Console.WriteLine("Console context initialized");
        }

        public bool CanAddError { get; set; }

        public bool CanAddInfo { get; set; }
        
        public bool CanAddWarning { get; set; }
        
        public void Add(Message message)
        {
            #region check if can add message type
            switch (message.MessageType)
            {
                case Constants.MESSAGE_TYPE_ERROR:
                    if(!this.CanAddError)
                    {
                        return;
                    }
                    break;
                case Constants.MESSAGE_TYPE_WARNING:
                    if(!this.CanAddWarning)
                    {
                        return;
                    }
                    break;
                case Constants.MESSAGE_TYPE_INFO:
                    if(!this.CanAddInfo)
                    {
                        return;
                    }
                    break;
            }
            #endregion

            if (message.ID == 0 || message.ID == long.MinValue)
            {
                message.ID = this._Counter++;
            }

            Console.WriteLine(string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\"", message.ID, message.Owner, message.IdentifierName, message.IdentifierValue, message.Group, message.Operation, message.Data, message.CreatedOn));

        }
    }
}
