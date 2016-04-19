using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Helper
    {
        public static string GenerateFileName(string prefix)
        {
            StringBuilder bld = new StringBuilder();

            bld.Append(prefix);
            bld.AppendFormat("-UTC-{0}.csv", DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fff"));

            return bld.ToString();
        }
    }
}
