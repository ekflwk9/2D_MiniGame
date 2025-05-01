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
        //�ִϸ��̼� ȣ�� �޼���
        isAttack = false;
        isReady = false;
    }
}
