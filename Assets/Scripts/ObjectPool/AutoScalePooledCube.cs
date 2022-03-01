using UnityEngine;

namespace ObjectPool
{
    public class AutoScalePooledCube : PooledObject
    {
        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        
            if( gameObject.activeSelf )
            {
                transform.localScale = transform.localScale * Mathf.Sin( Time.deltaTime + 2 );
            }

        }

        public override void Spawn()
        {
            base.Spawn();
        }

        public override void Despawn()
        {
            base.Despawn();
            // Reset the position and scale once the pool object is going to despawn
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.localScale = Vector3.one;
        }
    }
}
