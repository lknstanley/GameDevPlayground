using Games.FindThePatternsGame.Actions;
using Games.FindThePatternsGame.Managers;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Games.FindThePatternsGame
{
    public class FTPPlayer : MonoBehaviour
    {
        [ SerializeField ]
        private bool _canMove = true;

        [ SerializeField ]
        private Vector3 currentLocation;

        private void FixedUpdate()
        {
            if ( _canMove )
            {
                // Move up
                if ( Input.GetKey( KeyCode.UpArrow ) && CanMoveTo( Vector3.forward ) )
                    Move( Vector3.forward );
                // Move down
                if ( Input.GetKey( KeyCode.DownArrow ) && CanMoveTo( -Vector3.forward ) )
                    Move( -Vector3.forward );
                // Move left
                if ( Input.GetKey( KeyCode.LeftArrow ) && CanMoveTo( Vector3.left ) )
                    Move( Vector3.left );
                // Move right
                if ( Input.GetKey( KeyCode.RightArrow ) && CanMoveTo( Vector3.right ) )
                    Move( Vector3.right );
            }
        }

        /// <summary>
        ///     Move the player to the given direction
        /// </summary>
        /// <param name="dir"></param>
        private void Move( Vector3 dir )
        {
            SetCurrentLocation( new Vector3( currentLocation.x + dir.z, 0, currentLocation.z + dir.x ) );
            var moveCmd = new FTPCharacterMove( transform, dir, 1f, this );
            FTPGameManager.GetInstance().GetCommandManager().AddCommand( moveCmd );
        }

        /// <summary>
        ///     Check the target vector2 is walkable or not
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool CanMoveTo( Vector3 dir )
        {
            var tempVec2 = new Vector3( currentLocation.x + dir.z, 0, currentLocation.z + dir.x );
            var map = FTPGameManager.GetInstance().GetLevelManager().GetMap();
            if ( ( int ) tempVec2.x >= 0 && ( int ) tempVec2.x < map.Count &&
                 ( int ) tempVec2.z >= 0 && ( int ) tempVec2.z < map[ ( int ) tempVec2.x ].Count )
                return map[ ( int ) tempVec2.x ][ ( int ) tempVec2.z ] == 0;
            return false;
        }

        #region Interfaces

        /// <summary>
        ///     Set the player can move or not
        /// </summary>
        /// <param name="target"></param>
        public void SetCanMove( bool target )
        {
            _canMove = target;
        }

        /// <summary>
        ///     Set current location of the player
        /// </summary>
        /// <param name="location"></param>
        public void SetCurrentLocation( Vector3 location )
        {
            currentLocation = location;
            var idx = ( int ) location.x * FTPGameManager.GetInstance().GetLevelManager().GetMap().Count +
                      ( int ) location.z;
            var trans = FTPGameManager.GetInstance().GetLevelManager().GetRoadTransforms()[ idx ];
            if ( trans != null && trans.TryGetComponent( out FTPRoad road ) )
                road.ChangeColor( Color.green );
        }

        #endregion
    }
}