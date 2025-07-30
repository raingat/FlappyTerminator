using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
    }
}
