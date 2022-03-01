using System;
using System.Collections.Generic;

namespace Observer.Core
{
    public class Observer< T, TK > 
        where T : IObserver< TK > 
        where TK : Enum
    {
        private Dictionary< TK, List< T > > _subject;

        public Observer()
        {
            _subject = new Dictionary< TK, List< T > >();
        }

        /// <summary>
        /// Subscribe event
        /// </summary>
        /// <param name="eventType">Target event type</param>
        /// <param name="receiver">Observer</param>
        public void Subscribe( TK eventType, T receiver )
        {
            // Check subject dictionary contains target event type or not
            if ( !_subject.ContainsKey( eventType ) )
                _subject.Add( eventType, new List< T >() );
            
            // Add receiver to the dictionary
            _subject[ eventType ].Add( receiver );
        }

        /// <summary>
        /// Unsubscribe event
        /// </summary>
        /// <param name="receiver">Observer</param>
        public void Unsubscribe( T receiver )
        {
            // Clean all receiver from dictionary
            foreach ( var kvp in _subject )
                kvp.Value.Remove( receiver );
        }

        /// <summary>
        /// Notify objects by a given event type
        /// </summary>
        /// <param name="eventType">Target event type</param>
        /// <param name="data">Optional data</param>
        public void Notify( TK eventType, object data )
        {
            if ( _subject.ContainsKey( eventType ) )
                _subject[ eventType ].ForEach( item => item.OnNotify( eventType, data ) );
        }
    }
}