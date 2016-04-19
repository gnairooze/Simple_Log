using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Manager
    {
        private object _Context;

        #region constructors
        public Manager(string context, int count = 50, string filename = "")
        {
            this._Context = SimpleLog.Repository.LogFactory.GetLogContext(context, count, filename);
        }
        #endregion

        public void Add(Message message)
        {
            (this._Context as SimpleLog.Repository.ILogContextAdd).Add(message);
        }

        public void Delete(Message message)
        {
            if(this._Context is SimpleLog.Repository.ILogContextManage)
            {
                (this._Context as SimpleLog.Repository.ILogContextManage).Delete(message);
            }
            else
            {
                throw new InvalidCastException("the context cannot delete message.");
            }
        }

        public IEnumerable<Message> Read(Search search)
        {
            if (this._Context is SimpleLog.Repository.ILogContextManage)
            {
                return (this._Context as SimpleLog.Repository.ILogContextManage).Read(search);
            }
            else
            {
                throw new InvalidCastException("the context cannot read messages.");
            }
        }
    }
}
