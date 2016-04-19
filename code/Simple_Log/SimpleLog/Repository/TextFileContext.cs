using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal class TextFileContext : ILogContextAdd
    {
        #region attributes
        private string _FileName;
        #endregion

        #region constructors
        public TextFileContext(string fileName)
        {
            this._FileName = fileName;

            if (!File.Exists(this._FileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(this._FileName))
                {
                    sw.WriteLine("\"ID\", \"Owner\", \"IdentifierName\", \"IdentifierValue\", \"Group\", \"Operation\", \"Data\", \"CreatedOn\"");
                }
            }
        }
        #endregion

        public void Add(Message message)
        {
            using (StreamWriter sw = File.AppendText(this._FileName))
            {
                sw.WriteLine(string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\"", message.ID, message.Owner, message.IdentifierName, message.IdentifierValue, message.Group, message.Operation, message.Data, message.CreatedOn));
            }
        }
    }
}
