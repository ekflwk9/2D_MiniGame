using UnityEngine;

public class MeleeMonster : Monster
{
    private void AttackRange()
    {
        if (Service.Distance(target.position, transform.position) < 2.7f)
        {
            GameManager.gameEvent.Hit("Player", dmg);
        }
    }

    protected override void Move()
    {
        if (Service.Distance(target.position, transform.position) < 1.5f)
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
