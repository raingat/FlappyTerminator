using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CollisionDetector))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private Projectile _projectile;

    private CollisionDetector _collisionDetector;

    private BoxCollider2D _boxCollider;

    public event Action<Bullet> Dash;

    private void Awake()
    {
        _collisionDetector = GetComponent<CollisionDetector>();

        _boxCollider = GetComponent<BoxCollider2D>();

        _boxCollider.isTrigger = true;
    }

    private void OnEnable()
    {
        _collisionDetector.Collided += ReturnToPool;

        StartCoroutine(Move());
    }

    private void OnDisable()
    {
        _collisionDetector.Collided -= ReturnToPool;
    }

    private void ReturnToPool()
    {
        Dash?.Invoke(this);
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            transform.Translate(transform.right * _projectile.Speed * Time.deltaTime, Space.World);

            yield return null;
        }
    }
}
