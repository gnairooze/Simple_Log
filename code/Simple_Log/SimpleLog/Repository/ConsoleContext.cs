using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Repository
{
    internal class ConsoleContext : ILogContextManage
    {
        private List<Message> _Messages = new List<Message>();

        public ConsoleContext(int count)
        {
            DateTime date = DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                int businessID = i + 1;

                this._Messages.Add(new Message() {
                    CreatedOn = date,
                    Data = "Data " + businessID.ToString(),
                    Group = "Group " + businessID.ToString(),
                    ID = businessID,
                    IdentifierName = "DMO",
                    IdentifierValue = businessID.ToString(),
                    Operation = "Operation " + businessID.ToString(),
                    Owner = "Owner DEMO"
                });
            }

            Console.WriteLine("Console context initialized");
        }

        public void Add(Message message)
        {
            if(message.ID != 0 && message.ID != long.MinValue)
            {
                bool exists = this._Messages.Where(m => m.ID == message.ID).Any();
                if (exists)
                {
                    throw new InvalidOperationException("Message already exists");
                }
            }

            long businessId = this._Messages.Max(m => m.ID)+1;

            message.ID = businessId;
            this._Messages.Add(message);

            Console.WriteLine("Message added");
        }

        public void Delete(Message message)
        {
            this._Messages.Remove(message);

            Console.WriteLine("Message removed");
        }

        public IEnumerable<Message> Read(Search search)
        {
            //more search filters to be implemented later
            return this._Messages.OrderByDescending(m => m.ID).Take(search.Size).Skip((search.Page - 1) * search.Size);
        }
    }
}
