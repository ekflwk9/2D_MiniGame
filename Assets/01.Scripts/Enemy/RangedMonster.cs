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
            arrows[i].SpawnArrow("Player", 3);
        }
    }

    private void Fire()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].isFire)
            {
                arrows[i].Fire(this.transform.position);
                break;
            }
        }
    }

    protected override void Move()
    {

    }
}
