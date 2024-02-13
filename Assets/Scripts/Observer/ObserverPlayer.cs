using Observer.Core;
using UnityEngine;

namespace Observer
{
    public class ObserverPlayer : MonoBehaviour, IObserver
    {
        [ SerializeField ] private Transform itemSocket;
        [ SerializeField ] private bool hasItem;

        private void Start()
        {
            EventHandler.GetInstance().Subscribe( ObserverEventType.PickupItem, this );
        }

        public void OnNotify( ObserverEventType eventType, object data )
        {
            Debug.Log( $"[{gameObject.name}] OnNotify Triggered - {eventType.ToString()}" );
            switch ( eventType )
            {
                case ObserverEventType.PickupItem:
                    PickupItem( data );
                    break;
            }
        }

        private void PickupItem( object data )
        {
            if ( data is GameObject go )
            {
                go.transform.SetParent( itemSocket );
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = Vector3.one;

                hasItem = true;
            }
        }
    }
}