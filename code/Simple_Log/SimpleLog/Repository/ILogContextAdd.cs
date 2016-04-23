using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal interface ILogContextAdd
    {
        bool CanAddError { get; set; }
        bool CanAddWarning { get; set; }
        bool CanAddInfo { get; set; }

        void Add(Message message);
    }
}
