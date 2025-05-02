using Unity.Mathematics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool isFire { get; private set; }
    private Rigidbody2D rigid;

    public void SpawnArrow()
    {
        rigid = GetComponent<Rigidbody2D>();

        DontDestroyOnLoad(this.gameObject);
        this.transform.position = Vector3.one * 1000;
    }

    public void Fire(Vector3 _firePos)
    {
        //��ġ ����
        this.transform.position = _firePos;

        //���� ���콺 ��ġ
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _firePos.x = target.x - _firePos.x;
        _firePos.y = target.y - _firePos.y;

        //���� ���
        var atan = math.atan2(_firePos.y, _firePos.x);
        var deg = math.degrees(atan);
        deg += 270f;

        //���� �Ҵ�
        this.transform.rotation = Quaternion.Euler(0, 0, deg);

        //�߻�
        rigid.linearVelocity = _firePos.normalized * 15f;
        isFire = true;
    }

    public void Destroy()
    {
        DestroyImmediate(this.gameObject);
    }

    private void SetOff()
    {
        isFire = false;
        rigid.linearVelocity = Vector2.zero;
        this.transform.position = Vector3.one * 1000;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.effect.On(this.transform.position, EffectCode.Arrow);
            GameManager.sound.OnEffect("ArrowHitWall");

            SetOff();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.gmaeEvent.Hit(collision.gameObject.name, 2);
            SetOff();
        }
    }
}
