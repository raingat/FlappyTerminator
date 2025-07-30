using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CollisionDetector))]
[RequireComponent(typeof(HeroMovement))]
[RequireComponent(typeof(AnimationHero))]
[RequireComponent(typeof(HeroAttack))]
public class Hero : MonoBehaviour
{
    private CollisionDetector _collisionDetector;

    private BoxCollider2D _boxCollider;

    private HeroMovement _heroMovement;

    public event Action GameOver;

    public void Reset()
    {
        _heroMovement.Reset();
    }

    private void Awake()
    {
        _heroMovement = GetComponent<HeroMovement>();

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
        GameOver?.Invoke();
    }
}
