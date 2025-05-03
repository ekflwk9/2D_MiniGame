using UnityEngine;

public abstract class Monster : MonoBehaviour,
IStart, IHit
{
    [Header("���� ����")]
    [SerializeField] protected int dmg;
    [SerializeField] protected int health;
    [SerializeField] protected float knockback;
    [SerializeField] protected float moveSpeed;

    [Space(10f)]
    [Header("���� ����Ʈ ���� ��ġ ����")]
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
        if (anim == null) Debug.Log($"{this.name}�� �ִϸ����Ͱ� �������� ����");

        rigid = GetComponent<Rigidbody2D>();
        if (rigid == null) Debug.Log($"{this.name}�� Rigidbody2D�� �������� ����");

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
        //�ִϸ����� ȣ�� �޼���
        var effectPos = this.transform.position + bloodPos;
        GameManager.effect.OnEffect(effectPos, direction, EffectCode.Walk);
        GameManager.sound.OnEffect("Walk");
    }

    private void OnIdle()
    {
        //�ִϸ��̼� ȣ�� �޼���
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
