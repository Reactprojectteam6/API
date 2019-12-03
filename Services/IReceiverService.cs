using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;

namespace final_project.Services
{
    public interface IReceiverService
    { 
      
      public Receiver AddReceiver(Receiver receiver);
    }
}