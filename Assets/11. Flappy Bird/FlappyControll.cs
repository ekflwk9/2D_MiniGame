using UnityEngine;

public class FlappyControll : MonoBehaviour,
IGameEvent
{
    private bool isDead;
    private Rigidbody2D rigid;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        rigid.linearVelocity = Vector2.right * 6f;
        rigid.linearVelocity += Vector2.up * 7f;

        GameManager.SetComponent(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!isDead) rigid.linearVelocity += Vector2.up * 5f;
        }

        this.transform.rotation = Quaternion.Euler(0, 0, rigid.linearVelocity.y * 5f);
    }

    public void OnGameEvent()
    {
        isDead = false;
        anim.SetBool("Dead", isDead);

        this.transform.position = new Vector3(this.transform.position.x, 2, 0);
        rigid.linearVelocity += Vector2.up * 7f;
        rigid.linearVelocity = Vector2.right * 6f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            //upScore
        }

        else if (collision.gameObject.CompareTag("Wall"))
        {
            //GameOver
            isDead = true;
            anim.SetBool("Dead", isDead);
        }
    }
}
