using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    public Vector2 range { get; private set; }
    private Vector2 size;
    private Vector2 nextPos;

    private Animator anim;
    private Transform target;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        target = FindFirstObjectByType<PlayerComponent>().transform;
        if (target == null) Debug.Log("�÷��̾ �������� ����");

        size = new Vector2(17.78f, 10f);
        this.transform.position = target.transform.position;

        GameManager.SetComponent(this);
    }

    private void Update()
    {
        //�� ��ġ => �÷��̾� ��ġ ����
        if (target != null)
        {
            var thisPos = this.transform.position;
            nextPos = Vector2.Lerp(thisPos, target.transform.position, 0.015f);

            //ī�޶� ��ġ + ī�޶� ������
            var camSize = size * 0.5f;
            var posVal = nextPos + camSize;
            var negVal = nextPos + (camSize * -1);

            //�� ������
            var posRange = range * 0.5f;
            var negRange = range * -0.5f;

            //x�� �˻�
            if (posVal.x > posRange.x) nextPos.x = posRange.x - camSize.x;
            else if (negVal.x < negRange.x) nextPos.x = negRange.x + camSize.x;

            //y�� �˻�
            if (posVal.y > posRange.y) nextPos.y = posRange.y - camSize.y;
            else if (negVal.y < negRange.y) nextPos.y = negRange.y + camSize.y;

            //��ġ ����
            this.transform.position = nextPos;
        }
    }

    public void SetRange(Vector2 _range) => range = _range;
    public void Shake() => anim.Play("Shake", 0, 0);
    public void HitShake() => anim.Play("Hit", 0, 0);
}
