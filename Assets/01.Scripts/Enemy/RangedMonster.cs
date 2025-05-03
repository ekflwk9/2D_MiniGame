using UnityEngine;

public class RangedMonster : Monster
{
    private Arrow[] arrows;

    public override void OnStart()
    {
        base.OnStart();

        var arrow = Service.FindResource("Weapon", "Arrow");
        arrows = new Arrow[3];

        for (int i = 0; i < arrows.Length; i++)
        {
            var gameObject = Instantiate(arrow);
            arrows[i] = gameObject.GetComponent<Arrow>();
            arrows[i].SpawnArrow("Player", 3, 6f);
        }
    }

    private void Fire()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].isFire)
            {
                arrows[i].Fire(target.position, this.transform.position);
                break;
            }
        }
    }

    protected override void Move()
    {
        if (Service.Distance(target.position, transform.position) < 25f)
        {
            rigid.linearVelocity = Vector2.zero;
            anim.SetBool("Move", false);

            isMove = false;
            anim.Play("Attack", 0, 0);
        }

        else
        {
            anim.SetBool("Move", true);

            //���� ���� ����
            direction.x = target.position.x < transform.position.x ? -1 : 1;
            transform.localScale = direction;

            //���� �̵� ��ġ
            var movePos = target.position - transform.position;
            rigid.linearVelocity = movePos.normalized * moveSpeed;
        }
    }
}
