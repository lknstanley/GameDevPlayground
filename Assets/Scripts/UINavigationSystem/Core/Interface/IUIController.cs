namespace UINavigationSystem.Core.Interface
{
    public interface IUIController
    {
        public void Push( UIViewController viewController );
        public void Push( string path );
        public void Pop();
    }
}