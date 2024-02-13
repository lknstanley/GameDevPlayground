using CommandPattern.Core;
using UnityEngine;

namespace CommandPattern.Actions
{
    public class MoveCommand : ICommand
    {
        private readonly Vector3 _dir;
        private readonly float _distance;
        private readonly Space _space;
        private readonly Transform _target;

        public MoveCommand( Transform trans, Vector3 dir, float distance, Space space )
        {
            _target = trans;
            _dir = dir;
            _distance = distance;
            _space = space;
        }

        public void Dispose()
        {
        }

        public void Execute()
        {
            _target.Translate( _dir * _distance, _space );
        }

        public void Undo()
        {
            _target.Translate( -_dir * _distance, _space );
        }
    }
}