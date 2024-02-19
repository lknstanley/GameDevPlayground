using CommandPattern.Core;
using UnityEngine;

namespace Games.FindThePatternsGame.Actions
{
    public class FTPCharacterMove : ICommand
    {
        private Vector3 _dir;
        private float _dist;
        private Transform _target;

        public FTPCharacterMove( Transform target, Vector3 dir, float dist )
        {
            _target = target;
            _dir = dir;
            _dist = dist;
        }

        public void Dispose()
        {
        }

        public void Execute()
        {
        }

        public void Undo()
        {
        }
    }
}