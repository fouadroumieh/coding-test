using Refactor.Entities;

namespace Refactor
{
    public class OrderShippingEvent : IDomainEvent
    {
        public Order Order { get; set; }
    }
}