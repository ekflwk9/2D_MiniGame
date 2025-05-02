public class Bow : Weapon
{
    private Arrow[] arrows;
    public override float knockback { get; protected set; } = 2f;
    public override int critical { get; protected set; } = 5;
    public override int dmg { get; protected set; } = 2;

    public override void OnAwake()
    {
        base.OnAwake();

        var arrow = Service.FindResource("Weapon", "Arrow");
        arrows = new Arrow[20];

        for (int i = 0; i < arrows.Length; i++)
        {
            var gameObject = Instantiate(arrow);
            arrows[i] = gameObject.GetComponent<Arrow>();
            arrows[i].SpawnArrow();
        }

        //임시 무기 장착
        GameManager.SetComponent(this);
    }

    public override void Ready()
    {

        anim.Play("Ready", -1, 0);

    }

    public override void Attack()
    {

        anim.Play("Attack", -1, 0);

        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].isFire)
            {
                arrows[i].Fire(this.transform.position);
                break;
            }
        }

    }
}
