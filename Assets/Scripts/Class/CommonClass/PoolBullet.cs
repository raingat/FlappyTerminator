using System.Collections.Generic;
using UnityEngine;

public class PoolBullet : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;

    private Queue<Bullet> _pool = new Queue<Bullet>();

    public Bullet GetObject(Vector2 position, Quaternion angle)
    {
        if (_pool.Count == 0)
            Expend();

        Bullet instance = _pool.Dequeue();
        instance.gameObject.SetActive(true);

        instance.transform.position = position;
        instance.transform.rotation = angle;

        return instance;
    }

    public void ReturnObject(Bullet instance)
    {
        instance.gameObject.SetActive(false);

        _pool.Enqueue(instance);
    }

    private void Expend()
    {
        Bullet instance = Instantiate(_prefab);

        _pool.Enqueue(instance);
    }
}
