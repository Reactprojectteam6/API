using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
using final_project.Services;

namespace final_project.Services
{
    public class ReceiverService : IReceiverService
    {     private DataContext  _context;
       public ReceiverService(DataContext context)
       {  _context=context;

       }
        public Receiver AddReceiver(Receiver receiver)
        {    int max=1;
            var s=_context.Receivers.Select(p=>p.id);
             foreach(var i in s)
             { if(max<int.Parse(i)) max=int.Parse(i);

             }
             receiver.id=(max+1).ToString();
             _context.Receivers.Add(receiver);
             _context.SaveChanges();
             return receiver;
        }
    }
}