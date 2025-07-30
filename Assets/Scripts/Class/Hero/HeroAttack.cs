using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] private SpawnerBullet _spawnerBullet;

    [SerializeField] private Transform _position;

    private InputReader _inputReader = new();

    private void Update()
    {
        if (_inputReader.IsAttack())
            Shoot();
    }

    private void Shoot()
    {
        _spawnerBullet.Spawn(_position.position, transform.rotation);
    }
}
