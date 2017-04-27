using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor.Entities;

namespace Refactor
{
    public class ShippingService : IShippingService
    {

        public void ShipOrder(Order order)
        {
            order.Statuses.Add(OrderStatus.EnRoute);
            RaiseOrderShippingEvent(order);
        }
        private void RaiseOrderShippingEvent(Order order)
        {
            //Register Handler and raise the OrderShippingEvent
            Bus.Register(new OrderShippingHandler());
            var orderShippingEvent = new OrderShippingEvent();
            orderShippingEvent.Order = order;
            Bus.Raise(orderShippingEvent);
        }
        public void ConfirmDelivery(Order order)
        {
            order.Statuses.Add(OrderStatus.Delivered);
        }

       
    }
}
