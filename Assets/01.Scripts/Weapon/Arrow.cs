using Unity.Mathematics;
using UnityEngine;

public class Arrow : MonoBehaviour,
IDestroy
{
    public bool isFire { get; private set; }
    private int dmg;
    private string targetName;
    private float speed;
    private Rigidbody2D rigid;

    public void SpawnArrow(string _targetName, int _dmg, float _speed, bool _isPooling = false)
    {
        dmg = _dmg;
        targetName = _targetName;
        speed = _speed;

        rigid = GetComponent<Rigidbody2D>();
        this.transform.position = Vector3.one * 1000;

        if(_isPooling) DontDestroyOnLoad(this.gameObject);
        GameManager.SetComponent(this);
    }

    public void Fire(Vector3 _targetPos, Vector3 _firePos)
    {
        //위치 설정
        this.transform.position = _firePos;

        //현재 마우스 위치
        var target = _targetPos;
        _firePos.x = target.x - _firePos.x;
        _firePos.y = target.y - _firePos.y;

        //각도 계산
        var atan = math.atan2(_firePos.y, _firePos.x);
        var deg = math.degrees(atan);
        deg += 270f;

        //각도 할당
        this.transform.rotation = Quaternion.Euler(0, 0, deg);

        //발사
        rigid.linearVelocity = _firePos.normalized * speed;
        isFire = true;
    }

    public void OnDestroyHandler()
    {
        Destroy(this.gameObject);
    }

    private void SetOff()
    {
        isFire = false;
        rigid.linearVelocity = Vector2.zero;
        this.transform.position = Vector3.down * 1000;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.effect.On(this.transform.position, EffectCode.Arrow);
            GameManager.sound.OnEffect("ArrowHitWall");

            SetOff();
        }

        if (collision.gameObject.CompareTag(targetName))
        {
            GameManager.gameEvent.Hit(collision.gameObject.name, dmg);
            SetOff();
        }
    }
}
