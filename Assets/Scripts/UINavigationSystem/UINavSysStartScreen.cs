using UINavigationSystem.Core;

namespace UINavigationSystem
{
    public class UINavSysStartScreen : UIViewController
    {
        #region Event Hanlders

        public void OnSettingsButtonClicked()
        {
            Navigator.Push( "Settings" );
        }

        public void OnFriendListButtonClicked()
        {
            Navigator.Push( "FriendList" );
        }

        #endregion
    }
}