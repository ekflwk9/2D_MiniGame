using UnityEngine;

public abstract class Monster : MonoBehaviour,
IStart, IHit
{
    [SerializeField] protected int dmg;
    [SerializeField] protected int health;
    [SerializeField] protected int moveSpeed;

    protected bool isAttack;
    protected Vector3 direction = Vector3.one;

    protected Transform target;
    protected Animator anim;
    protected Rigidbody2D rigid;

    public virtual void OnStart()
    {
        anim = GetComponent<Animator>();
        if (anim == null) Debug.Log($"{this.name}�� �ִϸ����Ͱ� �������� ����");

        rigid = GetComponent<Rigidbody2D>();
        if (rigid == null) Debug.Log($"{this.name}�� Rigidbody2D�� �������� ����");

        target = GameManager.player.transform;
        GameManager.SetComponent(this);
    }

    protected abstract void Move();

    protected abstract void Attack();

    private void EndAttack()
    {
        //�ִϸ��̼� ȣ�� �޼���
        isAttack = false;
        anim.Play("Idle", 0, 0);
    }

    public virtual void OnHit(int _dmg)
    {
        health -= _dmg;
        if (health <= 0) anim.Play("Dead", -1, 0);
    }

    private void Update()
    {
        Move();
        Attack();
    }
}
