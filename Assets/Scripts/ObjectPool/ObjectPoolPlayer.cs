using UnityEngine;
using ObjectPool.Core;
using Random = UnityEngine.Random;

namespace ObjectPool
{
    public class ObjectPoolPlayer : MonoBehaviour
    {

        [ Header( "Pool Manager" ) ]
        public Transform poolsObjectContainer;
        public ObjectPool< AutoScalePooledCube > MyPool;
        public AutoScalePooledCube autoScaleCubeTemplate;

        private void Awake()
        {
            MyPool = new ObjectPool< AutoScalePooledCube >(
                5,
                autoScaleCubeTemplate,
                ( item, index ) =>
                {
                    item.gameObject.transform.SetParent( poolsObjectContainer );
                } );
        }

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
            // Get from pool
            AutoScalePooledCube cube = MyPool.GetObjectFromPool();
            
            // Reset
            cube.Despawn();
            
            // Set initial value
            cube.transform.position = new Vector3( 
                Random.Range( -5.0f, 5.0f ), 
                2.0f,
                Random.Range( -5.0f, 5.0f ) );
            
            // Spawn again
            cube.Spawn();
        }
    }
}
