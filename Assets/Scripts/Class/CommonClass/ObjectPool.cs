using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private Queue<T> _pool = new Queue<T>();

    public T GetObject(Vector2 position, Quaternion angle)
    {
        if (_pool.Count == 0)
            Expend();

        T instance = _pool.Dequeue();
        instance.gameObject.SetActive(true);

        instance.transform.position = position;
        instance.transform.rotation = angle;

        return instance;
    }

    public T GetObject(Vector2 position)
    {
        if (_pool.Count == 0)
            Expend();

        T instance = _pool.Dequeue();
        instance.gameObject.SetActive(true);

        instance.transform.position = position;

        return instance;
    }

    public void ReturnObject(T instance)
    {
        instance.gameObject.SetActive(false);

        _pool.Enqueue(instance);
    }

    private void Expend()
    {
        T instance = Instantiate(_prefab);

        _pool.Enqueue(instance);
    }
}
