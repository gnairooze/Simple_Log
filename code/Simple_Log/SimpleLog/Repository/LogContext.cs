using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal class LogContext:DbContext,ILogContext 
    {
        public DbSet<Message> Messages { get; set; }

        public void Add(Message message)
        {
            Messages.Add(message);
            this.SaveChanges();
        }

        public void Delete(Message message)
        {
            Messages.Remove(message);
            this.SaveChanges();
        }

        public IEnumerable<Message> Read(Search search)
        {
            //more search filters to be implemented later
            return this.Messages.OrderByDescending(m => m.ID).Take(search.Size).Skip((search.Page - 1) * search.Size);
        }
    }
}
