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
}
