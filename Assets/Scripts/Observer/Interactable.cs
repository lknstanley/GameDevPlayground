using Observer.Core;
using UnityEngine;

namespace Observer
{
    [ RequireComponent( typeof( SphereCollider ) ) ]
    public class Interactable : MonoBehaviour
    {
        [ Header( "Config" ) ]
        [ SerializeField ]
        private string targetTag = "Player";

        [ SerializeField ]
        private InteractableType interactableType = InteractableType.Key;

        protected SphereCollider InteractableCollider;

        protected virtual void Awake()
        {
            InteractableCollider = GetComponent< SphereCollider >();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
        }

        protected virtual void OnDestroy()
        {
        }

        protected virtual void OnTriggerEnter( Collider other )
        {
            if ( other.CompareTag( targetTag ) )
                ObserverEventHandler.GetInstance().Notify( ObserverEventType.ReachInteractable, gameObject );
        }

        protected void OnTriggerExit( Collider other )
        {
            if ( other.CompareTag( targetTag ) )
                ObserverEventHandler.GetInstance().Notify( ObserverEventType.LeaveInteractable, gameObject );
        }

        public InteractableType GetInteractableType()
        {
            return interactableType;
        }

        public virtual void Interact()
        {
            Debug.Log( $"[{gameObject.name}] - Someone is interacting with me." );
            ObserverEventHandler.GetInstance().Notify( ObserverEventType.Interacted, gameObject );
        }
    }
}