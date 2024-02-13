using Observer.Core;
using UnityEngine;
using EventHandler = Observer.Core.EventHandler;

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
            EventHandler.GetInstance().Subscribe( ObserverEventType.SucceedToUnlockedDoor, this );
            EventHandler.GetInstance().Subscribe( ObserverEventType.FailedToUnlockDoor, this );
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            EventHandler.GetInstance().Unsubscribe( ObserverEventType.SucceedToUnlockedDoor, this );
            EventHandler.GetInstance().Unsubscribe( ObserverEventType.FailedToUnlockDoor, this );
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