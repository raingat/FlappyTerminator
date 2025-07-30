using UnityEngine;

public class AnimationHero : MonoBehaviour
{
    private static readonly int Fly = Animator.StringToHash("Fly");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationFly()
    {
        _animator.SetTrigger(Fly);
    }
}
