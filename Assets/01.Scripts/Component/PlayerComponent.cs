using UnityEngine;

public class PlayerComponent : MonoBehaviour,
IAwake, IHit, IDestroy
{
    public int health { get; private set; } = 15;
    private float moveSpeed = 300f;

    private Animator anim;
    private Rigidbody2D rigid;

    private Vector3 effectDirection = Vector3.one;
    private Vector3 direction = Vector3.one;
    private Vector3 pos;

    public void OnAwake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameManager.SetComponent(this);
    }

    private void Update()
    {
        if(health > 0) Move();
    }

    private void Move()
    {
        pos.x = 0f;
        pos.y = 0f;

        //상하 조작
        if (Input.GetKey(KeyCode.W)) pos.y = 1f;
        else if (Input.GetKey(KeyCode.S)) pos.y = -1f;

        //좌우 조작
        if (Input.GetKey(KeyCode.A)) pos.x = -1f;
        else if (Input.GetKey(KeyCode.D)) pos.x = 1f;

        //애니메이션 조작
        if (pos != Vector3.zero) anim.SetBool("Move", true);
        else anim.SetBool("Move", false);

        rigid.linearVelocity = pos.normalized * moveSpeed * Time.smoothDeltaTime;
    }

    public void Direction(bool _isLeft)
    {
        direction.x = _isLeft ? -1f : 1f;
        this.transform.localScale = direction;
    }

    private void OnWalkEffect()
    {
        effectDirection.z = direction.x;
        var effectPos = transform.position + Vector3.down * 0.8f;

        GameManager.effect.OnEffect(effectPos, effectDirection, EffectCode.Walk);
        GameManager.sound.OnEffect("Walk");
    }

    public void OnHit(int _dmg)
    {
        health -= _dmg;
        GameManager.effect.On(this.transform.position, EffectCode.Blood);

        if (health > 0)
        {
            GameManager.sound.OnEffect("PlayerHit");
        }

        else
        {
            //GameManager.gmaeEvent.
        }
    }

    public void OnDestroyHandler()
    {
        DestroyImmediate(this.gameObject);
    }
}
