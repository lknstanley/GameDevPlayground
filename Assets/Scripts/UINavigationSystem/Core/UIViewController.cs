using System.Threading.Tasks;
using UINavigationSystem.Core.Interface;
using UnityEngine;

namespace UINavigationSystem.Core
{
    public class UIViewController : MonoBehaviour, IUIEvent
    {
        #region Unity Lifecycle

        protected virtual void OnEnable()
        {
            // Enable the view controller
        }

        protected virtual void Awake()
        {
            // Initialize the view controller
        }

        protected virtual void Start()
        {
            // Start the view controller
        }

        protected virtual void OnDestroy()
        {
            // Destroy the view controller
        }

        #endregion

        #region UI Lifecycle

        public async Task OnLoad()
        {
            // UI Event OnLoad
        }

        public async Task PostLoad()
        {
            // UI Event PostLoad
        }

        public async Task OnDisplay()
        {
            // UI Event OnDisplay
        }

        public async Task PostDisplay()
        {
            // UI Event PostDisplay
        }

        public async Task OnPop()
        {
            // UI Event OnPop
        }

        #endregion
    }
}