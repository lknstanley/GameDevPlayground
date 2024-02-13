namespace Observer.Core
{
    public interface IObserver
    {
        void OnNotify( ObserverEventType eventType, object data );
    }
}