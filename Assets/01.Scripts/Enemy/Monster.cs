using UnityEngine;

public abstract class Monster : MonoBehaviour,
IStart, IHit
{
    [Header("몬스터 정보")]
    [SerializeField] protected int dmg;
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float knockback;
    [SerializeField] protected float attackRange;

    [Space(10f)]
    [Header("블러드 임펙트 스폰 위치 조정")]
    [SerializeField] protected Vector3 bloodPos;

    private int maxHealth;
    protected bool isMove = true;
    protected Vector3 direction = Vector3.one;

    protected Transform target;
    protected Animator anim;
    protected Rigidbody2D rigid;

    public virtual void OnStart()
    {
        maxHealth = health;

        anim = GetComponent<Animator>();
        if (anim == null) Debug.Log($"{this.name}에 애니메이터가 존재하지 않음");

        rigid = GetComponent<Rigidbody2D>();
        if (rigid == null) Debug.Log($"{this.name}에 Rigidbody2D가 존재하지 않음");

        target = GameManager.player.transform;
        GameManager.SetComponent(this);
    }

    protected virtual void OnWalk()
    {
        //애니메이터 호출 메서드
        var effectPos = this.transform.position + bloodPos;
        GameManager.effect.OnEffect(effectPos, direction, EffectCode.Walk);
        GameManager.sound.OnEffect("Walk");
    }

    protected virtual void OnIdle()
    {
        //애니메이션 호출 메서드
        isMove = true;
        anim.Play("Idle", 0, 0);
        rigid.linearVelocity = Vector3.zero;
    }

    public virtual void OnHit(int _dmg)
    {
        health -= _dmg;

        var effectPos = this.transform.position + bloodPos;
        GameManager.effect.OnEffect(effectPos, direction, EffectCode.Blood);
        GameManager.sound.OnEffect($"{this.name}Hit");

        if (health > 0)
        {
            isMove = false;
            rigid.linearVelocity = (target.position - this.transform.position) * -knockback;
            anim.Play("Hit", 0, 0);
        }

        else
        {
            isMove = true;
            rigid.linearVelocity = Vector3.zero;
            anim.Play("Idle", 0, 0);

            health = maxHealth;
            this.gameObject.SetActive(false);
        }
    }

    protected virtual void Update()
    {
        if (isMove && !GameManager.stopGame) Move();
    }

    protected virtual void Move()
    {
        if (Service.Distance(target.position, transform.position) < attackRange)
        {
            rigid.linearVelocity = Vector2.zero;
            anim.SetBool("Move", false);

            isMove = false;
            anim.Play("Attack", 0, 0);
        }

        else
        {
            anim.SetBool("Move", true);

            //몬스터 보는 방향
            direction.x = target.position.x < transform.position.x ? -1 : 1;
            transform.localScale = direction;

            //몬스터 이동 위치
            var movePos = target.position - transform.position;
            rigid.linearVelocity = movePos.normalized * moveSpeed;
        }
    }
}
