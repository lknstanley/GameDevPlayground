using Observer.Core;
using UnityEngine;

namespace Observer
{
    [ RequireComponent( typeof( MeshRenderer ) ) ]
    public class LockedDoor : Interactable, IObserver
    {
        [ Header( "Display Config" ) ]
        [ SerializeField ] private Color lockedColor;

        [ SerializeField ] private Color unlockedColor;

        [ SerializeField ] private Material _lockedMaterial;

        private bool isLocked;

        protected override void Awake()
        {
            base.Awake();
            _lockedMaterial = GetComponent< MeshRenderer >().material;
        }

        protected override void Start()
        {
            base.Start();
            ObserverEventHandler.GetInstance().Subscribe( ObserverEventType.SucceedToUnlockedDoor, this );
            ObserverEventHandler.GetInstance().Subscribe( ObserverEventType.FailedToUnlockDoor, this );
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            ObserverEventHandler.GetInstance().Unsubscribe( ObserverEventType.SucceedToUnlockedDoor, this );
            ObserverEventHandler.GetInstance().Unsubscribe( ObserverEventType.FailedToUnlockDoor, this );
        }

        public void OnNotify( ObserverEventType eventType, object data )
        {
            switch ( eventType )
            {
                case ObserverEventType.SucceedToUnlockedDoor:
                    _lockedMaterial.color = unlockedColor;
                    break;
                case ObserverEventType.FailedToUnlockDoor:
                    _lockedMaterial.color = lockedColor;
                    break;
            }
        }
    }
}