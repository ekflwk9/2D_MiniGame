using UnityEngine;

public class Bow : Weapon
{
    public override int critical { get; protected set; } = 5;
    public override int dmg { get; protected set; } = 2;

    public override void OnAwake()
    {
        base.OnAwake();

        //임시 무기 장착
        GameManager.SetComponent(this);
    }

    public override void Ready()
    {
        if(!isReady)
        {
            isReady = true;
            anim.Play("Ready", -1, 0);
        }
    }

    public override void Attack()
    {
        if (!isAttack)
        {
            isAttack = true;
            anim.Play("Attack", -1, 0);
        }
    }
}
