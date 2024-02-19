using System.Threading.Tasks;
using Observer.Core;
using UnityEngine;

namespace Observer
{
    public class ObserverPlayer : MonoBehaviour, IObserver
    {
        [ SerializeField ] private Transform itemSocket;
        private Interactable _curInteractable;
        private bool _hasKey;
        private bool _isInteractionCooldown;

        private void Start()
        {
            ObserverEventHandler.GetInstance().Subscribe( ObserverEventType.Interacted, this );
            ObserverEventHandler.GetInstance().Subscribe( ObserverEventType.ReachInteractable, this );
            ObserverEventHandler.GetInstance().Subscribe( ObserverEventType.LeaveInteractable, this );
            ObserverEventHandler.GetInstance().Subscribe( ObserverEventType.UnlockDoor, this );
        }

        private void Update()
        {
            if ( !_isInteractionCooldown && _curInteractable != null && Input.GetKey( KeyCode.E ) ) DelayedInteract();
        }

        private void OnDestroy()
        {
            ObserverEventHandler.GetInstance().Unsubscribe( ObserverEventType.Interacted, this );
            ObserverEventHandler.GetInstance().Unsubscribe( ObserverEventType.ReachInteractable, this );
            ObserverEventHandler.GetInstance().Unsubscribe( ObserverEventType.LeaveInteractable, this );
            ObserverEventHandler.GetInstance().Unsubscribe( ObserverEventType.UnlockDoor, this );
        }

        public void OnNotify( ObserverEventType eventType, object data )
        {
            Debug.Log( $"[{gameObject.name}] OnNotify Triggered - {eventType.ToString()}" );
            switch ( eventType )
            {
                case ObserverEventType.Interacted:
                    HandleInteractable( data );
                    break;
                case ObserverEventType.ReachInteractable:
                    SetPotentialInteractable( data );
                    break;
                case ObserverEventType.LeaveInteractable:
                    _curInteractable = null;
                    break;
                case ObserverEventType.UnlockDoor:
                    break;
            }
        }

        private async void DelayedInteract()
        {
            _curInteractable.Interact();
            _isInteractionCooldown = true;
            await Task.Delay( 1000 );
            _isInteractionCooldown = false;
        }

        private void SetPotentialInteractable( object data )
        {
            if ( data is GameObject go ) _curInteractable = go.GetComponent< Interactable >();
        }

        private void HandleInteractable( object data )
        {
            if ( data is GameObject go && go.TryGetComponent( out Interactable interactable ) )
                // Do different logic based on the interactable type
                switch ( interactable.GetInteractableType() )
                {
                    case InteractableType.Key:
                        go.transform.SetParent( itemSocket );
                        go.transform.localPosition = Vector3.zero;
                        go.transform.localScale = Vector3.one;
                        _hasKey = true;

                        // Clean current interactable pointer
                        _curInteractable = null;
                        break;
                    case InteractableType.Door:
                        if ( _hasKey )
                            ObserverEventHandler.GetInstance().Notify( ObserverEventType.SucceedToUnlockedDoor, null );
                        else
                            ObserverEventHandler.GetInstance().Notify( ObserverEventType.FailedToUnlockDoor, null );
                        break;
                }
        }
    }
}