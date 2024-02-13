using Observer.Core;
using UnityEngine;
using EventHandler = Observer.Core.EventHandler;

namespace Observer
{
    public class PickupItem : MonoBehaviour
    {
        private BoxCollider _collider;

        private void Start()
        {
            _collider = GetComponent< BoxCollider >();
        }

        private void OnTriggerEnter( Collider other )
        {
            Debug.Log( $"{other.gameObject.name} collides with me!" );
            EventHandler.GetInstance().Notify( ObserverEventType.PickupItem, gameObject );
            _collider.enabled = false;
        }

        public void Use()
        {
            transform.SetParent( null );
        }
    }
}