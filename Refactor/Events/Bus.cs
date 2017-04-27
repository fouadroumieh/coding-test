using System.Collections.Generic;

namespace Refactor
{
    public class Bus
    {
        private static readonly IList<IHandler<IDomainEvent>> _handlers = new List<IHandler<IDomainEvent>>();
        public static void Register(IHandler<IDomainEvent> handler)
        {
            if (handler != null)
                _handlers.Add(handler);
        }

        public static void Raise<T>(T eventData) where T : IDomainEvent
        {
            foreach (var handler in _handlers)
            {
                if (handler.CanHandle(eventData))
                    handler.Handle(eventData);
            }
        }
    }
}