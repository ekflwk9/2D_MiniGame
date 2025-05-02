using UnityEngine;

public abstract class Weapon : MonoBehaviour,
IAwake
{
    protected bool canAttack;
    protected Animator anim;

    public abstract float knockback { get; protected set; }
    public abstract int critical { get; protected set; }
    public abstract int dmg { get; protected set; }

    public virtual void OnAwake() => anim = GetComponent<Animator>();
    public abstract void Ready();
    public abstract void Attack();
    private void EndReady() => canAttack = true; //�ִϸ��̼� ȣ�� �޼���
    private void EndAttack() => canAttack = false; //�ִϸ��̼� ȣ�� �޼���
}
