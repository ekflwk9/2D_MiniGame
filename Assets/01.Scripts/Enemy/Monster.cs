using UnityEngine;

public abstract class Monster : MonoBehaviour,
IStart, IHit
{
    [Header("몬스터 정보")]
    [SerializeField] protected int dmg;
    [SerializeField] protected int health;
    [SerializeField] protected float knockback;
    [SerializeField] protected float moveSpeed;

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

    public virtual void Respawn()
    {
        health = maxHealth;
    }

    protected abstract void Move();

    protected virtual void OnWalk()
    {
        //애니메이터 호출 메서드
        var effectPos = this.transform.position + bloodPos;
        GameManager.effect.OnEffect(effectPos, direction, EffectCode.Walk);
        GameManager.sound.OnEffect("Walk");
    }

    private void OnIdle()
    {
        //애니메이션 호출 메서드
        isMove = true;
        anim.Play("Idle", 0, 0);
        rigid.linearVelocity = Vector3.zero;
    }

    public virtual void OnHit(int _dmg)
    {
        health -= _dmg;
        isMove = false;
        rigid.linearVelocity = (target.position - this.transform.position) * -knockback;

        var effectPos = this.transform.position + bloodPos;
        GameManager.effect.OnEffect(effectPos, direction, EffectCode.Blood);
        GameManager.sound.OnEffect($"{this.name}Hit");

        if (health > 0) anim.Play("Hit", 0, 0);
        else this.gameObject.SetActive(false);     
    }

    private void Update()
    {
        if (isMove && GameManager.player.health > 0) Move();
    }
}
