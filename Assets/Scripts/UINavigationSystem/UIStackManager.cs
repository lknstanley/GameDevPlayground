using UINavigationSystem.Core;
using UINavigationSystem.Core.Interface;
using UINavigationSystem.Core.Modal;
using UnityEngine;

namespace UINavigationSystem
{
    public class UIStackManager : MonoBehaviour, IUIController
    {
        [ SerializeField ]
        private UIViewController startScreen;

        [ SerializeField ]
        private Router router;

        private UIStackNavigation _stackNavigation;

        private void Awake()
        {
            // Initialize the stack navigation
            _stackNavigation = new UIStackNavigation();
        }

        private void Start()
        {
            // Assign navigator to all screens
            foreach ( var screen in router.screens ) screen.viewController.RegisterNavigator( this );

            // Get root from router
            var root = router.rootPath;
            // Find router from router with root path
            var target = router.screens.Find( r => r.path == root );
            startScreen = target.viewController;

            // Setup the start screen
            _stackNavigation.Push( transform, startScreen );
        }

        #region Navigator Interface

        public void Pop()
        {
            _stackNavigation.Pop();
        }

        public void Push( UIViewController viewController )
        {
            _stackNavigation.Push( transform, viewController );
        }

        public void Push( string path )
        {
            var target = router.screens.Find( r => r.path == path );
            var viewController = target.viewController;
            Push( viewController );
        }

        #endregion
    }
}