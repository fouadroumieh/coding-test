namespace Refactor
{
    public interface IHandler<T>
    {
        bool CanHandle(IDomainEvent eventType);
        void Handle(IDomainEvent eventData);
    }
}