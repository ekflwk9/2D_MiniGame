public class Bow : Weapon
{
    public override int critical { get; protected set; } = 5;
    public override int dmg { get; protected set; } = 2;
    private Arrow[] arrows;

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

        //�ӽ� ���� ����
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
