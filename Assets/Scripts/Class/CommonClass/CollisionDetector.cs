using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action Collided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out IInteractable _))
            Collided?.Invoke();
    }
}
