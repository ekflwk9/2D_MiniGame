using UnityEngine;

public class PlayerComponent : MonoBehaviour,
IAwake
{
    private Animator anim;
    private Rigidbody2D rigid;

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

        rigid.linearVelocity = pos.normalized * speed * Time.smoothDeltaTime;
    }

    public void Direction(bool _isLeft)
    {
        this.transform.localScale = _isLeft ? Vector3.left : Vector3.right;
    }
}
