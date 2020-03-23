using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    [Header( "Pool Settings" )]
    public PooledObject template;
    public int poolSize = 50;
    public List<PooledObject> pooledObjectList;
    public int cursorIndex = 0;

    [Header( "Debug Usage" )]
    public Transform defaultParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Init pool
        for( int i = 0; i < poolSize; i++ )
        {
            PooledObject pooledObject = Instantiate<PooledObject>( template, defaultParentTransform );
            // Ensure that the init position is zero
            pooledObject.transform.position = Vector3.zero;
            // Add to the pooled list
            pooledObjectList.Add( pooledObject );
        }
    }

    public PooledObject GetObjectFromPool()
    {
        // Ensure that we are not going to break the size of the array
        if( cursorIndex + 1 >= pooledObjectList.Count )
        {
            // If the cursor is pointing outside of the list, change it to point to the first item
            cursorIndex = 0;
        }

        // Get reference from the item
        PooledObject target = pooledObjectList[ cursorIndex ];

        // If this pool object is on screen, force to kill it from the screen first
        if( target.gameObject.activeSelf )
        {
            target.Despawn();
        }

        // Increase the cursor
        cursorIndex++;
        return target;
    }

}
