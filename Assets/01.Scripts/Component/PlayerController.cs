using UnityEngine;

public class PlayerController : MonoBehaviour,
IAwake
{
    private Animator anim;
    private Rigidbody2D rigid;

    private Vector3 direction = Vector3.one;
    private Vector3 pos;
    private float speed = 300f;

    public void OnAwake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameManager.SetComponent(this);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        pos.x = 0f;
        pos.y = 0f;

        //���� ����
        if(Input.GetKey(KeyCode.W)) pos.y = 1f;
        else if(Input.GetKey(KeyCode.S)) pos.y = -1f;

        //�¿� ����
        if(Input.GetKey(KeyCode.A)) pos.x = -1f;
        else if(Input.GetKey(KeyCode.D)) pos.x = 1f;

        //�ִϸ��̼� ����
        if (pos != Vector3.zero) anim.SetBool("Move", true);
        else anim.SetBool("Move", false);

        rigid.linearVelocity = pos.normalized * speed * Time.smoothDeltaTime;
    }

    public void Direction(bool _isLeft)
    {
        direction.x = _isLeft ? -1f : 1f;
        this.transform.localScale = direction;
    }

    private void OnEffect() => GameManager.effect.On(this.transform.position,"Walk");
}
