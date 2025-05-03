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
            var right = nextPos + camSize;
            var left = nextPos + (camSize * -1);

            //�� ������
            var rightRange = range * 0.5f;
            var leftRange = range * -0.5f;

            //x�� �˻�
            if (right.x > rightRange.x) nextPos.x = rightRange.x - camSize.x;
            else if (left.x < leftRange.x) nextPos.x = leftRange.x + camSize.x;

            //y�� �˻�
            if (right.y > rightRange.y) nextPos.y = rightRange.y - camSize.y;
            else if (left.y < leftRange.y) nextPos.y = leftRange.y + camSize.y;

            //��ġ ����
            this.transform.position = nextPos;
        }
    }

    public void SetRange(Vector2 _range) => range = _range;
    public void Shake() => anim.Play("Shake", 0, 0);
    public void HitShake() => anim.Play("Hit", 0, 0);
}
