using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal interface ILogContextAdd
    {
        void Add(Message message);
    }
}
