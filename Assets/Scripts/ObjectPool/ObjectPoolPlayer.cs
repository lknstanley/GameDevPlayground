using UnityEngine;

public class ObjectPoolPlayer : MonoBehaviour
{

    [Header( "Pool Manager" )]
    public ObjectPoolManager poolManager;

    // Update is called once per frame
    void Update()
    {
        // When the player presses SpaceBar
        if( Input.GetKeyUp( KeyCode.Space ) )
        {
            SpawnAutoScaleCube();
        }
    }

    void SpawnAutoScaleCube()
    {
        PooledObject poolObject = poolManager.GetObjectFromPool();

        // Randomise the init position
        poolObject.transform.position = new Vector3( UnityEngine.Random.Range( -5.0f, 5.0f ), 2.0f, UnityEngine.Random.Range( -5.0f, 5.0f ) );

        poolObject.Spawn();
    }
}
