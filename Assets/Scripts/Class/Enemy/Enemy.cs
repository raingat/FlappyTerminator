using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CollisionDetector))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour
{
    private CollisionDetector _collisionDetector;

    public event Action<Enemy> Destroying;

    private BoxCollider2D _boxCollider;

    private Transform _movementPoint;

    private void Awake()
    {
        _collisionDetector = GetComponent<CollisionDetector>();

        _boxCollider = GetComponent<BoxCollider2D>();

        _boxCollider.isTrigger = true;
    }

    private void OnEnable()
    {
        _collisionDetector.Collided += HandleCollision;
    }

    private void OnDisable()
    {
        _collisionDetector.Collided -= HandleCollision;
    }

    private void HandleCollision()
    {
        Destroying?.Invoke(this);
    }

    public void SetMovementPoint(Transform point)
    {
        _movementPoint = point;
    }

    public Transform GetMovementPoint()
    {
        return _movementPoint;
    }
}
