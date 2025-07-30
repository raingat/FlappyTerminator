using UnityEngine;

public class HeroTracker : MonoBehaviour
{
    [SerializeField] private Hero _target;

    [SerializeField] private float _xOffset;

    private void LateUpdate()
    {
        Vector2 position = transform.position;

        position.x = _target.transform.position.x + _xOffset;

        transform.position = position;
    }
}
