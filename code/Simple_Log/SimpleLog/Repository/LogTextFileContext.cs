using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal class LogTextFileContext : ILogContextAdd
    {
        #region attributes
        private string _FileName;
        #endregion

        #region properties
        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                this._FileName = value;

                addHeader();
            }
        }
        #endregion

        #region constructors
        public LogTextFileContext(dynamic settings)
        {
            this.FileName = settings.FileName;

            this.CanAddError = settings.CanAddError;
            this.CanAddWarning = settings.CanAddWarning;
            this.CanAddInfo = settings.CanAddInfo;
        }
        #endregion

        public bool CanAddError { get; set; }

        public bool CanAddInfo { get; set; }

        public bool CanAddWarning { get; set; }

        public void Add(Message message)
        {
            #region check if can add message type
            switch (message.MessageType)
            {
                case Constants.MESSAGE_TYPE_ERROR:
                    if (!this.CanAddError)
                    {
                        return;
                    }
                    break;
                case Constants.MESSAGE_TYPE_WARNING:
                    if (!this.CanAddWarning)
                    {
                        return;
                    }
                    break;
                case Constants.MESSAGE_TYPE_INFO:
                    if (!this.CanAddInfo)
                    {
                        return;
                    }
                    break;
            }
            #endregion

            validate(message);

            using (StreamWriter sw = File.AppendText(this._FileName))
            {
                sw.WriteLine(string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\"", message.ID, message.Owner, message.IdentifierName, message.IdentifierValue, message.Group, message.Operation, message.Data, message.CreatedOn));
            }
        }

        private void validate(Message message)
        {
            if(string.IsNullOrWhiteSpace(this.FileName))
            {
                throw new InvalidOperationException("Filename not set in LogTextFileContext");
            }
        }

        private void addHeader()
        {
            if (!File.Exists(this._FileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(this._FileName))
                {
                    sw.WriteLine("\"ID\", \"Owner\", \"IdentifierName\", \"IdentifierValue\", \"Group\", \"Operation\", \"Data\", \"CreatedOn\"");
                }
            }
        }
    }
}
