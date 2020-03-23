using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{

    private float currentTimeLeft = 0.0f;

    [Header( "Pool Object Settings" )]
    public float lifeTime = 3.0f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // By default, this pooled object should be deactive
        gameObject.SetActive( false );
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // Calculate how long this object will last
        if( gameObject.activeSelf )
        {
            // Calculate the time left
            currentTimeLeft -= Time.deltaTime;

            // When the timer is less than zero, this object is going to deactivate
            if( currentTimeLeft <= 0.0f )
            {
                gameObject.SetActive( false );
            }
        }
    }

    public virtual void Spawn()
    {
        // Set the time left to the life time
        currentTimeLeft = lifeTime;
        // Show the object to the screen
        gameObject.SetActive( true );
    }

    public virtual void Despawn()
    {
        // Force set the time left to zero, in case the life time is not finish
        currentTimeLeft = 0.0f;
        // Hide this object from screen
        gameObject.SetActive( false );
    }
}
