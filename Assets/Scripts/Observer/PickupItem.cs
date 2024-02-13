using Observer.Core;
using EventHandler = Observer.Core.EventHandler;

namespace Observer
{
    public class PickupItem : Interactable, IObserver
    {
        protected override void Start()
        {
            base.Start();
            EventHandler.GetInstance().Subscribe( ObserverEventType.SucceedToUnlockedDoor, this );
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            EventHandler.GetInstance().Unsubscribe( ObserverEventType.SucceedToUnlockedDoor, this );
        }

        public void OnNotify( ObserverEventType eventType, object data )
        {
            switch ( eventType )
            {
                case ObserverEventType.SucceedToUnlockedDoor:
                    Destroy( gameObject );
                    break;
            }
        }

        public override void Interact()
        {
            base.Interact();
            EventHandler.GetInstance().Notify( ObserverEventType.Interacted, gameObject );
            InteractableCollider.enabled = false;
        }
    }
}