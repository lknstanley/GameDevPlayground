using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Games.FindThePatternsGame.Managers
{
    public class FTPLevelManager : MonoBehaviour, IManagerEvent< FTPLevelManager >
    {
        [ SerializeField ]
        private int initialMapSize = 4;

        [ SerializeField ]
        private int level;

        [ SerializeField ]
        private GameObject roadTemplate;

        private List< List< int > > _map;

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
            FTPRoadFactory.PopulateRoadMap( _map, roadTemplate, transform );
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

        #endregion
    }
}