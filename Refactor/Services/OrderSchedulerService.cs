using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor.Entities;

namespace Refactor
{
    public class OrderSchedulerService : IOrderSchedulerService
    {
        public void ScheduleOrderForDelivery(Order order)
        {
            if (!order.Statuses.Any(x => new[] {OrderStatus.InStock}.Any()))
            {
                order.Statuses.Add(OrderStatus.ScheduledForDelivery);
            }
        }
    }
}
