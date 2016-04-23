using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal class LogDBContext:DbContext,ILogContextAdd, ILogContextDelete, ILogContextRead
    {
        public DbSet<Message> Messages { get; set; }

        public LogDBContext()
        {
            this.CanAddError = true;
            this.CanAddWarning = true;
            this.CanAddInfo = true;
            this.ContextName = Constants.LOG_DB;
        }

        public LogDBContext(dynamic settings)
        {
            this.CanAddError = settings.CanAddError;
            this.CanAddWarning = settings.CanAddWarning;
            this.CanAddInfo = settings.CanAddInfo;
            this.ContextName = settings.ContextName;
        }

        public bool CanAddError { get; set; }

        public bool CanAddInfo { get; set; }

        public bool CanAddWarning { get; set; }

        public string ContextName { get; set; }
        
        public void Add(Message message)
        {
            #region check if can add message type
            switch (message.MessageType)
            {
                case Constants.MESSAGE_TYPE_ERROR:
                    if (!this.CanAddError)
                    {
                        return;
                    }
                    break;
                case Constants.MESSAGE_TYPE_WARNING:
                    if (!this.CanAddWarning)
                    {
                        return;
                    }
                    break;
                case Constants.MESSAGE_TYPE_INFO:
                    if (!this.CanAddInfo)
                    {
                        return;
                    }
                    break;
            }
            #endregion

            Messages.Add(message);

            try
            {
                this.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
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
