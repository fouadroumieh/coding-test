using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor.Entities;

namespace Refactor
{
    public interface IOrderSchedulerService
    {
        void ScheduleOrderForDelivery(Order order);
        
    }
}
