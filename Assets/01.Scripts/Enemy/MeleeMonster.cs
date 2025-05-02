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

            //몬스터 보는 방향
            direction.x = target.position.x < transform.position.x ? -1 : 1;
            transform.localScale = direction;

            //몬스터 이동 위치
            var movePos = target.position - transform.position;
            rigid.linearVelocity = movePos.normalized * moveSpeed;
        }
    }
}
