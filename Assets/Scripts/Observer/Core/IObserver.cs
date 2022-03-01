using System;
namespace Observer.Core
{
    public interface IObserver< in TK > where TK : Enum
    {
        void OnNotify( TK eventType, object data );
    }
}