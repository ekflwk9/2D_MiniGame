using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool canAttack;
    protected Animator anim;

    public abstract float knockback { get; protected set; }
    public abstract int critical { get; protected set; }
    public abstract int dmg { get; protected set; }

    protected virtual void Awake() => anim = GetComponent<Animator>();
    public abstract void Ready();
    public abstract void Attack();
    private void EndReady() => canAttack = true; //애니메이션 호출 메서드
    private void EndAttack() => canAttack = false; //애니메이션 호출 메서드
}
