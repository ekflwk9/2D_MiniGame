using UnityEngine;

public abstract class Weapon : MonoBehaviour,
IAwake
{
    protected bool isReady;
    protected bool isAttack;
    protected Animator anim;

    public abstract int critical { get; protected set; }
    public abstract int dmg { get; protected set; }

    public virtual void OnAwake() => anim = GetComponent<Animator>();
    public abstract void Ready();
    public abstract void Attack();

    private void EndAttack()
    {
        //애니메이션 호출 메서드
        isAttack = false;
        isReady = false;
    }
}
