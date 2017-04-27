namespace Refactor
{
    public class OrderShippingHandler : IHandler<IDomainEvent>
    {
        public void Handle(IDomainEvent eventData)
        {
            var obj = eventData as OrderShippingEvent;
            if(obj != null)
            {
                //Send email
                //EmailUtility.SendEmail(obj.Order.EmailAddress, "Order to be shipped", "Order to be shipped");
            }
            return;
        }

        public bool CanHandle(IDomainEvent eventType)
        {
            return eventType is OrderShippingEvent;
        }
    }
}