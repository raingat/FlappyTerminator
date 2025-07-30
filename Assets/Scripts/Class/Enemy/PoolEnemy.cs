using System.Collections.Generic;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;

    private Queue<Enemy> _pool = new Queue<Enemy>();

    public Enemy GetObject(Vector2 position)
    {
        if (_pool.Count == 0)
            Expend();

        Enemy instance = _pool.Dequeue();
        instance.gameObject.SetActive(true);

        instance.transform.position = position;

        return instance;
    }

    public void ReturnObject(Enemy instance)
    {
        instance.gameObject.SetActive(false);

        _pool.Enqueue(instance);
    }

    private void Expend()
    {
        Enemy instance = Instantiate(_prefab);

        _pool.Enqueue(instance);
    }
}
