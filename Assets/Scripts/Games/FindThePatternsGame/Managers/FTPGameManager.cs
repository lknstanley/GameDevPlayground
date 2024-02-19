using CommandPattern;
using Observer.Core;
using UnityEngine;

namespace Games.FindThePatternsGame.Managers
{
    public class FTPGameManager : MonoBehaviour
    {
        #region References

        [ SerializeField ] private FTPUIManager _uiManager;

        public FTPUIManager GetUIManager()
        {
            return _uiManager;
        }

        [ SerializeField ] private CommandManager _commandManager;

        public CommandManager GetCommandManager()
        {
            return _commandManager;
        }

        [ SerializeField ] private ObserverEventHandler _eventManager;

        public ObserverEventHandler GetEventManager()
        {
            return _eventManager;
        }

        [ SerializeField ] private FTPLevelManager _levelManager;

        public FTPLevelManager GetLevelManager()
        {
            return _levelManager;
        }

        #endregion

        #region Singleton

        private static FTPGameManager _instance;

        public static FTPGameManager GetInstance()
        {
            return _instance;
        }

        private void Awake()
        {
            if ( _instance == null )
                _instance = this;
            else
                Destroy( gameObject );
        }

        #endregion

        #region Entry Point

        private void Start()
        {
            InitialiseAll();
        }

        private async void InitialiseAll()
        {
            // Start loading assets from all managers
            await _uiManager.LoadAsset();
            await _commandManager.LoadAsset();
            await _eventManager.LoadAsset();
            await _levelManager.LoadAsset();

            // Kickstart the game after finish all loading
            _levelManager.GetInstance().StartGame();
        }

        #endregion
    }
}