using UINavigationSystem.Core;

namespace UINavigationSystem
{
    public class UINavSysSettingsScreen : UIViewController
    {
        public void OnBackButtonClicked()
        {
            Navigator.Pop();
        }
    }
}