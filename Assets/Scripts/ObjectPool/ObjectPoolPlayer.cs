using UnityEngine;

namespace ObjectPool
{
    public class ObjectPoolPlayer : MonoBehaviour
    {

        [ Header( "Pool Manager" ) ]
        public ObjectPoolManager poolManager;

        // Update is called once per frame
        void Update()
        {
            // When the player presses SpaceBar
            if ( Input.GetKeyDown( KeyCode.Space ) )
            {
                SpawnAutoScaleCube();
            }
        }

        void SpawnAutoScaleCube()
        {
            PooledObject poolObject = poolManager.GetObjectFromPool();

            // Randomise the init position
            poolObject.transform.position = new Vector3( 
                Random.Range( -5.0f, 5.0f ), 
                2.0f,
                Random.Range( -5.0f, 5.0f ) );

            poolObject.Spawn();
        }
    }
}
