using CommandPattern.Actions;
using UnityEngine;

namespace CommandPattern
{
    public class RemoteTarget : MonoBehaviour
    {
        [ SerializeField ] private CommandManager _commandManager;

        public void OnRequestMoveUp()
        {
            var cmd = new MoveCommand( transform, transform.forward, 1f, Space.Self );
            _commandManager.AddCommand( cmd );
        }

        public void OnRequestMoveDown()
        {
            var cmd = new MoveCommand( transform, -transform.forward, 1f, Space.Self );
            _commandManager.AddCommand( cmd );
        }

        public void OnRequestMoveLeft()
        {
            var cmd = new MoveCommand( transform, transform.right, 1f, Space.Self );
            _commandManager.AddCommand( cmd );
        }

        public void OnRequestMoveRight()
        {
            var cmd = new MoveCommand( transform, -transform.right, 1f, Space.Self );
            _commandManager.AddCommand( cmd );
        }
    }
}