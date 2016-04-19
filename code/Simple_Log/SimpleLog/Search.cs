using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Search
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public List<long> IDs { get; set; }

        public List<string> Owners { get; set; }

        public string IdentifierName { get; set; }

        public List<string> IdentifierValues { get; set; }

        public List<string> Groups { get; set; }

        public List<string> Operations { get; set; }

        public DateTime? CreatedOnFrom { get; set; }

        public DateTime? CreatedOnTo { get; set; }
    }
}
