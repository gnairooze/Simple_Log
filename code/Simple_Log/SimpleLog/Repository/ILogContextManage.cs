using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal interface ILogContextManage:ILogContextAdd
    {
        void Delete(Message message);
        IEnumerable<Message> Read(Search search);
    }
}
