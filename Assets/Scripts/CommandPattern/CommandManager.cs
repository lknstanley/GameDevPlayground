using System.Collections.Generic;
using CommandPattern.Core;
using UnityEngine;

namespace CommandPattern
{
    public class CommandManager : MonoBehaviour
    {
        [ Header( "Command Histories" ) ]
        private readonly List< ICommand > _histories = new();

        private int _counter;

        private Queue< ICommand > _historiesBuffer;

        private void Awake()
        {
            _historiesBuffer = new Queue< ICommand >();
        }

        #region Interfaces

        /// <summary>
        ///     Add a command to the command manager
        /// </summary>
        /// <param name="cmd"></param>
        public void AddCommand( ICommand cmd )
        {
            // Call dispose for all commands after the current counter
            for ( var i = _counter; i < _histories.Count; i++ ) _histories[ i ].Dispose();

            // Remove all commands after the current counter when adding new command
            while ( _histories.Count > _counter )
                _histories.RemoveAt( _counter );

            // Add the command to the queue
            _historiesBuffer.Enqueue( cmd );

            // Transfer the command from the queue to the list, execute it and increment the counter
            while ( _historiesBuffer.Count > 0 )
            {
                var newCommand = _historiesBuffer.Dequeue();
                newCommand.Execute();
                _histories.Add( newCommand );
                _counter++;
            }
        }

        /// <summary>
        ///     Undo the last command
        /// </summary>
        public void Undo()
        {
            // Check current pointer is not at the beginning
            if ( _counter <= 0 ) return;

            // Decrement the counter and call undo
            _counter--;
            _histories[ _counter ].Undo();
        }

        /// <summary>
        ///     Redo the last command
        /// </summary>
        public void Redo()
        {
            // Check current pointer is not at the end
            if ( _counter >= _histories.Count ) return;

            // Call redo and increment the counter
            _histories[ _counter ].Execute();
            _counter++;
        }

        #endregion
    }
}