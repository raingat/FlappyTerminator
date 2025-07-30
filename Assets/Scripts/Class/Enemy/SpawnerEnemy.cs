using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private PoolEnemy _pool;

    [SerializeField] private float _waitTime;

    [SerializeField] private float _maxCount;

    [SerializeField] private float _maxCoordinateY;
    [SerializeField] private float _minCoordinateY;

    [SerializeField] private Transform _point;

    [SerializeField] private Transform _movementPoint;

    private float _currentCount;

    public bool CanSpawn => _currentCount < _maxCount;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void GetFromPool(Vector2 position)
    {
        Enemy instance = _pool.GetObject(position);

        instance.SetMovementPoint(_movementPoint);

        instance.Destroying += ReturnToPool;

        _currentCount++;
    }

    private void ReturnToPool(Enemy instance)
    {
        _pool.ReturnObject(instance);

        instance.Destroying -= ReturnToPool;

        _currentCount--;
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_waitTime);

        while (enabled)
        {
            if (CanSpawn)
            {
                Vector2 position = new Vector2(_point.position.x, _point.position.y + Random.Range(_minCoordinateY, _maxCoordinateY));

                GetFromPool(position);
            }

            yield return waitForSeconds;
        }
    }
}
