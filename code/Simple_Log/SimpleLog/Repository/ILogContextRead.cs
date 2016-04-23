using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal interface ILogContextRead
    {
        string ContextName { get; set; }
        IEnumerable<Message> Read(Search search);
    }
}
