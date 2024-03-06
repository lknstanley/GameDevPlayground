using System.Collections.Generic;
using System.Threading.Tasks;
using Games.FindThePatternsGame.Constraints;
using UnityEngine;

namespace Games.FindThePatternsGame.Managers
{
    public class FTPLevelManager : MonoBehaviour, IManagerEvent< FTPLevelManager >
    {
        [ SerializeField ]
        private int initialMapSize = 10;

        [ SerializeField ]
        private int level;

        [ SerializeField ]
        private GameObject roadTemplate;

        [ SerializeField ]
        private GameObject playerTemplate;

        private List< List< int > > _map;
        private List< Transform > _roadTransforms;

        #region Unity Lifecycles

        private void Awake()
        {
        }

        #endregion

        public FTPLevelManager GetInstance()
        {
            return this;
        }

        public async Task LoadAsset()
        {
            Debug.Log( $"[{gameObject.name}] Start Preparing Assets" );
            await Task.Delay( 1000 );
        }

        #region Internal

        private void GenerateMap()
        {
            FTPRoadFactory.ShuffleRoadMap( initialMapSize, initialMapSize, out _map );
            FTPRoadFactory.PopulateRoadMap( _map, roadTemplate, transform, out _roadTransforms );

            // Find the entrance and instantiate the player
            var entrance =
                _roadTransforms.Find( r => r.GetComponent< FTPRoad >().GetRoadType() == FTPRoadType.Entrance );

            // Get the entrance location in vector 3
            var entranceVec2 = Vector2.zero;
            for ( var i = 0; i < _map.Count; i++ )
            for ( var j = 0; j < _map[ i ].Count; j++ )
                if ( _map[ i ][ j ] == 2 )
                {
                    entranceVec2 = new Vector3( i, 0, j );
                    break;
                }

            // Instantiate the player
            var player = Instantiate( playerTemplate, entrance.position + Vector3.up * 1, Quaternion.identity );
            player.GetComponent< FTPPlayer >().SetCurrentLocation( entranceVec2 );

            // Move camera to the center of the map by getting transform from the road transforms
            var center = _roadTransforms[ initialMapSize / 2 * initialMapSize + initialMapSize / 2 ];
            var cam = Camera.main;
            cam.transform.position = center.position + Vector3.up * 10f;
        }

        #endregion

        #region Interfaces

        /// <summary>
        ///     Kickstart the game
        /// </summary>
        public void StartGame()
        {
            GenerateMap();
        }

        /// <summary>
        ///     Get current level
        /// </summary>
        /// <returns></returns>
        public int GetCurrentLevel()
        {
            return level;
        }

        /// <summary>
        ///     Increase the level when the player reaches the goal
        /// </summary>
        public void LevelUp()
        {
            level++;
            GenerateMap();
        }

        /// <summary>
        ///     Get the map data
        /// </summary>
        /// <returns></returns>
        public List< List< int > > GetMap()
        {
            return _map;
        }

        /// <summary>
        ///     Get the road transforms
        /// </summary>
        /// <returns></returns>
        public List< Transform > GetRoadTransforms()
        {
            return _roadTransforms;
        }

        #endregion
    }
}