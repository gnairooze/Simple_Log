using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Manager
    {
        private SimpleLog.Repository.ILogContext _Context;

        #region constructors
        public Manager(string context, int count = 50)
        {
            this._Context = SimpleLog.Repository.LogFactory.GetLogContext(context, count);
        }
        #endregion

        public void Add(Message message)
        {
            this._Context.Add(message);
        }

        public void Delete(Message message)
        {
            this._Context.Delete(message);
        }

        public IEnumerable<Message> Read(Search search)
        {
            return this._Context.Read(search);
        }
    }
}
