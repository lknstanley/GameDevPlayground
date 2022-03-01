namespace ObjectPool.Core
{
    public interface IPoolable
    {
        void Spawn();
        void Despawn();
    }
}