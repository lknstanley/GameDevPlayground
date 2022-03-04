using System;
using Observer.Core;
using UnityEngine;

namespace Observer
{
    public class PickupItem : MonoBehaviour
    {
        private void OnCollisionEnter( Collision collision )
        {
            Debug.Log( $"{collision.collider.gameObject.name} collides with me!" );
        }
    }
}