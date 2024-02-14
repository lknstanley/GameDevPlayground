using UINavigationSystem.Core;

namespace UINavigationSystem
{
    public class UINavSysFriendListScreen : UIViewController
    {
        public void OnBackClicked()
        {
            Navigator.Pop();
        }
    }
}