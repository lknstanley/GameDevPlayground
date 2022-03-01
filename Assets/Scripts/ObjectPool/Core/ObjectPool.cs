using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool.Core
{
    public class ObjectPool< T > where T : IPoolable
    {
        private T[] _pools;
        private int _poolSize;
        private int _cursor;
        
        public ObjectPool( int poolSize, T template, Action<T, int> onCreateInstance )
        {
            _poolSize = poolSize;
            _pools = new T[ _poolSize ];
            
            // initialise pool and fill with instance of template
            for ( int i = 0; i < _poolSize; i++ )
            {
                // Force instantiate object with interface
                // https://answers.unity.com/questions/1181330/instantiating-an-object-from-its-interface.html
                IPoolable pooledObject = Object.Instantiate(
                    ( ( UnityEngine.Object ) ( object ) template ) ) as IPoolable;

                // Check the cloned object is not null
                if ( pooledObject == null )
                {
                    Debug.LogError( "[ObjectPoolManager] Failed to create instance of poolable" );
                    return;
                }

                // Store instance to pool list
                _pools[ i ] = ( T ) pooledObject;

                // Trigger onCreateInstance event
                onCreateInstance( _pools[ i ], i );
            }
        }

        #region Interface

        public T GetObjectFromPool()
        {
            // Get object from pool
            T target = _pools[ _cursor ];
            // Increase cursor
            _cursor++;
            // Clamp cursor within pool size
            if ( _cursor >= _poolSize ) _cursor = 0;
            return target;
        }

        #endregion
    }
}