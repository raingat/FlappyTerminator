using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField] private ObjectPool<Bullet> _pool;

    public void Spawn(Vector2 position, Quaternion angle)
    {
        Bullet instance = _pool.GetObject(position, angle);

        instance.Dash += ReturnToPool;
    }

    private void ReturnToPool(Bullet instance)
    {
        _pool.ReturnObject(instance);

        instance.Dash -= ReturnToPool;
    }
}
