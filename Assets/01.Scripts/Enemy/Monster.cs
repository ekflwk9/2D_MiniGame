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
        if (anim == null) Debug.Log($"{this.name}에 애니메이터가 존재하지 않음");

        rigid = GetComponent<Rigidbody2D>();
        if (rigid == null) Debug.Log($"{this.name}에 Rigidbody2D가 존재하지 않음");

        target = GameManager.player.transform;
        GameManager.SetComponent(this);
    }

    protected abstract void Move();

    protected abstract void Attack();

    private void EndAttack()
    {
        //애니메이션 호출 메서드
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
