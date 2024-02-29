using CommandPattern.Core;
using Pixelplacement;
using UnityEngine;

namespace Games.FindThePatternsGame.Actions
{
    public class FTPCharacterMove : ICommand
    {
        private readonly Vector3 _dir;
        private readonly FTPPlayer _player;
        private readonly Transform _target;
        private float _dist;

        public FTPCharacterMove( Transform target, Vector3 dir, float dist, FTPPlayer player )
        {
            _target = target;
            _dir = dir;
            _dist = dist;
            _player = player;
            _player.SetCanMove( false );
        }

        public void Dispose()
        {
        }

        public void Execute()
        {
            var trans = _target;
            var localPosition = trans.localPosition;
            Tween.LocalPosition( trans, localPosition, localPosition + _dir * 1f,
                0.3f, 0, Tween.EaseInOutStrong, Tween.LoopType.None, () => { }, () => { _player.SetCanMove( true ); } );
        }

        public void Undo()
        {
            var trans = _target;
            var localPosition = trans.localPosition;
            Tween.LocalPosition( trans, localPosition, localPosition + -_dir * 1f,
                0.3f, 0, Tween.EaseInOutStrong, Tween.LoopType.None, () => { }, () => { _player.SetCanMove( true ); } );
        }
    }
}