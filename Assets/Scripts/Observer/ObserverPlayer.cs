using Observer.Core;
using UnityEngine;
using EventType = Observer.Core.EventType;

namespace Observer
{
    public class ObserverPlayer : MonoBehaviour, IObserver< EventType >
    {
        private Observer< ObserverPlayer, EventType > _observer;

        public void OnNotify( EventType eventType, object data )
        {
            Debug.Log( $"[{gameObject.name}] OnNotify Triggered - {eventType.ToString()}" );
        }
    }
}