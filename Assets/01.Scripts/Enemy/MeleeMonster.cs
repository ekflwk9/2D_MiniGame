using UnityEngine;

public class MeleeMonster : Monster
{
    private void AttackRange()
    {
        if (Service.Distance(target.position, transform.position) < 2.7f)
        {
            Debug.Log("플레이어 히트 !");
            GameManager.gmaeEvent.Hit("Player", dmg);
            GameManager.effect.On(target.position, EffectCode.Blood);
            GameManager.sound.OnEffect("PlayerHit");
        }
    }

    protected override void Attack()
    {
        if (!isAttack)
        {
            isAttack = true;
            anim.Play("Attack", 0, 0);
        }
    }

    protected override void Move()
    {
        if (Service.Distance(target.position, transform.position) < 2f)
        {
            rigid.linearVelocity = Vector2.zero;
            anim.SetBool("Move", false);
            Attack();
        }

        else
        {
            anim.SetBool("Move", true);

            if (target.position.x < transform.position.x) direction.x = -1;
            else direction.x = 1;

            transform.localScale = direction;
            var movePos = target.position - transform.position;
            rigid.linearVelocity = movePos.normalized * moveSpeed;
        }
    }
}
