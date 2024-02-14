using System.Collections.Generic;
using UINavigationSystem.Core.Interface;

namespace UINavigationSystem.Core
{
    public class UIStackNavigation
    {
        private readonly Stack< IUIEvent > _viewControllerStack;

        public UIStackNavigation()
        {
            _viewControllerStack = new Stack< IUIEvent >();
        }

        public async void Push( IUIEvent viewController )
        {
            // Call the UI lifecycle events
            await viewController.OnLoad();
            await viewController.PostLoad();
            await viewController.OnDisplay();
            await viewController.PostDisplay();

            // Push the view controller to the stack
            _viewControllerStack.Push( viewController );
        }

        public async void Pop()
        {
            // Check stack has at least two view controller
            if ( _viewControllerStack.Count <= 1 ) return;

            // Pop the view controller from the stack
            var poppedView = _viewControllerStack.Pop();
            await poppedView.OnPop();

            // Display the last UI view
            var lastView = _viewControllerStack.Peek();
            await lastView.OnLoad();
            await lastView.PostLoad();
            await lastView.OnDisplay();
            await lastView.PostDisplay();
        }
    }
}