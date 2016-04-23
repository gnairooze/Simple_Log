using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Manager
    {
        private List<object> _Contexts = new List<object>();

        #region constructors
        public Manager():this(Constants.LOG_CONSOLE, null)
        {
            
        }

        public Manager(string context) : this(context, null)
        {

        }

        public Manager(string context, dynamic settings)
        {
            this._Contexts.Add(SimpleLog.Repository.LogFactory.GetLogContext(context, settings));
        }
        #endregion

        public void AddContext(string context, dynamic settings)
        {
            this._Contexts.Add(SimpleLog.Repository.LogFactory.GetLogContext(context, settings));
        }

        public void Add(Message message)
        {
            foreach (var context in this._Contexts)
            {
                if (context is SimpleLog.Repository.ILogContextAdd)
                {
                    (context as SimpleLog.Repository.ILogContextAdd).Add(message);
                }
            }
        }

        public void Delete(Message message)
        {
            foreach (var context in this._Contexts)
            {
                if (context is SimpleLog.Repository.ILogContextDelete)
                {
                    (context as SimpleLog.Repository.ILogContextDelete).Delete(message);
                }
            }
        }

        public IEnumerable<Message> Read(string context, Search search)
        {
            foreach (var item in this._Contexts)
            {
                if (item is SimpleLog.Repository.ILogContextRead && (item as SimpleLog.Repository.ILogContextRead).ContextName == context)
                {
                    return (item as SimpleLog.Repository.ILogContextRead).Read(search);
                }
            }
            return null;
        }
    }
}
