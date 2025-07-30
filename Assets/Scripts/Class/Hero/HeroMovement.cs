using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speedHorizontal;
    [SerializeField] private float _speedVertical;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private Vector2 _startPosition;

    private AnimationHero _animation;

    private Rigidbody2D _rigidbody;

    private InputReader _inputReader = new();

    private void Awake()
    {
        _animation = GetComponent<AnimationHero>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;

        _maxRotation = Quaternion.Euler(0.0f, 0.0f, _maxRotationZ);
        _minRotation = Quaternion.Euler(0.0f, 0.0f, _minRotationZ);
    }

    private void Update()
    {
        if (_inputReader.IsFlying())
            Fly();

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speedRotation * Time.deltaTime);

        Vector2 currentPosition = transform.position;

        currentPosition.y = Mathf.Clamp(transform.position.y, _minHeight, _maxHeight);

        transform.position = currentPosition;
    }

    private void Fly()
    {
        _rigidbody.velocity = new Vector2(_speedHorizontal, _speedVertical);

        transform.rotation = _maxRotation;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;

        _animation.PlayAnimationFly();
    }
}
