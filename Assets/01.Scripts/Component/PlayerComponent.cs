using UnityEngine;

public class PlayerComponent : MonoBehaviour,
IHit, IDestroy
{
    public int health { get; private set; } = 15;
    private float moveSpeed = 3.5f;

    private Animator anim;
    private Rigidbody2D rigid;
    private GameObject touchItem;

    private Vector3 effectDirection = Vector3.one;
    private Vector3 direction = Vector3.one;
    private Vector3 pos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        DontDestroyOnLoad(this.gameObject);
        GameManager.SetComponent(this);
    }

    private void Update()
    {
        if (!GameManager.stopGame)
        {
            Move();
            OnItem();
        }
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

        rigid.linearVelocity = pos.normalized * moveSpeed;
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

        GameManager.sound.OnEffect("PlayerHit");
        GameManager.effect.On(this.transform.position, EffectCode.Blood);
        GameManager.cam.HitShake();
        GameManager.gameEvent.Call("SetHpSlider");

        if (health <= 0)
        {
            health = 15;
            anim.SetBool("Move", false);

            GameManager.stopGame = true;
            this.gameObject.SetActive(false);

            GameManager.fade.OnFade(FadeFunc, 0.3f);
        }
    }

    private void OnItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (touchItem != null)
            {
                GameManager.gameEvent.Call(touchItem.name);
                touchItem = null;
            }
        }
    }

    private void FadeFunc()
    {
        GameManager.ChangeScene("Loby");
        GameManager.stopGame = false;
    }

    public void OnDestroyHandler()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) touchItem = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) touchItem = null;
    }
}
