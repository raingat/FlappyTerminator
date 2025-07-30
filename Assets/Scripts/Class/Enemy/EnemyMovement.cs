using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _point;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void LateUpdate()
    {
        _point = _enemy.GetMovementPoint();

        Vector2 position = transform.position;

        if (transform.position.x < _point.position.x)
            position.x = _point.position.x;
        else
            position.x = Mathf.Lerp(transform.position.x, _point.position.x, _speed * Time.deltaTime);

        transform.position = position;
    }
}
