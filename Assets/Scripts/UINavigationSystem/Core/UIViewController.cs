using System.Threading.Tasks;
using Pixelplacement;
using UINavigationSystem.Core.Interface;
using UnityEngine;

namespace UINavigationSystem.Core
{
    [ RequireComponent( typeof( CanvasGroup ) ) ]
    public class UIViewController : MonoBehaviour, IUIEvent
    {
        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;

        protected IUIController Navigator;

        #region Unity Lifecycle

        protected virtual void OnEnable()
        {
            // Enable the view controller
            if ( _canvasGroup == null ) _canvasGroup = GetComponent< CanvasGroup >();
            if ( _rectTransform == null ) _rectTransform = GetComponent< RectTransform >();
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

        public void RegisterNavigator( IUIController navigator )
        {
            Navigator = navigator;
        }

        public virtual async Task OnLoad()
        {
            // UI Event OnLoad
            gameObject.SetActive( true );
            transform.SetAsLastSibling();

            // Animations
            var delay = 0f;
            Tween.CanvasGroupAlpha( _canvasGroup, 0, 1, 0.3f, delay, Tween.EaseInOut );
            delay += 0.3f;

            // Wait for animations to complete
            await Task.Delay( ( int ) ( delay * 1000 ) );
        }

        public virtual async Task PostLoad()
        {
            // UI Event PostLoad
        }

        public virtual async Task OnDisplay()
        {
            // UI Event OnDisplay
        }

        public virtual async Task PostDisplay()
        {
            // UI Event PostDisplay
        }

        public virtual async Task OnPop()
        {
            // Animations
            var delay = 0f;
            Tween.CanvasGroupAlpha( _canvasGroup, 1, 0, 0.3f, delay, Tween.EaseInOut );
            delay += 0.3f;
            await Task.Delay( ( int ) ( delay * 1000 ) );

            // UI Event OnPop
            gameObject.SetActive( false );
        }

        #endregion
    }
}