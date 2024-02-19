using System.Collections.Generic;
using UnityEngine;

namespace Observer.Core
{
    public class ObserverEventHandler : MonoBehaviour
    {
        private static ObserverEventHandler _instance;
        private readonly Dictionary< ObserverEventType, List< IObserver > > _observers = new();

        private void Awake()
        {
            if ( _instance == null )
                _instance = this;
            else
                Destroy( gameObject );
        }

        public static ObserverEventHandler GetInstance()
        {
            if ( _instance == null )
                _instance = new GameObject( "EventHandler" ).AddComponent< ObserverEventHandler >();
            return _instance;
        }

        public void Subscribe( ObserverEventType eventType, IObserver observer )
        {
            if ( !_observers.ContainsKey( eventType ) )
                _observers.Add( eventType, new List< IObserver >() );
            _observers[ eventType ].Add( observer );
        }

        public void Unsubscribe( ObserverEventType eventType, IObserver observer )
        {
            if ( _observers.TryGetValue( eventType, out var listOfTargetedObservers ) )
                listOfTargetedObservers.Remove( observer );
        }

        public void Notify( ObserverEventType eventType, object data )
        {
            // loop through all observers and find the correct one
            if ( _observers.TryGetValue( eventType, out var observers ) )
                foreach ( var observer in observers )
                    observer.OnNotify( eventType, data );
        }
    }
}