using UnityEngine;

public class FlappyControll : MonoBehaviour
{
    private bool isDead;
    private Rigidbody2D rigid;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;

        GameManager.gameEvent.Add(FlappyStart);
        GameManager.SetComponent(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isDead) rigid.linearVelocity += Vector2.up * 5f;
        }

        this.transform.rotation = Quaternion.Euler(0, 0, rigid.linearVelocity.y * 5f);
    }

    private void FlappyStart()
    {
        isDead = false;
        anim.SetBool("Dead", isDead);

        var setPos = this.transform.position;
        setPos.y = 0;
        this.transform.position = setPos;

        rigid.gravityScale = 1.3f;
        rigid.linearVelocity = Vector2.right * 6f;
        rigid.linearVelocity += Vector2.up * 7f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isDead = true;
            anim.SetBool("Dead", isDead);
            rigid.linearVelocity = Vector3.zero;

            GameManager.gameEvent.Call("FlappyOnMenu");
        }
    }
}
