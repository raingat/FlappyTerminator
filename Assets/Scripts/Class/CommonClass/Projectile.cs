using UnityEngine;

[CreateAssetMenu(fileName = "projectile", menuName = "Projectile/Create new bullet", order = 51)]
public class Projectile : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}
