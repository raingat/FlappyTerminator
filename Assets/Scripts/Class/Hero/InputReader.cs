using UnityEngine;

public class InputReader
{
    private const KeyCode FlyKey = KeyCode.Space;
    private const KeyCode AttackKey = KeyCode.Q;

    public bool IsFlying()
    {
        return Input.GetKeyDown(FlyKey);
    }

    public bool IsAttack()
    {
        return Input.GetKeyDown(AttackKey);
    }
}
