using Games.FindThePatternsGame.Actions;
using Games.FindThePatternsGame.Managers;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Games.FindThePatternsGame
{
    public class FTPPlayer : MonoBehaviour
    {
        private bool _canMove = true;

        private void Update()
        {
            if ( _canMove && Input.GetKey( KeyCode.UpArrow ) ) Move( Vector3.forward );
            if ( _canMove && Input.GetKey( KeyCode.DownArrow ) ) Move( -Vector3.forward );
            if ( _canMove && Input.GetKey( KeyCode.LeftArrow ) ) Move( Vector3.left );
            if ( _canMove && Input.GetKey( KeyCode.RightArrow ) ) Move( Vector3.right );
        }

        private void Move( Vector3 dir )
        {
            var moveCmd = new FTPCharacterMove( transform, dir, 1f, this );
            FTPGameManager.GetInstance().GetCommandManager().AddCommand( moveCmd );
        }

        #region Interfaces

        public void SetCanMove( bool target )
        {
            _canMove = target;
        }

        #endregion
    }
}