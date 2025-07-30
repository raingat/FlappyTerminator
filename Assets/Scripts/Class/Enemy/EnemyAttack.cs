using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private SpawnerBullet _spawnerBullet;

    [SerializeField] private Transform _position;

    [SerializeField] private float _maxWaitTime;
    [SerializeField] private float _minWaitTime;

    private void OnEnable()
    {
        StartCoroutine(Shot());
    }

    private void Shoot()
    {
        _spawnerBullet.GetFromPool(_position.position, transform.rotation);
    }

    private IEnumerator Shot()
    {
        WaitForSeconds waitForSeconds;

        while (enabled)
        {
            waitForSeconds = new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));

            yield return waitForSeconds;

            Shoot();
        }
    }
}
